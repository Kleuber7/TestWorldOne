using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INVCurandeiro : INVPerseguirAliado
{
    [SerializeField] float quantidadeDeCura;
    [SerializeField] bool podeCurar = true;
    [SerializeField] bool playerFerido = false;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(MorteAim());

        podeCurar = true;  
    }

    public IEnumerator MorteAim()
    {
        StartCoroutine(TempoDeVida());
        yield return new WaitForSeconds(5);
        NaoPerseguir();
        GetComponent<FSMInvocacoes>().Morrer();
        

    }



    private void Update() 
    {
        if(alvo != player)
        {
            SetAlvo();
        }

        if(alvo != null)
        {
            if(Vector3.Distance(transform.position, alvo.transform.position) >= distanciaParar && !stunado)
            {
               
                Perseguir();
            }
        }
        else
        {
            GetComponent<FSMInvocacoes>().ParadoAtaque();
            SetAlvo();
        }

        if(player.GetComponent<Jogador_Status>().Vida < player.GetComponent<Jogador_Status>().Vida_Maxima)
        {
            playerFerido = true;
        }
        else
        {
            playerFerido = false;
        }

        if(playerFerido)
        {
            if(podeCurar)
            {
                GetComponent<FSMInvocacoes>().Healing();
                StartCoroutine(CuraPorSegundo());
            }
        }
        else
        {
            GetComponent<FSMInvocacoes>().ParadoAtaque();
        }
    }

    public void Cura()
    {
        if(player != null)
        {
            player.GetComponent<Jogador_Status>().Vida += quantidadeDeCura;

            if(player.GetComponent<Jogador_Status>().Vida > player.GetComponent<Jogador_Status>().Vida_Maxima)
            {
                player.GetComponent<Jogador_Status>().Vida = player.GetComponent<Jogador_Status>().Vida_Maxima;
            }
        }
    }

    public override void SetAlvo()
    {
        alvo = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator CuraPorSegundo()
    {
        podeCurar = false;
        yield return new WaitForSeconds(1);
        Cura();
        podeCurar = true;
    }
}
