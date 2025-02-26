using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class IngridientCollisions : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            BaseIngredient otherIngridient = other.GetComponent<BaseIngredient>();
            Plate plate = other.GetComponent<Plate>();
            if (otherIngridient != null && otherIngridient.IsOnPlate)
            {
                otherIngridient.PlaceInSocket(transform);
                Destroy(this);
            }
            else if(plate != null && !plate.HasIngridient)
            {
                plate.PlaceInSocket(transform);
                Destroy(this);
            }
        }
    }
}