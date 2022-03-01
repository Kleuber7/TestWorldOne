using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class INVHUD : MonoBehaviour
{
    //[SerializeField] private bool aliado1 = true;
    //[SerializeField] private KeyCode teclaAliado1;
    //[SerializeField] private Button botaoAliado1;
    //[SerializeField] private float tempoDeRecargaBotao1;
    //[SerializeField] private float tempoDeRecarga1;
    //[SerializeField] private float custoMana1;
    //[SerializeField] private bool aliado2 = true;
    //[SerializeField] private KeyCode teclaAliado2;
    //[SerializeField] private Button botaoAliado2;
    //[SerializeField] private float tempoDeRecargaBotao2;
    //[SerializeField] private float tempoDeRecarga2;
    //[SerializeField] private float custoMana2;
    //[SerializeField] private bool aliado3 = true;
    //[SerializeField] private KeyCode teclaAliado3;
    //[SerializeField] private Button botaoAliado3;
    //[SerializeField] private float tempoDeRecargaBotao3;
    //[SerializeField] private float tempoDeRecarga3;
    //[SerializeField] private float custoMana3;
    //[SerializeField] private bool aliado4 = true;
    //[SerializeField] private KeyCode teclaAliado4;
    //[SerializeField] private Button botaoAliado4;
    //[SerializeField] private float tempoDeRecargaBotao4;
    //[SerializeField] private float tempoDeRecarga4;
    //[SerializeField] private float custoMana4;
    //[SerializeField] private GameObject player;
    //private float tempoDeRecarga;
    //private int aliadosInvocados = 0;
    //private bool podeInvocar = true;
    //private bool invocou = false;

    //[SerializeField] private INVInvoca scriptDeInvocacao;

    //private void Start() 
    //{
    //    player = GameObject.FindGameObjectWithTag("player");
    //}

    //private void Update() 
    //{
    //    if(!invocou)
    //    {
    //        if(!podeInvocar)
    //        {
    //            invocou = true;
    //        }
    //        else
    //        {
    //            if(aliado1 && Input.GetKeyDown(teclaAliado1))
    //            {
    //                chamaInvoca(0);
    //                tempoDeRecargaBotao1 = tempoDeRecarga1;
    //                StartCoroutine(Recarga1());
    //                player.GetComponent<Jogador_Status>().Mana -= custoMana1;
    //                aliado1 = false;
    //            }
    //            if(aliado2 && Input.GetKeyDown(teclaAliado2))
    //            {
    //                chamaInvoca(1);
    //                tempoDeRecargaBotao2 = tempoDeRecarga2;
    //                StartCoroutine(Recarga2());
    //                player.GetComponent<Jogador_Status>().Mana -= custoMana2;
    //                aliado2 = false;
    //            }
    //            if(aliado3 && Input.GetKeyDown(teclaAliado3))
    //            {
    //                chamaInvoca(2);
    //                tempoDeRecargaBotao3 = tempoDeRecarga3;
    //                StartCoroutine(Recarga3());
    //                player.GetComponent<Jogador_Status>().Mana -= custoMana3;
    //                aliado3 = false;
    //            }
    //            if(aliado4 && Input.GetKeyDown(teclaAliado4))
    //            {
    //                chamaInvoca(3);
    //                tempoDeRecargaBotao4 = tempoDeRecarga4;
    //                StartCoroutine(Recarga4());
    //                player.GetComponent<Jogador_Status>().Mana -= custoMana4;
    //                aliado4 = false;
    //            }
                
    //        }

    //        botaoAliado1.interactable = true;
    //        botaoAliado2.interactable = true;
    //        botaoAliado3.interactable = true;
    //        botaoAliado4.interactable = true;
    //    }
    //    else
    //    {
    //        botaoAliado1.interactable = false;
    //        botaoAliado2.interactable = false;
    //        botaoAliado3.interactable = false;
    //        botaoAliado4.interactable = false;
    //    }

    //    if(!aliado1)
    //    {
    //        tempoDeRecargaBotao1 -= Time.deltaTime;
    //        botaoAliado1.image.fillAmount =  1 - (((tempoDeRecargaBotao1 * 100) / tempoDeRecarga1) / 100);
    //        if(tempoDeRecargaBotao1 < 0)
    //        {
    //            tempoDeRecargaBotao1 = 0;
    //        }
    //    }

    //    if(!aliado2)
    //    {
    //        tempoDeRecargaBotao2 -= Time.deltaTime;
    //        botaoAliado2.image.fillAmount =  1 - (((tempoDeRecargaBotao2 * 100) / tempoDeRecarga2) / 100);
    //        if(tempoDeRecargaBotao2 < 0)
    //        {
    //            tempoDeRecargaBotao2 = 0;
    //        }
    //    }

    //    if(!aliado3)
    //    {
    //        tempoDeRecargaBotao3 -= Time.deltaTime;
    //        botaoAliado3.image.fillAmount =  1 - (((tempoDeRecargaBotao3 * 100) / tempoDeRecarga3) / 100);
    //        if(tempoDeRecargaBotao3 < 0)
    //        {
    //            tempoDeRecargaBotao3 = 0;
    //        }
    //    }
        
    //    if(!aliado4)
    //    {
    //        tempoDeRecargaBotao4 -= Time.deltaTime;
    //        botaoAliado4.image.fillAmount =  1 - (((tempoDeRecargaBotao4 * 100) / tempoDeRecarga4) / 100);
    //        if(tempoDeRecargaBotao4 < 0)
    //        {
    //            tempoDeRecargaBotao4 = 0;
    //        }
    //    }

    //    if(aliadosInvocados < 2)
    //    {
    //        podeInvocar = true;
    //        invocou = false;
    //    }

    //    if(player.GetComponent<Jogador_Status>().Mana <= 0)
    //    {
    //        podeInvocar = false;
    //    }
    //}

    //void chamaInvoca(int indexAliado)
    //{
    //    scriptDeInvocacao.SetAliado(indexAliado);
    //    scriptDeInvocacao.Invoca();
    //    aliadosInvocados++;
    //    if(aliadosInvocados > 1)
    //    {
    //        podeInvocar = false;
    //        aliadosInvocados = 2;
    //    }
        
    //}

    //public void AtivaAliado1()
    //{
    //    aliado1 = true;
    //}

    //public void AtivaAliado2()
    //{
    //    aliado2 = true;
    //}

    //public void AtivaAliado3()
    //{
    //    aliado3 = true;
    //}

    //public void AtivaAliado4()
    //{
    //    aliado4 = true;
    //}

    //IEnumerator Recarga1()
    //{
    //    yield return new WaitForSeconds(tempoDeRecarga1);
    //    aliadosInvocados--;
    //    AtivaAliado1();
    //    if(aliadosInvocados < 0)
    //    {
    //        aliadosInvocados = 0;
    //    }
    //}

    //IEnumerator Recarga2()
    //{
    //    yield return new WaitForSeconds(tempoDeRecarga2);
    //    aliadosInvocados--;
    //    AtivaAliado2();
    //    if(aliadosInvocados < 0)
    //    {
    //        aliadosInvocados = 0;
    //    }
    //}
    //IEnumerator Recarga3()
    //{
    //    yield return new WaitForSeconds(tempoDeRecarga3);
    //    aliadosInvocados--;
    //    AtivaAliado3();
    //    if(aliadosInvocados < 0)
    //    {
    //        aliadosInvocados = 0;
    //    }
    //}
    //IEnumerator Recarga4()
    //{
    //    yield return new WaitForSeconds(tempoDeRecarga4);
    //    aliadosInvocados--;
    //    AtivaAliado4();
    //    if(aliadosInvocados < 0)
    //    {
    //        aliadosInvocados = 0;
    //    }
    //}
}
