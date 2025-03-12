using Autohand;
using System.Net.NetworkInformation;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class BaseIngredient : MonoBehaviour
    {
        [SerializeField] private Transform Socket;

        public IngredientType Type;

        public bool IsOnPlate;

        public Plate Plate;

        public void PlaceInSocket(Transform ingredient)
        {
            if (Socket != null)
            {
                ingredient.parent = Socket;
                
                //Debug.LogWarning($"{ingredient.name}: Placed on Socket");
                Plate.AddIngridient(ingredient.GetComponent<BaseIngredient>().Type);
                ingredient.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ingredient.GetComponent<Rigidbody>().isKinematic = true;

                ingredient.GetComponent<Grabbable>().enabled = false;
                ingredient.GetComponent<DistanceGrabbable>().enabled = false;
                ingredient.localPosition = Vector3.zero;
            }
            else
            {
                Debug.LogWarning("Socket is not assigned");
            }
        }
    }
}

