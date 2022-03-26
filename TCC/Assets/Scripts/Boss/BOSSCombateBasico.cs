using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSCombateBasico : MonoBehaviour
{
    public BOSSGerenciador gerenciador;
    public BOSSProjetil tiro;
    public Transform pontoDisparo;
    public bool podeAtirar;
    public bool cdEstado;
    public float velocidadeDeAtaque;
    public float tempoEstado;
    public FSMBoss fsm;

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
                transform.LookAt(new Vector3(gerenciador.alvo.transform.position.x - transform.position.x, transform.position.y, gerenciador.alvo.transform.position.z - transform.position.z));
                fsm.ChangeAnimationState("");
                fsm.ChangeAnimationState(fsm.Atirando());
                BOSSProjetil tiroDisparado;
                tiroDisparado = Instantiate(tiro.gameObject, pontoDisparo.position, pontoDisparo.rotation).GetComponent<BOSSProjetil>();
                tiroDisparado.direcao = gerenciador.alvo.transform.position - pontoDisparo.position;
                tiroDisparado.atirou = true;
                tiroDisparado.transform.LookAt(tiroDisparado.direcao);
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
        fsm.ChangeAnimationState(fsm.Idle());
        cdEstado = false;
    }
}
