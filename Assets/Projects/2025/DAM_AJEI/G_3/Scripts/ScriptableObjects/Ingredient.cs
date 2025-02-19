using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    [CreateAssetMenu(fileName = "Ingridient", menuName = "ScriptableObjects/Ingridient", order = 0)]
    public class Ingredient : ScriptableObject
    {
        public PrimaryCategory PrimaryCategory;

        public IngredientType IngridientType;

        public float Price;

    }
}