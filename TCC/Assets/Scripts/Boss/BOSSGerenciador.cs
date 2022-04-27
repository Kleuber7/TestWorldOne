using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BOSSGerenciador : MonoBehaviour
{
    public bool atirar;
    public bool combateBasico;
    public bool atravessar;
    public bool enfurecido;
    public GameObject alvo;
    public Transform posicaoCombate;
    public Transform posicoesCombate;
    public BOSSStatus status;
    public BOSSPath scriptPath;
    public BOSSTiros scriptTiros;
    public float delayTrocaDeEstado;
    public FSMBoss fsm;

    void Start()
    {
        alvo = GameManager.gameManager.GetPlayer();
        AtivaCombateBasico();
    }

    void FixedUpdate()
    {
        if(status.vida <= (status.vidaMax * .3f))
        {
            enfurecido = true;
        }
    }

    public void AlteraEstadoCombate()
    {
        combateBasico = false;
        int r = Random.Range(0,2);
        if(r == 0)
        {
            atirar = true;
        }
        else
        {
            atravessar = true;
        }
    }

    public void AlteraEstadoAtirar()
    {
        atirar = false;
        int r = Random.Range(0,2);
        if(r == 0)
        {
            AtivaCombateBasico();
        }
        else
        {
            atravessar = true;
        }
    }

    public void AlteraEstadoAtravessar()
    {
        atravessar = false;
        int r = Random.Range(0,2);
        if(r == 0)
        {
            AtivaCombateBasico();
        }
        else
        {
            atirar = true;
        }
    }

    public void EscolhePosicaoCombate()
    {
        posicaoCombate = posicoesCombate.GetChild(Random.Range(0, posicoesCombate.childCount));
    }

    public void PosicionaCombate()
    {
        EscolhePosicaoCombate();
        transform.LookAt(new Vector3(posicaoCombate.position.x, transform.position.y, posicaoCombate.position.z));
        transform.DOMove(posicaoCombate.position, (posicaoCombate.position - transform.position).magnitude / status.velocidade).SetEase(Ease.Linear).OnPlay(()=> {fsm.ChangeAnimationState(fsm.PreparandoPulo()); StartCoroutine(DelayPulo());}).OnComplete(() => transform.DORotate(posicaoCombate.GetComponent<PontoDisparo>().rotacaoInicial, 1/status.velocidade).SetEase(Ease.Linear).OnComplete(() => combateBasico = true));
    }

    public void AtivaCombateBasico()
    {
        PosicionaCombate();
    }

    public IEnumerator DelayTrocaDeEstadoCombate()
    {
        yield return new WaitForSeconds(delayTrocaDeEstado);
        AlteraEstadoCombate();
    } 

    public IEnumerator DelayTrocaDeEstadoAtirar()
    {
        yield return new WaitForSeconds(delayTrocaDeEstado);
        AlteraEstadoAtirar();
    } 

    public IEnumerator DelayTrocaDeEstadoAtravessar()
    {
        yield return new WaitForSeconds(delayTrocaDeEstado);
        AlteraEstadoAtravessar();
    }

    public IEnumerator DelayPulo()
    {
        yield return new WaitForSeconds(1);
        fsm.ChangeAnimationState(fsm.Pulo());
    } 
}
