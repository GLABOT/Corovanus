using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public static Hand instance;
    public GameObject inHand;
    private Rigidbody rb;
    public float throwForce;
  

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PutInHand(GameObject ingridient)
    {
        Debug.Log(ingridient + " puted in hand!");
        ingridient.transform.SetParent(transform); // Сделать переданный объект дочерним объектом левой руки
        ingridient.transform.localPosition = Vector3.zero; // Установить локальную позицию объекта в (0, 0, 0)
        ingridient.transform.localRotation = Quaternion.identity; // Установить локальную ротацию объекта в начальное положение
        inHand = ingridient;
        rb = ingridient.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        
    }

    public void ReleaseObject()
    {
        inHand.transform.SetParent(null); // Отсоединить объект от руки
        rb.isKinematic = false;
        Destroy(inHand);
        inHand = null;
    }
}