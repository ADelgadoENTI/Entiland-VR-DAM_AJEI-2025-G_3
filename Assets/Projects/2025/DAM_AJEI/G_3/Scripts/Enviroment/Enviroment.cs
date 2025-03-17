using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class Enviroment : MonoBehaviour
    {
        public float speed;
        public float Realspeed;
        public bool direction;
        public bool stop;

        public Transform place1;
        public Transform place2;
        public int rand;

        private void Start()
        {
            Realspeed = speed;
        }

        void Update()
        {
            if (direction)
            {
                transform.position += new Vector3(0, 0, 1) * Time.deltaTime * Realspeed;
                transform.rotation = Quaternion.Euler(0, -90, 0);

            }
            else
            {
                transform.position += new Vector3(0, 0, -1) * Time.deltaTime * Realspeed;
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }

            if (stop)
            {
                Realspeed = 0;
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                StartCoroutine(Persons());
            }
        }

        private IEnumerator Persons()
        {
            stop = true;
            yield return new WaitForSeconds(Random.Range(1, 5));

            //rand = Random.Range(0, 2);
            rand = 1;
            if (rand == 1)
            {
                if (direction == true)
                {
                    direction = false;
                    stop = false;
                    Realspeed = speed;                  
                }
                else
                {
                    direction = true;
                    stop = false;
                    Realspeed = speed;
                }
            }
            if (rand == 0)
            {
                if (direction == true)
                {
                    transform.position = place1.position;
                    stop = false;
                    Realspeed = speed;
                }
                else
                {
                    transform.position = place2.position;
                    stop = false;
                    Realspeed = speed;
                }

            }


        }
    }
}

