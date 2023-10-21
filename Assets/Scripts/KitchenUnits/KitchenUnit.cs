using ScriptableObjects.Ingredients;
using UnityEngine;
using UnityEngine.Serialization;

namespace KitchenUnits
{
    public abstract class KitchenUnit : MonoBehaviour // родительский класс для всей кухонной утвари
    {
        [SerializeField] protected Transform _ingredientInstantiateTransform;
        public GameObject CookedIngredient { get; protected set; }
        public float timeToCook;
        
        
        public abstract void Cook(IngredientInfo ingredient); // метод который нужно вызывать для готовки :)
    }
}