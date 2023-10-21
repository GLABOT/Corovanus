using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using KitchenUnits;
using ScriptableObjects.Ingredients;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject targetPickUp;
    private Vector3 _movement;
    private bool _isGrabbed;
    private bool _isCooking;
    private GameObject _objectInHand;
    
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
        _isCooking = true;
        yield return new WaitForSeconds(time);
        _isCooking = false;
        _objectInHand = Instantiate(cookedIngredient, targetPickUp.transform);
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box") && _objectInHand == null && Input.GetKey(KeyCode.E))
        {
            var boxClass = collision.gameObject.GetComponent<BoxClass>();
            _objectInHand = Instantiate(boxClass.pickUpObject, targetPickUp.transform);
        }
        //adding objectInHand to plate
        if (collision.gameObject.CompareTag("Podnos") && _objectInHand != null && Input.GetKey(KeyCode.E))
        {
            var plate = collision.gameObject.GetComponent<Plate>();
            plate.AddIngredient(_objectInHand.GetComponent<Ingredient>().ingredient);
            Destroy(_objectInHand);
        }
        //cooking something on something
        if (collision.gameObject.CompareTag("KitchenUnit") && _objectInHand != null && Input.GetKey(KeyCode.E) && !_isCooking)
        {
            var kitchenUnit = collision.gameObject.GetComponent<KitchenUnit>();
            kitchenUnit.Cook(_objectInHand.GetComponent<Ingredient>().ingredient);
            Destroy(_objectInHand);
            StartCoroutine(Cook(kitchenUnit.timeToCook, kitchenUnit.CookedIngredient));
        }
    }
}
