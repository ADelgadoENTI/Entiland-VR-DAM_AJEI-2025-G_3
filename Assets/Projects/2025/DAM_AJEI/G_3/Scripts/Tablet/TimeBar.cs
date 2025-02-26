using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class TimeBar : MonoBehaviour
    {
        [SerializeField]private float _timeMax; 
        private float _timeMaxCounter;

        [SerializeField] private Image _timeBar;

        private void Start()
        {
            _timeMaxCounter = _timeMax;
        }

        void Update()
        {
            if (_timeMaxCounter <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _timeMaxCounter -= Time.deltaTime;

                float amount = _timeMaxCounter / _timeMax;
                
                _timeBar.fillAmount = amount;
            }
        }
    }
}
