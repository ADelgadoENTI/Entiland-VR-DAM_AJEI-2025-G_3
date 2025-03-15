using Autohand;
using System.Collections;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class BaseIngredient : MonoBehaviour
    {
        [SerializeField] public Transform Socket;

        public IngredientType Type;

        public bool IsOnPlate;

        public Plate Plate;

        //public void PlaceInSocket(Transform ingredient)
        //{
        //    if (Socket != null)
        //    {
        //        //Debug.LogWarning($"{ingredient.name}: Placed on Socket");
        //        //Plate.AddIngridient(ingredient.GetComponent<BaseIngredient>().Type, gameObject);
        //        ingredient.GetComponent<Grabbable>().enabled = false;
        //        ingredient.GetComponent<DistanceGrabbable>().enabled = false;
        //        ingredient.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //        ingredient.GetComponent<Rigidbody>().isKinematic = true;
        //        StartCoroutine(WaitToNextFrame(ingredient));
        //    }
        //    else
        //    {
        //        Debug.LogWarning("Socket is not assigned");
        //    }
        //}

        private IEnumerator WaitToNextFrame(Transform ingredient)
        {
            yield return new WaitForEndOfFrame();
            ingredient.GetComponentInChildren<MeshCollider>().enabled = false;
            ingredient.SetParent(Socket);
            ingredient.localPosition = Vector3.zero;
        }
    }
}

