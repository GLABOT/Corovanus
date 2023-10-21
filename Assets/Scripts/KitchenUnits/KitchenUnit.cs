using ScriptableObjects.Ingredients;
using UnityEngine;
using UnityEngine.Serialization;

namespace KitchenUnits
{
    public abstract class KitchenUnit : MonoBehaviour // родительский класс для всей кухонной утвари
    {
        [SerializeField] protected Transform _ingredientInstantiateTransform;
        public float timeToCook;
        public GameObject cookedIngredient;
        
        public abstract void Cook(IngredientInfo ingredient); // метод который нужно вызывать для готовки :)
    }
}