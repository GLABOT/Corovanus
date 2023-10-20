using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject targetPickUp;
    private Vector3 movement;
    private bool _isGrabbed;
    private bool _isCooking;
    private BoxClass _boxClass;
    
    private void FixedUpdate()
    {
        if (_isCooking) return;
        MovePlayer();
    }

    private void Update()
    {
        if (_isCooking) return;
        RotatePlayer();
    }

    private void MovePlayer()
    {
        transform.Translate(UserInput() * (_speed * Time.deltaTime), Space.World);
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
            movement = UserInput();

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
    }
    private Vector3 UserInput()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");
        return new Vector3(horizontalInput, 0f, verticalInput);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box") && _isGrabbed == false)
        {
            _boxClass = collision.gameObject.GetComponent<BoxClass>();
            Instantiate(_boxClass.pickUpObject, targetPickUp.transform);
            _isGrabbed = true;
        }

        if (collision.gameObject.CompareTag("Podnos") && _isGrabbed == true)
        {
            string nameOfObject = _boxClass.pickUpObject.name.ToString();
            Destroy(GameObject.Find(string.Concat(nameOfObject,"(Clone)")));
            _isGrabbed = false;
        }
    }
}
