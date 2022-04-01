using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class INIPatrulha : INIMovimento
{
    [SerializeField] private bool patrulha = false;
    [SerializeField] private INIPerseguir scriptPerseguir;
    [SerializeField] private Vector3 direcao;
    [SerializeField] private float tempoDescanso;
    [SerializeField] private float tempoPatrulha;
    [SerializeField] private INIPontos pontosScript;
    [SerializeField] private float velocidade;
    [SerializeField] private Transform[] pontos;
    private Vector3[] pontosDG;
    [SerializeField] private FSMInimigos iniAnima;
    [SerializeField] private float tempoDespertar;
    public bool despertando;
    public bool reinicia = false;
    

    private void Start() 
    {
        reinicia = false;
        iniAnima = GetComponent<FSMInimigos>();
        pontosDG = new Vector3[pontos.Length];
        for(int i = 0; i < pontos.Length; i++)
        {
            pontosDG[i] = pontos[i].position;
        }
        StartCoroutine(Despertar());
    }

    void FixedUpdate()
    {
        AplicaGravidade();

        if(patrulha)
        {
            if(!scriptPerseguir.GetPerseguir() && !this.gameObject.GetComponent<INIStatus>().GetStunado() && !scriptPerseguir.GetAtacando() && scriptPerseguir.finishAnimation)
            {
                    
                iniAnima.ChangeAnimationState(iniAnima.Patrulhando());
                if(reinicia)
                {
                    ReiniciaPatrulha();
                }
            }
        }
        else
        {
            ParaPatrulha();
        }
    }

    public bool GetPatrulha()
    {
        return patrulha;
    }

    public void SetPatrulha(bool valor)
    {
        patrulha = valor;
    }

    IEnumerator Despertar()
    {
        despertando = true;
        patrulha = false;
        yield return new WaitForSeconds(tempoDespertar);
        patrulha = true;
        despertando = false;
        transform.DOPath(pontosDG, 100 / velocidade, PathType.Linear).SetEase(Ease.Linear).SetLoops(-1).SetLookAt(.01f);
    }

    public void ParaPatrulha()
    {
        DOTween.Pause(transform);
        if(!despertando)
        {
            reinicia = true;
        }
    }

    public void ReiniciaPatrulha()
    {
        if(Vector3.Distance(transform.position, pontosDG[0]) > .1f)
        {
            transform.DOMove(pontosDG[0], (inimigo.transform.position - pontosDG[0]).magnitude / velocidade / 2).SetEase(Ease.Linear).OnComplete(() => {transform.DOPath(pontosDG, 100 / velocidade, PathType.Linear).SetEase(Ease.Linear).SetLoops(-1).SetLookAt(.01f);});
        }
        else
        {
            transform.DOPath(pontosDG, 100 / velocidade, PathType.Linear).SetEase(Ease.Linear).SetLoops(-1).SetLookAt(.01f);
        }
        transform.LookAt(new Vector3(pontosDG[0].x, transform.position.y, pontosDG[0].z));
        reinicia = false;
    }
}
