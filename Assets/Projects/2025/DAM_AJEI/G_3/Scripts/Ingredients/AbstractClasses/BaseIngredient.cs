using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public abstract class BaseIngredient : MonoBehaviour
    {
        [SerializeField] protected Transform Socket { get; private set; }

        protected Category IngredientCategory { get; private set; }

        protected IngredientType Type { get; private set; }

        public void PlaceInSocket(Transform ingredient)
        {
            if (Socket != null)
            {
                ingredient.parent = transform;
                ingredient.position = Socket.position;
            }
            else
            {
                Debug.LogWarning("Socket is not assigned");
            }
        }
    }
}

