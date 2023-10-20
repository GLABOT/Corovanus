using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float coolDown;

    private void Start()
    {
        if (instance == null)
            instance = this;

        StartCoroutine(WaitForOrder());
    }

    IEnumerator WaitForOrder()
    {
        int randnum = Random.Range(0, 15);
        Debug.Log("kd = " + (15+randnum));
        yield return new WaitForSeconds(10 + randnum);
        OrderSystem.instance.newOrder();
        StartCoroutine(WaitForOrder());
    }


}
