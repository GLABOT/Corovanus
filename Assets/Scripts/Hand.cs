using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public static Hand instance;
    public GameObject inHand;
    //private Rigidbody rb;
    public float throwForce;
  

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PutInHand(GameObject ingridient)
    {
        GameObject ingridientInstance = Instantiate(ingridient);
        Debug.Log(ingridient + " puted in hand!");
        ingridientInstance.transform.SetParent(transform); // Сделать переданный объект дочерним объектом левой руки
        ingridientInstance.transform.localPosition = Vector3.zero; // Установить локальную позицию объекта в (0, 0, 0)
        ingridientInstance.transform.localRotation = Quaternion.identity; // Установить локальную ротацию объекта в начальное положение
        inHand = ingridientInstance;

        
    }

    public void ReleaseObject()
    {
        inHand.transform.SetParent(null); // Отсоединить объект от руки
        //rb.isKinematic = false;
        Destroy(inHand);
        inHand = null;
    }
}