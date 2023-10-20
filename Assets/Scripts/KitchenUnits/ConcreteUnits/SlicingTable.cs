using System.Collections;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace KitchenUnits.ConcreteUnits
{
    public class SlicingTable : KitchenUnit
    {
        public override void Cook(IngredientInfo ingredient)
        {
            StartCoroutine(WaitForSlice(ingredient));
        }

        private IEnumerator WaitForSlice(IngredientInfo ingredient)
        {
            yield return new WaitForSeconds(_timeToCook);
            Instantiate(ingredient.prefab, _ingredientInstantiateTransform);
        }
    }
}