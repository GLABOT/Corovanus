using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Ingredients
{
    public class ItemDataBase : MonoBehaviour
    {
        public static ItemDataBase instance;
        //public List<Ingredients> 

    void Start()
        {
            if (instance == null)
                instance = this;
        }


    }
}
