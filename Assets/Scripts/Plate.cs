using System.Collections.Generic;
using System.Linq;
using ScriptableObjects.Ingredients;
using ScriptableObjects.RecipeItems;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private int _maxIngredients;
    [SerializeField] private float _ingredientsOffset;
    [SerializeField] private Transform _ingredientsCreationPoint;
    private List<IngredientInfo> _ingredients;
    public RecipeItemInfo Recipe;
    private List<GameObject> _ingredientPrefabs;

    private void Awake()
    {
        _ingredients = new List<IngredientInfo>();
        _ingredientPrefabs = new List<GameObject>();
    }

    public void AddIngredient(IngredientInfo ingredient)
    {
        if (!Recipe.ingredients.Contains(ingredient) || _ingredients.Contains(ingredient)) return;
        _ingredients.Add(ingredient);
        _ingredientPrefabs.Add(ingredient.prefab);
        RearrangeIngredients();
    }

    private void RearrangeIngredients()
    {
        if (_ingredients.Count > 1)
        {
            for (int j = 0; j < _ingredients.Count; j++) // bubblesort ^.^
            {
                for (int i = 0; i < _ingredients.Count - 1; i++)
                {
                    if (_ingredients[i].priority < _ingredients[i + 1].priority)
                    {
                        (_ingredients[i], _ingredients[i + 1]) = (_ingredients[i + 1], _ingredients[i]);
                    }
                }
            }
        }
        
        RecreateIngredients();
    }

    private void RecreateIngredients()
    {
        for (int i = 0; i < _ingredients.Count; i++)
        {
            Destroy(_ingredientPrefabs[i]);
        }
        
        for (int i = 0; i < _ingredients.Count; i++)
        {
            Vector3 offset = new Vector3(0f, _ingredientsOffset * i, 0f);
            _ingredientPrefabs[i] = Instantiate(_ingredients[i].prefab, 
                _ingredientsCreationPoint.position + offset, Quaternion.identity);
        }
    }
}