using Autohand;
using System.Collections;
using System.Net.NetworkInformation;
using System.Net.Sockets;
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
                
                
                //Debug.LogWarning($"{ingredient.name}: Placed on Socket");
                Plate.AddIngridient(ingredient.GetComponent<BaseIngredient>().Type, gameObject);
                ingredient.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ingredient.GetComponent<Rigidbody>().isKinematic = true;

                ingredient.GetComponent<Grabbable>().enabled = false;
                ingredient.GetComponent<DistanceGrabbable>().enabled = false;
                StartCoroutine(WaitToNextFrame(ingredient));
            }
            else
            {
                Debug.LogWarning("Socket is not assigned");
            }
        }

        private IEnumerator WaitToNextFrame(Transform ingredient)
        {
            yield return new WaitForEndOfFrame();
            ingredient.parent = Socket;
            ingredient.localPosition = Vector3.zero;
        }
    }
}

