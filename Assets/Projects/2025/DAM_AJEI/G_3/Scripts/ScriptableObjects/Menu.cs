using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    [CreateAssetMenu(fileName = "Menu", menuName = "ScriptableObjects/Menu", order = 2)]
    public class Menu : ScriptableObject
    {
        public List<Recipe> Recipes;
    }
}