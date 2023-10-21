using ScriptableObjects.Ingredients;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] public IngredientInfo ingredient;
    public GameObject Prefab;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag != "Player")
            return;
        if (Hand.instance.inHand != null)
            return;

        if (Input.GetKey(KeyCode.E))
        {
            GameObject obj = Instantiate(Prefab, transform);
            Hand.instance.PutInHand(obj);
            PlayerMovement.instance.isHolding = true;
        }
    }
}