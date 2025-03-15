using Autohand;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class IngridientCollisions : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            Plate plate = other.GetComponent<Plate>();

            if (plate != null)
            {
                transform.rotation = Quaternion.identity;
                plate.PlaceInSocket(transform);
                Destroy(this);
            }
        }
    }
}