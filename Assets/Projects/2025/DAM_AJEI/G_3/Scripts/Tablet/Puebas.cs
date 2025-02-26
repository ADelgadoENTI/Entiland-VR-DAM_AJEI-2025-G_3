using Autohand.Demo;
using EntilandVR.DosCinco.DAM_AJEI.G_TRES;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puebas : MonoBehaviour
{
    public Recipe Pedido;
    public GameObject pedidoObject;
    public TabletLogic tabelt;


    public void SpawnPedido()
    {
        tabelt.ActivePedido(Pedido, 5f);
    }
}
