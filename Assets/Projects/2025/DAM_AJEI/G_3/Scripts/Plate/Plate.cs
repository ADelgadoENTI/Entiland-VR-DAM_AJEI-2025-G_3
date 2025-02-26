using EntilandVR.DosCinco.DAM_AJEI.G_TRES;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class Plate : MonoBehaviour
    {
        [SerializeField] private Transform _socket;

        private Dictionary<IngredientType, int> _ingridients = new Dictionary<IngredientType, int>();

        public bool HasIngridient;

        public void PlaceInSocket(Transform ingredient)
        {
            if (_socket != null)
            {
                ingredient.parent = _socket;
                //ingredient.position = _socket.position;
                BaseIngredient ing = ingredient.GetComponent<BaseIngredient>();
                ing.IsOnPlate = true;
                ingredient.localPosition = Vector3.zero;
                ing.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ing.GetComponent<Rigidbody>().isKinematic = true;
                HasIngridient = true;
                IngredientType type = ing.Type;
                ing.Plate = this;
                AddIngridient(type);
                //Debug.Log($"{ingredient.name} placed on plate");
            }
            else
            {
                Debug.LogWarning("Socket is not assigned");
            }
        }

        
        public void AddIngridient(IngredientType type)
        {
            Debug.LogWarning(type);
            if (_ingridients.ContainsKey(type))
            {
                _ingridients[type]++;
            }
            else
            {
                _ingridients.Add(type, 1);
            }
            Debug.Log($"{type} exists {_ingridients[type]}");
        }
    }
}