using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class ClientManager : MonoBehaviour
    {
        public GameObject[] clients;
        public GameObject client;
        public Transform[] spawnpoints;
        public GameObject goEat;
        public Transform[] queuePositions;
        void Start()
        {
            StartCoroutine(SpawnClients());
        }
        void Update()
        {

        }
        IEnumerator SpawnClients()
        {
            for (int i = 0; i < 4; i++)
            {
                clients[i] = Instantiate(client, spawnpoints[Random.Range(0, 2)].transform.position, Quaternion.identity);
                clients[i].gameObject.transform.rotation = Quaternion.LookRotation(goEat.transform.position - clients[i].transform.position, Vector3.up);
                yield return new WaitForSeconds(.25f);
            }
            NextClient();
        }
        public void NextClient()
        {
            int length = clients.Length;
            if (length >= 4)
            {
                int temp = 0;
                GameObject[] newClients;
                newClients = new GameObject[length];
                for (int i = 0; i < length; i++)
                {
                    clients[i].TryGetComponent(out ClientMovement cL);
                    if (!cL.finishedDish)
                    {
                        newClients[temp] = clients[i];
                        temp++;
                    }
                }
                int tempLen = 4 - newClients.Length;
                if (tempLen > 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (newClients[i] == null)
                        {
                            newClients[i] = Instantiate(client, spawnpoints[Random.Range(0, 2)].transform.position, Quaternion.identity);
                            newClients[i].gameObject.transform.rotation = Quaternion.LookRotation(goEat.transform.position - newClients[i].gameObject.transform.position, Vector3.up);
                        }
                    }
                    clients = newClients;
                }
            }
            for(int i = 0; i < clients.Length; i++)
            {
                clients[i].TryGetComponent(out ClientMovement cL);
                cL.objectivePosition = queuePositions[i].position;
            }
        }
    }
}
