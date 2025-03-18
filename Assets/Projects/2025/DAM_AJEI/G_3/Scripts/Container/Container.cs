using System.Collections;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class Container : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        private bool _isSquashing;
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BaseIngredient>() || other.GetComponent<Dish>())
            {
                Destroy(other.gameObject);
                if (!_isSquashing ) StartCoroutine(SquashAndStretch());
            }
        }

        private IEnumerator SquashAndStretch()
        {
            _isSquashing = true;
            Vector3 newScale = new Vector3(1f, 1.3f, 0.8f);
            transform.localScale = newScale;
            yield return new WaitForSeconds(.2f);
            transform.localScale = Vector3.one;
            _isSquashing = false;
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}