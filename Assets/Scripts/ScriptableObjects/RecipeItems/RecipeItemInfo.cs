using System.Collections.Generic;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace ScriptableObjects.RecipeItems
{
    [CreateAssetMenu(fileName = "RecipeItemInfo")]
    public class RecipeItemInfo : ScriptableObject
    {
        [SerializeField] private List<IngredientInfo> _ingredients;
        public List<IngredientInfo> ingredients => _ingredients;
    }
}