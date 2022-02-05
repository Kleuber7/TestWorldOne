using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BOSSPath : MonoBehaviour
{
    public Transform[] pontosPath;
    Vector3[] posicaoPontos;
    public Transform posicaoInicial;
    public float velocidade;
    public float duracaoPath;
    public bool iniciarPath;
    OBJDano scriptDano;

    private void Start() 
    {
        scriptDano = this.GetComponent<OBJDano>();
        posicaoPontos = new Vector3[pontosPath.Length];
        for(int i = 0; i < pontosPath.Length; i++)
        {
            posicaoPontos[i] = pontosPath[i].position;
        }
    }

    void Update()
    {
        if(iniciarPath)
        {
            transform.DOMove(posicaoInicial.position, 1/velocidade).SetEase(Ease.InCirc).OnComplete(() => {this.gameObject.GetComponent<TrailRenderer>().enabled = true; transform.DOPath(posicaoPontos, duracaoPath, PathType.Linear).SetEase(Ease.Linear).OnPlay(() => scriptDano.enabled = true).OnComplete(() => { this.GetComponent<TrailRenderer>().enabled = false; scriptDano.enabled = false;});});
            iniciarPath = false;
        }
    }
}
