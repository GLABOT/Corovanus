using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoevement : MonoBehaviour
{
    public float speed;
    private Vector2 move;
    public GameObject targetPickUp;
    public bool isGrabbed = false;
    public BoxClass boxClass;




    void Update()
    {
        movePlayer();
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box") && isGrabbed == false)
        {
            boxClass = collision.gameObject.GetComponent<BoxClass>();
            Instantiate(boxClass.pickUpObject, targetPickUp.transform);
            isGrabbed = true;
        }

        if (collision.gameObject.CompareTag("Podnos") && isGrabbed == true)
        {
            string nameOfObject = boxClass.pickUpObject.name.ToString();
            Destroy(GameObject.Find(string.Concat(nameOfObject,"(Clone)")));
            isGrabbed = false;
        }
    }


}
