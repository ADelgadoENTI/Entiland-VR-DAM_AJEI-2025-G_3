using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class TabletLogic : MonoBehaviour
    {
        public GameObject[] pedidos;


        public void ActivePedido(Recipe Pedido, float PacienciaCliente)
        {
            foreach (GameObject pedido in pedidos)
            {
                if (!pedido.active)
                {
                    pedido.SetActive(true);
                    pedido.GetComponent<PedidoTablet>().Active(Pedido, PacienciaCliente);
                    break;
                }
            }
        }
    }
}
