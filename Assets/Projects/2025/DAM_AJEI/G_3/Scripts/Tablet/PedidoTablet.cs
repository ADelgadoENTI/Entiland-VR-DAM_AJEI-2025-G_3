using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EntilandVR.DosCinco.DAM_AJEI.G_TRES
{
    public class PedidoTablet : MonoBehaviour
    {
        [SerializeField] private TimeBar _tBar;
        [SerializeField] private Image _sprite;

        public void Active(Recipe Pedido, float PacienciaCliente, ClientMovement client)
        {
            _tBar.SetTime(Pedido.Time + PacienciaCliente, client);
            _sprite.sprite = Pedido.Sprite;
        }
    }
}
