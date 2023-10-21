using System.Collections;
using System.Security.Cryptography;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace KitchenUnits.ConcreteUnits
{
    public class SlicingTable : KitchenUnit
    {
        public override void Cook(IngredientInfo ingredient)
        {
            CookedIngredient = ingredient.slicedIngredient.prefab;
            StartCoroutine(WaitForSlice(ingredient));
        }

        private IEnumerator WaitForSlice(IngredientInfo ingredient)
        {
            var cookingIngredient = Instantiate(ingredient.prefab, _ingredientInstantiateTransform);
            yield return new WaitForSeconds(timeToCook);
            Destroy(cookingIngredient);
            
        }
    }
}