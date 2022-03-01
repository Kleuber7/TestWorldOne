using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{
   
    //private int sorteio;
    //private Jogador_Status status;
    //private InformacoesHUDJogador barras;

    //private void Start()
    //{
    //    status = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador_Status>();
    //    barras = GameObject.FindGameObjectWithTag("InfoJogador").GetComponent<InformacoesHUDJogador>();
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {

    //            SorteioAtributos();
    //            this.gameObject.GetComponent<Bau>().enabled = false;
    //            this.gameObject.GetComponent<BoxCollider>().enabled = false;

    //        }
    //    }

    //}


    //public void SorteioAtributos()
    //{
    //    sorteio = Random.Range(1, 5);

    //    if(sorteio == 1)
    //    {
            
    //        status.Vida += 30f;
    //        StartCoroutine(Vida());
    //        barras.SetHealth(status.Vida);
    //    }
    //    else if(sorteio == 2)
    //    {
    //        status.Velocidade += 10;
    //        StartCoroutine(Velocidade());
    //    }
    //    else if (sorteio == 3)
    //    {
    //        status.Mana += 30;
    //        StartCoroutine(Mana());
    //        barras.SetMana(status.Mana);
    //    }
    //    else if (sorteio == 4)
    //    {
    //        GameManager.gameManager.dinheiroJogador += 50;
    //        StartCoroutine(Dinheiro());
    //        barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
    //    }


    //}

  
    //IEnumerator Vida()
    //{
    //    status.vidaMaxS.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(1.5f);
    //    status.vidaMaxS.gameObject.SetActive(false);
    //}
    //IEnumerator Mana()
    //{
    //    status.manaMaxS.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(1.5f);
    //    status.manaMaxS.gameObject.SetActive(false);
    //}
    //IEnumerator Velocidade()
    //{
    //    status.velocidadeMaxS.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(1.5f);
    //    status.velocidadeMaxS.gameObject.SetActive(false);
    //}
    //IEnumerator Dinheiro()
    //{
    //    status.dinheiroS.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(1.5f);
    //    status.dinheiroS.gameObject.SetActive(false);
    //}

}
