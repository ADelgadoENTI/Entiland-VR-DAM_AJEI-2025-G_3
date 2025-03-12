using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Recipe", order = 1)]
    public class Recipe : ScriptableObject
    {
        public Sprite Sprite;
        public GameObject Prefab;
        public float Time;
        public List<IngridientRecipe> Ingridients;
        public int ID;
    }
}