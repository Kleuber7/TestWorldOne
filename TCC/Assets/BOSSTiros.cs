using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BOSSTiros : MonoBehaviour
{
    public Transform posicaoInicial;
    public GameObject pontosDeDisparo;
    public Vector3 rotacaoInicial;
    public Vector3 rotacaoFinal;
    public float velocidade;
    public float velocidadeRotacao;
    public bool iniciarTiros;
    public GameObject prefabTiro;
    public Transform pontoDisparo;
    public int contadorDisparos = 0;
    public int numeroDeDisparos;

    void FixedUpdate()
    {
        if(iniciarTiros)
        {
            EscolhePontoDeDisparo();
            transform.DOMove(posicaoInicial.position, 1/velocidade).SetEase(Ease.Flash).OnComplete(() => transform.DORotate(new Vector3(posicaoInicial.rotation.x, posicaoInicial.rotation.y, posicaoInicial.rotation.z), 1/velocidadeRotacao).OnComplete(() => transform.DORotate(rotacaoInicial, 1/velocidadeRotacao).SetEase(Ease.InCirc).OnComplete(() => transform.DORotate(rotacaoFinal, 1/(velocidadeRotacao / 2)).SetDelay(1f).SetEase(Ease.Linear).OnPlay(() => StartCoroutine(Disparos())))));
            iniciarTiros = false;
        }
    }

    public void EscolhePontoDeDisparo()
    {
        posicaoInicial = pontosDeDisparo.transform.GetChild(Random.Range(0, pontosDeDisparo.transform.childCount - 1));
        rotacaoInicial = posicaoInicial.GetComponent<PontoDisparo>().rotacaoInicial;
        rotacaoFinal = posicaoInicial.GetComponent<PontoDisparo>().rotacaoFinal;
    }

    IEnumerator Disparos()
    {
        INITiro tiro = Instantiate(prefabTiro, pontoDisparo.position, pontoDisparo.rotation).GetComponent<INITiro>();
        tiro.gameObject.transform.localScale = new Vector3(5, 5, 5);
        tiro.direcao = tiro.gameObject.transform.forward;
        tiro.atirou = true;
        contadorDisparos++;
        yield return new WaitForSeconds((1/(velocidadeRotacao / 2))/numeroDeDisparos);
        if(contadorDisparos < numeroDeDisparos)
        {
            StartCoroutine(Disparos());
        }
        else
        {
            contadorDisparos = 0;
        }
    }
}
