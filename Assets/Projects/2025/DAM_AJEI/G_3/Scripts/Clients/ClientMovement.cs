using Autohand;
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
        public bool iniciarPedido = false;
        private float paciencia; 
        private bool dishAnnounced = false;
        public GameObject ParticlesWin;
        public GameObject ParticlesLoose;

        public AudioSource AudioSource;
        public AudioClip AudioClipCorrect;
        public AudioClip AudioClipWrong;
        public AudioClip AudioClipBell;
        public AudioClip[] AudioClipsThanks;

        private MeshRenderer MeshRenderer;
        private MeshFilter MeshFilter;
        public Mesh[] Meshes;
        public Material[] Materials;
        void Start()
        {
            StartCoroutine(GoStreet());
            int rand = Random.Range(0, recipes.Count);

            pedido = recipes[rand];
            paciencia = Random.Range(0, 31);

            Debug.Log(pedido.ID);
            MeshRenderer = GetComponent<MeshRenderer>();
            MeshFilter = GetComponent<MeshFilter>();
            int randomMesh = Random.Range(0, Meshes.Length);
            MeshFilter.mesh = Meshes[randomMesh];
            MeshRenderer.material = Materials[randomMesh];
        }

        private IEnumerator GoStreet()
        {
            while (!reachedCenter)
            {
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
                    transform.position += transform.forward * Time.deltaTime * speed;
                }
                else
                {
                    if (iniciarPedido)
                    {
                        if (!dishAnnounced)
                        {
                            GameManager.instance.tablet.ActivePedido(pedido, paciencia, this);
                            AudioSource.PlayOneShot(AudioClipBell);
                            dishAnnounced = true;
                        }
                    }
                }
                yield return new WaitForEndOfFrame();
            }

        }

        public void FinishDish()
        {
            finishedDish = true;
            ClientManager.instance.NextClient();
            //hacer algo
            ClientManager.instance.KillClient(gameObject);
        }

        public void PedidoEntregado()
        {

            foreach (GameObject pedidos in GameManager.instance.tablet.pedidos)
            {
                if (pedidos.GetComponent<PedidoTablet>().pedido.ID == pedido.ID)
                {
                    pedidos.GetComponent<PedidoTablet>().ReserTimeBar();
                    break;
                }
            }

            FinishDish();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Objective"))
            {
                reachedCenter = true;
            }
            else if(other.TryGetComponent(out Dish d))
            {

                if (d.id == pedido.ID) 
                { 
                    PedidoEntregado();
                    Instantiate(ParticlesWin, transform.position, transform.rotation);
                    AudioSource.PlayOneShot(AudioClipCorrect);
                    StartCoroutine(WaitForAudio());
                    Debug.Log(d.id);
                }
                else
                {
                    Instantiate(ParticlesLoose, transform.position, transform.rotation);
                    AudioSource.PlayOneShot(AudioClipWrong);
                }
                    //Debug.Log("Echo");

                other.GetComponent<Grabbable>().enabled = false;
                Destroy(other.gameObject);
            }
        }

        private IEnumerator WaitForAudio()
        {
            yield return new WaitForSeconds(AudioClipCorrect.length);
            AudioSource.PlayOneShot(AudioClipsThanks[Random.Range(0, AudioClipsThanks.Length)]);
        }
    }
}