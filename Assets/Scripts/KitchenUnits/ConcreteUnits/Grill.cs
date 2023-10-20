using System.Collections;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace KitchenUnits.ConcreteUnits
{
    public class Grill : KitchenUnit
    {
        public override void Cook(IngredientInfo ingredient)
        {
            StartCoroutine(WaitForGrill(ingredient));
        }

        private IEnumerator WaitForGrill(IngredientInfo ingredient)
        {
            yield return new WaitForSeconds(_timeToCook);
            Instantiate(ingredient.grilledIngredient.prefab, _ingredientInstantiateTransform);
        }
    }
}