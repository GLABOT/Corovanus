using System.Collections.Generic;
using ScriptableObjects.Ingredients;
using UnityEngine;

public class RecipeItem : MonoBehaviour // родительский класс для всех типов еды
{
    [SerializeField] protected List<IngredientInfo> _ingredients;
}