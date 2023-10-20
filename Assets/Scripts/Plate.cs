using System;
using System.Collections.Generic;
using ScriptableObjects.Ingredients;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private int _maxIngredients;
    private List<IngredientInfo> _ingredients;
    
    private void Awake()
    {
        _ingredients = new List<IngredientInfo>();
    }

    private void AddIngredient(IngredientInfo ingredient)
    {
        if (_ingredients.Count<_maxIngredients)
            _ingredients.Add(ingredient);
    }

    private IngredientInfo TakeIngredient()
    {
        var lastIngredient = _ingredients[^1];
        _ingredients.RemoveAt(_ingredients.Count-1);
        return lastIngredient;
    }
}