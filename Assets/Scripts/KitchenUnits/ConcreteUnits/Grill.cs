using System.Collections;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace KitchenUnits.ConcreteUnits
{
    public class Grill : KitchenUnit
    {
        public override void Cook(IngredientInfo ingredient)
        {
            CookedIngredient = ingredient.grilledIngredient.prefab;
            StartCoroutine(WaitForGrill(ingredient));
        }

        private IEnumerator WaitForGrill(IngredientInfo ingredient)
        {
            var cookingIngredient = Instantiate(ingredient.prefab, _ingredientInstantiateTransform);
            yield return new WaitForSeconds(timeToCook);
            Destroy(cookingIngredient);
        }
    }
}