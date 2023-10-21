using System.Collections;
using KitchenUnits;
using KitchenUnits.ConcreteUnits;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _knife;
    [SerializeField] private GameObject _tray;
    [SerializeField] private GameObject _plate; // ингредиенты которые будут в руках пускай в этом трансформе будут
    [SerializeField] private Transform _holdingTransform;
    public bool isCooking; // поля для анимаций нужны, изменяются прям тут
    public bool isWashing;
    public bool isChopping;
    public bool isWalking;
    public bool isHolding;
    public bool isSaucing; // TODO: описать изменение надо
    public bool isHoldingPlate;
    public bool isHoldingIngredient;
    private Vector3 _movement;
    private GameObject _objectInHand;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _knife.GetComponent<MeshRenderer>().enabled = false;
        _plate.GetComponent<MeshRenderer>().enabled = false;
        _tray.GetComponent<MeshRenderer>().enabled = false;
    }
    
    private void FixedUpdate()
    {
        if (isCooking)
        {
            isWalking = false;
            return;
        }
        MovePlayer();
    }

    private void Update()
    {
        if (isCooking) return;
        UpdateBooleans();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        if (UserInput().Equals(Vector3.zero))
            _rigidbody.velocity = Vector3.zero;
        transform.Translate(UserInput() * (_speed * Time.deltaTime), Space.World);
    }

    private void UpdateBooleans()
    {
        isHolding = _objectInHand != null;
        isWalking = !UserInput().Equals(Vector3.zero);
    }
    
    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
            _movement = UserInput();

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_movement), 0.15f);
    }
    
    private Vector3 UserInput()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");
        return new Vector3(horizontalInput, 0f, verticalInput);
    }

    private IEnumerator Cook(float time, GameObject cookedIngredient)
    {
        isHolding = false;
        isCooking = true;
        yield return new WaitForSeconds(time);
        _knife.GetComponent<MeshRenderer>().enabled = false;
        isCooking = false;
        isWashing = false;
        isChopping = false;
        _objectInHand = Instantiate(cookedIngredient, _holdingTransform, true);
        isHolding = true;
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box") && !isHolding && Input.GetKey(KeyCode.E))
        {
            var boxClass = collision.gameObject.GetComponent<BoxClass>();
            _objectInHand = Instantiate(boxClass.pickUpObject, _holdingTransform, true);
            
            isHoldingIngredient = true;
        }
        //adding objectInHand to plate
        if (collision.gameObject.CompareTag("Podnos") && isHolding && Input.GetKey(KeyCode.E))
        {
            var plate = collision.gameObject.GetComponent<Plate>();
            plate.AddIngredient(_objectInHand.GetComponent<Ingredient>().ingredient);
            Destroy(_objectInHand);
            
            isHoldingIngredient = false;
        }
        //cooking something on something
        if (collision.gameObject.CompareTag("KitchenUnit") && isHoldingIngredient && Input.GetKey(KeyCode.E))
        {
            isHoldingIngredient = false;
            var kitchenUnit = collision.gameObject.GetComponent<KitchenUnit>();
            kitchenUnit.Cook(_objectInHand.GetComponent<Ingredient>().ingredient);
            Destroy(_objectInHand);
            StartCoroutine(Cook(kitchenUnit.timeToCook, kitchenUnit.CookedIngredient));
            
            if (kitchenUnit.GetType() == typeof(Sink))
            {
                isWashing = true;
                _knife.GetComponent<MeshRenderer>().enabled = true;
            }

            if (kitchenUnit.GetType() == typeof(SlicingTable))
            {
                isChopping = true;
                _knife.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
