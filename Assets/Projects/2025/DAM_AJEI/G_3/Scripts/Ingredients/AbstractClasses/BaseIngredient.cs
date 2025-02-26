using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public abstract class BaseIngredient : MonoBehaviour
    {
        [SerializeField] private Transform Socket;

        protected Category IngredientCategory;

        public IngredientType Type;

        public bool IsOnPlate;

        public void PlaceInSocket(Transform ingredient)
        {
            if (Socket != null)
            {
                ingredient.parent = Socket;
                ingredient.position = Socket.position;
                ingredient.position = Vector3.zero;
                Debug.Log($"{ingredient.name}: Placed on Socket");
            }
            else
            {
                Debug.LogWarning("Socket is not assigned");
            }
        }

        public Category GetCategory() { return IngredientCategory; }
    }
}

