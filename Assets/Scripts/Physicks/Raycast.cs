using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 20f))
        {
            Debug.Log("Hit Something");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * (hitinfo.distance) * 20f, Color.red);  
        }
        else
        {
            Debug.Log("Hit Nothing");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * (hitinfo.distance) * 20f, Color.blue);
        }
    }
}
