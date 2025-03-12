using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class Plate : MonoBehaviour
    {
        [SerializeField] private Transform _socket;
        [SerializeField] private Menu _menu;

        private Dictionary<IngredientType, int> _ingridients = new Dictionary<IngredientType, int>();

        public bool HasIngridient;

        public void PlaceInSocket(Transform ingredient)
        {
            if (_socket != null)
            {
                
                //ingredient.position = _socket.position;
                BaseIngredient ing = ingredient.GetComponent<BaseIngredient>();
                ing.IsOnPlate = true;
                
                HasIngridient = true;
                IngredientType type = ing.Type;
                ing.Plate = this;
                AddIngridient(type);
                ingredient.GetComponent<Grabbable>().enabled = false;
                ingredient.GetComponent<DistanceGrabbable>().enabled = false;
                ing.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ing.GetComponent<Rigidbody>().isKinematic = true;
                StartCoroutine(WaitToNextFrame(ingredient));

                //Debug.Log($"{ingredient.name} placed on plate");
            }
            else
            {
                Debug.LogWarning("Socket is not assigned");
            }
        }

        private IEnumerator WaitToNextFrame(Transform ingredient)
        {
            yield return new WaitForEndOfFrame();
            ingredient.parent = _socket;
            ingredient.localPosition = Vector3.zero;
        }
        
        public void AddIngridient(IngredientType type)
        {
            //Debug.LogWarning(type);
            if (_ingridients.ContainsKey(type))
            {
                _ingridients[type]++;
            }
            else
            {
                _ingridients.Add(type, 1);
            }
            //Debug.Log($"{type} exists {_ingridients[type]}");
            CheckRecipe();
        }

        private void CheckRecipe()
        {
            foreach(Recipe recipe in _menu.Recipes) 
            {
                int matchCount = 0;
                foreach (IngridientRecipe ingridient in recipe.Ingridients) 
                {
                    IngredientType type = ingridient.Category;
                    if (_ingridients.ContainsKey((type)))
                    {
                        matchCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (matchCount == recipe.Ingridients.Count)
                {
                    Debug.LogWarning($"Recipe '{recipe.name}' is complete!");
                    break;
                }
                else
                {
                    Debug.Log($"Recipe '{recipe.name}' is incomplete.");
                }

            }
        }
    }
}