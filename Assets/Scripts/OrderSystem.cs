using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects.Ingredients;
using ScriptableObjects.RecipeItems;

public class OrderSystem : MonoBehaviour
{
    public static OrderSystem instance;
    public GameObject OrderPrefab;


    private void Start()
    {
        if (instance == null)
            instance = this;
        
    }

    public void newOrder(RecipeItemInfo order)
    { 
        GameObject instance = Instantiate(OrderPrefab, transform.position, Quaternion.identity, transform);
        Order orderComponent = instance.GetComponent<Order>();
        orderComponent.SetRecipe(order);
    }
}
