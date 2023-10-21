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

            Hand.instance.ReleaseObject();
            PlayerMovement.instance.isHolding = false;
    }
}
