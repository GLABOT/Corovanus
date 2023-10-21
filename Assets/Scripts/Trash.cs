using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
            if (collision.transform.tag != "Player")
                return;
            if (Hand.instance.inHand == null)
                return;

        Debug.Log("touching trash");

            if (Input.GetKey(KeyCode.E))
            {
            Debug.Log("trashing");
            Hand.instance.ReleaseObject();
            }
    }
}
