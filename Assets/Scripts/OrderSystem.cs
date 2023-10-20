using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSystem : MonoBehaviour
{
    public static OrderSystem instance;

    private void Start()
    {
        if (instance == null)
            instance = this;
        
    }

    public void newOrder()
    {
        int randnum = Random.Range(0,10);       //до кол-ва рецептов сделать
        Debug.Log("NewOrderGiven");
    }
}
