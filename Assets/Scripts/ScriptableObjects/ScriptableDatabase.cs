using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects.Ingredients;
using ScriptableObjects.RecipeItems;

public class ScriptableDatabase : MonoBehaviour
{
    public static ScriptableDatabase instance = null;
    public List<RecipeItemInfo> recipes = new List<RecipeItemInfo>();
    public List<IngredientInfo> ingredients = new List<IngredientInfo>();

    private void Start()
    {
        if (instance == null)
            instance = this;
    }

}
