using EntilandVR.DosCinco.DAM_AJEI.G_TRES;
using System.Net.Sockets;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private Transform _socket;

    public bool HasIngridient;

    public void PlaceInSocket(Transform ingredient)
    {
        if (_socket != null)
        {
            ingredient.parent = _socket;
            ingredient.position = _socket.position;
            ingredient.GetComponent<BaseIngredient>().IsOnPlate = true;
            Debug.Log($"{ingredient.name} placed on plate");
            ingredient.position = Vector3.zero;
            HasIngridient = true;
        }
        else
        {
            Debug.LogWarning("Socket is not assigned");
        }
    }
}
