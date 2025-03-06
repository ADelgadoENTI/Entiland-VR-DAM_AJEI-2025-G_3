using Autohand;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class IngridientCollisions : MonoBehaviour
    {
        private BaseIngredient _thisIngridient;

        private void Start()
        {
            _thisIngridient = GetComponent<BaseIngredient>();
        }

        private void OnTriggerEnter(Collider other)
        {
            BaseIngredient otherIngridient = other.GetComponent<BaseIngredient>();
            Plate plate = other.GetComponent<Plate>();
            if (otherIngridient != null && otherIngridient.IsOnPlate)
            {
                otherIngridient.PlaceInSocket(transform);
                _thisIngridient.Plate = otherIngridient.Plate;
                
                transform.rotation = Quaternion.identity;
                Destroy(this);
            }
            else if(plate != null && !plate.HasIngridient)
            {
                transform.rotation = Quaternion.identity;
                plate.PlaceInSocket(transform);
                
                Destroy(this);
            }
        }
    }
}