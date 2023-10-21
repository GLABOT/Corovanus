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
        int randnum = Random.Range(0,ScriptableDatabase.instance.recipes.Count);       //?? ???-?? ???????? ???????
        Debug.Log("You need to cook" + ScriptableDatabase.instance.recipes[randnum].name);
        GameManager.instance.currentRecipe = ScriptableDatabase.instance.recipes[randnum];
        GameObject instance = Instantiate(OrderPrefab, transform.position, Quaternion.identity, transform);
        Order orderComponent = instance.GetComponent<Order>();
        orderComponent.SetRecipe(ScriptableDatabase.instance.recipes[randnum]);
    }
}
