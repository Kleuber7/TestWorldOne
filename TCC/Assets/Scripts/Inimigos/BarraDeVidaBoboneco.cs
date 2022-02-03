using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaBoboneco : MonoBehaviour
{
    [SerializeField] private Slider barraDeVida;
    [SerializeField] private StatusBoboneco scriptDeStatus;

    private void Update() 
    {
        barraDeVida.value = (scriptDeStatus.vida * 100 / scriptDeStatus.vidaMax) / 100;
    }
}
