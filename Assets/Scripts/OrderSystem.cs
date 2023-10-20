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

    public void newOrder()
    {
        int randnum = Random.Range(0,ScriptableDatabase.instance.recipes.Count);       //до кол-ва рецептов сделать
        Debug.Log("You need to cook" + ScriptableDatabase.instance.recipes[randnum].name);
        GameObject instance = Instantiate(OrderPrefab, transform.position, Quaternion.identity, transform);
        Order orderComponent = instance.GetComponent<Order>();
        orderComponent.SetRecipe(ScriptableDatabase.instance.recipes[randnum]);
    }
}
