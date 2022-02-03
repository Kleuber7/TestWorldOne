using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaPlayer : MonoBehaviour
{
    [SerializeField] private Slider barraDeVida;
    [SerializeField] private Jogador_Status scriptDeStatus;

    private void Start() 
    {   
        if(this.gameObject.tag == "Player")
        {
            scriptDeStatus = this.gameObject.GetComponent<Jogador_Status>();
        }
    }
    private void Update() 
    {
        barraDeVida.value = ((scriptDeStatus.Vida * 100) / scriptDeStatus.Vida_Maxima);
    }
}
