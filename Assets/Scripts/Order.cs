using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects.Ingredients;
using ScriptableObjects.RecipeItems;

public class Order : MonoBehaviour
{
    public Image[] images = new Image[8];    
    public RecipeItemInfo recipe;

    private void findCells()
    {
        for (int i = 0; i < transform.GetChild(0).childCount; i++) {
            images[i] = transform.GetChild(0).GetChild(i).GetComponent<Image>();
        }
    }

    public void SetRecipe(RecipeItemInfo Recipe)
    {
        recipe = Recipe;
        findCells();
        hideNonActiveCells();
    }

    private void hideNonActiveCells()
    {
        for (int i = 7; i >= recipe.ingredients.Count; i--)
            images[i].gameObject.SetActive(false);
    }

    private void setIngridients()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = recipe.ingredients[i].sprite;
        }
    }


}
