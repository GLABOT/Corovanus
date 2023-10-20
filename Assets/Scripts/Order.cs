using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    //передать сюда случайный рецепт
    private List<Image> ingridients;    //image для ингридиентов рецепта

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++) {
            //transform.GetChild(i).GetComponent<Image>() = recipe[i];
        }
    }


}
