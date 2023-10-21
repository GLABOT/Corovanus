using System.Collections;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace KitchenUnits.ConcreteUnits
{
    public class DeepFryer : KitchenUnit
    {
        public override void Cook(IngredientInfo ingredient)
        {
            cookedIngredient = ingredient.deepFriedIngredient.prefab;
            StartCoroutine(WaitForFry(ingredient));
        }

        private IEnumerator WaitForFry(IngredientInfo ingredient)
        {
            var cookingIngredient = Instantiate(ingredient.prefab, _ingredientInstantiateTransform);
            yield return new WaitForSeconds(timeToCook);
            Destroy(cookingIngredient);
        }
    }
}