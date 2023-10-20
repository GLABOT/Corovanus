using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects.Ingredients;
using ScriptableObjects.RecipeItems;

public class Order : MonoBehaviour
{
    public List<Image> ingridients;    //image ??? ???????????? ???????
    public RecipeItemInfo recipe;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++) {
            ingridients[i] = transform.GetChild(i).GetComponent<Image>();
        }
    }


}
