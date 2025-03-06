using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class SpawnIngredient : MonoBehaviour
    {
        [SerializeField] private GameObject ingredientPrefab;

        private void Start()
        {
            Spawn();
        }



        public void Spawn()
        {
            Instantiate(ingredientPrefab, transform.position, transform.rotation);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Grabbable>() != null)
            {
                Spawn();
            }
        }
    }
}
