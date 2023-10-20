using UnityEngine;

namespace ScriptableObjects.Ingredients
{
    [CreateAssetMenu(fileName = "IngredientInfo")]
    public class IngredientInfo : ScriptableObject
    {
        [SerializeField] private string _ingredientName;
        [SerializeField] private GameObject _prefab;
        public string ingredientName => _ingredientName;
        public string prefab => prefab;
    }
}