using System;
using System.Collections.Generic;
using System.Linq;
using ScriptableObjects.Ingredients;
using ScriptableObjects.RecipeItems;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private int _maxIngredients;
    private List<IngredientInfo> _ingredients;
    private List<RecipeItemInfo> _allRecipesData; 
    
    private void Awake()
    {
        _ingredients = new List<IngredientInfo>();
        _allRecipesData = ScriptableDatabase.instance.recipes;
    }

    public void AddIngredient(IngredientInfo ingredient)
    {
        if (_ingredients.Count<_maxIngredients)
            _ingredients.Add(ingredient);
    }
    
    public void CleanPlate()
    {
        _ingredients.Clear();
    }

    public RecipeItemInfo CreateItem() // метод который возвращает рецепт если можно создать еду из 
    {                                   // лежащих на тарелке ингредиентов, иначе возвращает null 
        for (int i = 0; i < _allRecipesData.Count; i++)
        {
            if (_ingredients.Count != _allRecipesData[i].ingredients.Count) continue;
            if (_ingredients.All(_allRecipesData[i].ingredients.Contains))
                return _allRecipesData[i];
        }
        return null;
    }
}