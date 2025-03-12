using System.Collections;
using UnityEngine;

public class Container : MonoBehaviour
{
    private Mesh _mesh;

    private void Start()
    {
        _mesh = GetComponent<Mesh>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ingridient" || other.tag == "Dish")
        {
            Destroy(other.gameObject);
            StartCoroutine(SquashAndStretch());
        }
    }

    private IEnumerator SquashAndStretch()
    {
        Vector3 newScale = new Vector3(0.9f, 1.1f, 0);
        transform.localScale = newScale;
        yield return new WaitForSeconds(.5f);
        transform.localScale = Vector3.one;
    }
}
