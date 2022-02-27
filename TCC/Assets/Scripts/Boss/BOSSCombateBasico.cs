using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSCombateBasico : MonoBehaviour
{
    public BOSSGerenciador gerenciador;
    public INITiro tiro;
    public Transform pontoDisparo;
    public bool podeAtirar;
    public bool cdEstado;
    public float velocidadeDeAtaque;
    public float tempoEstado;

    void FixedUpdate()
    {
        if(gerenciador.combateBasico)
        {
            StartCoroutine(TempoEstado());
            gerenciador.combateBasico = false;
        }

        if(cdEstado)
        {
            if(podeAtirar)
            {
                INITiro tiroDisparado;
                tiroDisparado = Instantiate(tiro.gameObject, pontoDisparo.position, pontoDisparo.rotation).GetComponent<INITiro>();
                tiroDisparado.direcao = gerenciador.alvo.transform.position - transform.position;
                tiroDisparado.atirou = true;
                StartCoroutine(CDDisparo());
            }
        }
    }

    public IEnumerator CDDisparo()
    {
        podeAtirar = false;
        yield return new WaitForSeconds(1/velocidadeDeAtaque);
        podeAtirar = true;
    }

    public IEnumerator TempoEstado()
    {
        cdEstado = true;
        podeAtirar = true;
        yield return new WaitForSeconds(tempoEstado);
        StopCoroutine(CDDisparo());
        StartCoroutine(gerenciador.DelayTrocaDeEstadoCombate());
        cdEstado = false;
    }
}
