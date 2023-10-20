using System.Collections;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace KitchenUnits.ConcreteUnits
{
    public class DeepFryer : KitchenUnit
    {
        public override void Cook(IngredientInfo ingredient)
        {
            StartCoroutine(WaitForFry(ingredient));
        }

        private IEnumerator WaitForFry(IngredientInfo ingredient)
        {
            yield return new WaitForSeconds(_timeToCook);
            Instantiate(ingredient.deepFriedIngredient.prefab, _ingredientInstantiateTransform);
        }
    }
}