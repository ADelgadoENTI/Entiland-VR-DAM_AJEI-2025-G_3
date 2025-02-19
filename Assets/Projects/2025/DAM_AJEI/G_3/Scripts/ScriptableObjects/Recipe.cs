using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Recipe", order = 1)]
    public class Recipe : ScriptableObject
    {
        public List<Category> ObligatoryIngredients;
        public List<IngredientType> BannedIngredients;
    }
}