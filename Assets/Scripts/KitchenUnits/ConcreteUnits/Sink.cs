using System.Collections;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace KitchenUnits.ConcreteUnits
{
    public class Sink : KitchenUnit
    {
        public override void Cook(IngredientInfo ingredient)
        {
            StartCoroutine(WaitForWash(ingredient));
        }

        private IEnumerator WaitForWash(IngredientInfo ingredient)
        {
            yield return new WaitForSeconds(_timeToCook);
            Instantiate(ingredient.washedIngredient.prefab, _ingredientInstantiateTransform);
        }
    }
}