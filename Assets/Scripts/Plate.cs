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
    private List<RecipeItemInfo> _allRecipesData;
    private List<GameObject> _ingredientPrefabs;

    private void Awake()
    {
        _ingredients = new List<IngredientInfo>();
        _allRecipesData = ScriptableDatabase.instance.recipes;
    }

    public void AddIngredient(IngredientInfo ingredient)
    {
        if (_ingredients.Count<_maxIngredients)
            _ingredients.Add(ingredient);
        RearrangeIngredients();
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

    private void RearrangeIngredients()
    {
        if (_ingredients.Count < 2) return;
        for (int j = 0; j < _ingredients.Count; j++) // bubblesort ^.^
        {
            for (int i = 0; i < _ingredients.Count; i++)
            {
                if (_ingredients[i].priority < _ingredients[i + 1].priority)
                {
                    (_ingredients[i], _ingredients[i + 1]) = (_ingredients[i + 1], _ingredients[i]);
                }
            }
        }

        RecreateIngredients();
    }

    private void RecreateIngredients()
    {
        for (int i = 0; i < _ingredients.Count-1; i++)
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