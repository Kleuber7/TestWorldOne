using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaBoss : MonoBehaviour
{
    [SerializeField] private Slider barraDeVida;
    [SerializeField] private BOSSStatus scriptDeStatus;

    private void FixedUpdate() 
    {
        barraDeVida.value = (scriptDeStatus.vida * 100 / scriptDeStatus.vidaMax) / 100;
        if(scriptDeStatus.vida <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
