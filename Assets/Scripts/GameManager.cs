using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects.RecipeItems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public RecipeItemInfo[] recipesForFirstDay;
    public RecipeItemInfo[] recipesForSecondDay;
    public RecipeItemInfo[] recipesForThirdDay;
    int currentMeal;

    private void Start()
    {
        if (instance == null)
            instance = this;

        currentMeal = 0;
        StartCoroutine(WaitForOrder());
    }

    IEnumerator WaitForOrder()
    {
        int randnum = Random.Range(0, 15);
        Debug.Log("kd = " + (10+randnum));  //(10+randnum)
        yield return new WaitForSeconds(2);
        OrderSystem.instance.newOrder(recipesForFirstDay[currentMeal]);
        StartCoroutine(WaitForOrder());
    }


}
