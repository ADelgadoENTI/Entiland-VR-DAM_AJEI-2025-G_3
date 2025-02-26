using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class Prueba : MonoBehaviour
    {
        public TMP_Text timerText;
        public float timerCounter;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            timerCounter -= Time.deltaTime;
            int min = Mathf.FloorToInt(timerCounter / 60);
            int sec = Mathf.FloorToInt(timerCounter % 60);


            if (timerText != null) timerText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
    }
}
