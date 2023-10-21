using System.Collections;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace KitchenUnits.ConcreteUnits
{
    public class Sink : KitchenUnit
    {
        public override void Cook(IngredientInfo ingredient)
        {
            cookedIngredient = ingredient.washedIngredient.prefab;
            StartCoroutine(WaitForWash(ingredient));
        }

        private IEnumerator WaitForWash(IngredientInfo ingredient)
        {
            var cookingIngredient = Instantiate(ingredient.prefab, _ingredientInstantiateTransform);
            yield return new WaitForSeconds(timeToCook);
            Destroy(cookingIngredient);
        }
    }
}