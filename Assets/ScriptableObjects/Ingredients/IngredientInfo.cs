using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects.Ingredients
{
    [CreateAssetMenu(fileName = "IngredientInfo")]
    public class IngredientInfo : ScriptableObject
    {
        [SerializeField] private string _ingredientName;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private IngredientInfo _grilledIngredient;
        [SerializeField] private IngredientInfo _slicedIngredient;
        [SerializeField] private IngredientInfo _deepFriedIngredient;
        [SerializeField] private IngredientInfo _washedIngredient;
        public string ingredientName => _ingredientName;
        public string prefab => prefab;
        public IngredientInfo grilledIngredient => _grilledIngredient;
        public IngredientInfo slicedIngredient => _slicedIngredient;
        public IngredientInfo DeepFriedIngredient => _deepFriedIngredient;
        public IngredientInfo washedIngredient => _washedIngredient;
    }
}