using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        [Header("General Stats")]
        public float generalTimer = 0;
        public bool matchStarted = false;
        public int completedDishes = 0;
        [SerializeField]private float _maxTimer;

        private void Awake()
        { 
            if (instance == null)
            { 
                instance = this;
            } 
            else
            { 
                Destroy(this.gameObject);
                Destroy(this);
            }
        }
        void Start()
        {
            generalTimer = _maxTimer;
        }

        void Update()
        {
            if (matchStarted)
            {
                generalTimer -= Time.deltaTime;
                Debug.Log(generalTimer);
                if(generalTimer <= 0)
                {
                    generalTimer = 0;

                    //TODO("Trigger Event Match Finished")

                    matchStarted = false;
                }
            }
        }

        public void DishCompleted()
        {
            completedDishes++;
            if (completedDishes == 3)
            {
                StartCoroutine(StartMatch());
            }
        }

        private IEnumerator StartMatch()
        {
            //enseñar texto numero
            //3
            Debug.Log("3");
            yield return new WaitForSeconds(1f);
            //2
            Debug.Log("2");

            yield return new WaitForSeconds(1f);
            //1
            Debug.Log("1");

            yield return new WaitForSeconds(1f);
            Debug.Log("Start");

            //que ponga que esta abierto el local
            matchStarted = true;
        }

    }
}
