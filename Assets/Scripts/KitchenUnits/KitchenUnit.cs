using ScriptableObjects.Ingredients;
using UnityEngine;

namespace KitchenUnits
{
    public abstract class KitchenUnit : MonoBehaviour // родительский класс для всей кухонной утвари
    {
        [SerializeField] protected float _timeToCook;
        [SerializeField] protected Transform _ingredientInstantiateTransform;

        public abstract void Cook(IngredientInfo ingredient); // метод который нужно вызывать для готовки :)
    }
}