using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    [CreateAssetMenu(fileName = "Ingredient", menuName = "ScriptableObjects/Ingredient", order = 0)]
    public class Ingredient : ScriptableObject
    {
        public Category PrimaryCategory;

        public IngredientType IngredientType;

        public float Price;

    }
}