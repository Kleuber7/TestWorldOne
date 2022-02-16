using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BOSSPath : MonoBehaviour
{
    public GameObject pontosPai;
    public Transform[] pontosPath;
    Vector3[] posicaoPontos;
    public Transform posicaoInicial;
    public float velocidade;
    public float duracaoPath;
    public bool iniciarPath;
    public OBJDano scriptDano;
    public BOSSGerenciador gerenciador;

    void FixedUpdate()
    {
        if(gerenciador.atravessar)
        {
            iniciarPath = true;
            gerenciador.atravessar = false;
        }

        if(iniciarPath)
        {
            SetaPontos();
            transform.DOMove(posicaoInicial.position, 1/velocidade).SetEase(Ease.InCirc).OnComplete(() => transform.DOPath(posicaoPontos, duracaoPath, PathType.Linear).SetEase(Ease.Linear).SetLookAt(-1).OnPlay(() => scriptDano.enabled = true).OnComplete(() => {scriptDano.enabled = false; StartCoroutine(gerenciador.DelayTrocaDeEstadoAtravessar());}));
            iniciarPath = false;
        }
    }

    public void SetaPontos()
    {
        DOTween.KillAll();

        Transform pontosSorteado = pontosPai.transform.GetChild(Random.Range(0, pontosPai.transform.childCount));
        
        pontosPath = new Transform[pontosSorteado.childCount];
        for(int i = 0; i < pontosPath.Length; i++)
        {
            pontosPath[i] = pontosSorteado.GetChild(i);
        }

        posicaoInicial = pontosPath[0];

        posicaoPontos = new Vector3[pontosPath.Length];
        for(int i = 0; i < pontosPath.Length; i++)
        {
            posicaoPontos[i] = pontosPath[i].position;
        }
    }
}
