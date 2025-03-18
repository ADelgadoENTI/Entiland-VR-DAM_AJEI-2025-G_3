using TMPro;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class TabletClients : MonoBehaviour
    {

        public TMP_Text TotalClients;
        public TMP_Text ClientsSatisfied;


        void Update()
        {
            if (GameManager.instance.matchStarted)
            {
                TotalClients.text = "Total: " + GameManager.instance.TotalClients;
                ClientsSatisfied.text = "Satisfied: " + GameManager.instance.ClientsSatisfied;
            }
            
        }
    }
}