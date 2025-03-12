using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class ClientMovement : MonoBehaviour
    {
        public float speed;
        public bool reachedCenter = false;
        public Vector3 objectivePosition;
        public bool finishedDish = false;
        public List<Recipe> recipes;
        public Recipe pedido;
        private float paciencia; 
        private bool dishAnnounced = false;
        void Start()
        {
            StartCoroutine(GoStreet());
            int rand = Random.Range(0, recipes.Count);

            pedido = recipes[rand];
            paciencia = Random.Range(0, 31);
        }

        private IEnumerator GoStreet()
        {
            while (!reachedCenter)
            {
                Debug.Log("Go");
                transform.position += transform.forward * Time.deltaTime * speed;
                yield return new WaitForEndOfFrame();
            }
                transform.rotation = Quaternion.LookRotation(objectivePosition - transform.position, Vector3.up);
                StartCoroutine(EnterStreet());
        }

        private IEnumerator EnterStreet()
        {
            while (!finishedDish)
            {
                if(Vector3.Distance(transform.position, objectivePosition) > 2)
                {
                    Debug.Log(Vector3.Distance(transform.position, objectivePosition));
                    transform.position += transform.forward * Time.deltaTime * speed;
                }
                yield return new WaitForEndOfFrame();
            }
            if (!dishAnnounced)
            {
                GameManager.instance.tablet.ActivePedido(pedido, paciencia);

                dishAnnounced = true;
            }
        }

        public void FinishDish()
        {
            finishedDish = true;
            //hacer algo
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Objective"))
            {
                reachedCenter = true;
            }
        }
    }
}