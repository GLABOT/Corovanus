using ScriptableObjects.Ingredients;
using UnityEngine;

namespace KitchenUnits
{
    public class Table : MonoBehaviour
    {
        [SerializeField] private Transform onTablePoint;
        public GameObject _itemOnTable { get; private set; }

        public void Place(GameObject item)
        {
            _itemOnTable = Instantiate(item, onTablePoint);
        }
        
        public GameObject Take()
        {
            var temp = _itemOnTable;
            Destroy(_itemOnTable);
            return temp;
        }
    }
}