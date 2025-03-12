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
        void Start()
        {

        }
        void Update()
        {

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
                    for (int i = 0; i < tempLen; i++)
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
        }
    }
}
