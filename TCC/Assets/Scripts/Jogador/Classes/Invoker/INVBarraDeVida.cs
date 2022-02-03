using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class INVBarraDeVida : MonoBehaviour
{
    [SerializeField] private Slider barraDeVida;
    [SerializeField] private INVStatus scriptDeStatus;

    private void Update() 
    {
        barraDeVida.value = (scriptDeStatus.vida * 100 / scriptDeStatus.vidaMax) / 100;
    }
}
