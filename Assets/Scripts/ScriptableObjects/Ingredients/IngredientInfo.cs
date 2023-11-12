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
        [SerializeField] private int _priority;
        public string ingredientName => _ingredientName;
        public GameObject prefab => _prefab;
        public IngredientInfo grilledIngredient => _grilledIngredient;
        public IngredientInfo slicedIngredient => _slicedIngredient;
        public IngredientInfo deepFriedIngredient => _deepFriedIngredient;
        public IngredientInfo washedIngredient => _washedIngredient;
        public int priority => _priority;
        public Sprite sprite;
    }
}