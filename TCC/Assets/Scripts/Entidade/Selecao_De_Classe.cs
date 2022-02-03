using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selecao_De_Classe : MonoBehaviour
{
    public GameObject jogador;
    public Jogador_Status Status_Jogador;
    public GameObject entityPanel;

    //public GameObject Painel_Classe_Magica;
    //public ED_AtivarPainel_Skil Ativar_HUD_Skil;
    //public GameObject   Necromante_Invoker,
    //                    Metamorfo_Lunari;

    void Start()
    {  
        jogador = GameObject.FindGameObjectWithTag("Player");
        Status_Jogador = jogador.GetComponent<Jogador_Status>();
        entityPanel.SetActive(false);

        //  Excluir
        //Necromante_Invoker = GameObject.Find("Necromante/Invoker");
        //Metamorfo_Lunari = GameObject.Find("Metamorfo/Lunari");
        //Painel_De_Classes = GameObject.Find("Painel_De_Classe");
        //Necromante_Invoker.SetActive(false);
        //Metamorfo_Lunari.SetActive(false);
    }

    public void OnTriggerStay(Collider Dentro)
    {
        if(Dentro  && Input.GetKeyDown(KeyCode.Space))
        {
            if(Dentro.gameObject.tag == "Player")
            {
                entityPanel.SetActive(true);
            }
        }
       
        
        //if(Dentro && Status_Jogador.Classe_Escolhida==true)
        //{
        //    if(Input.GetKeyDown(KeyCode.Q) && Status_Jogador.Classe_Magica==true)
        //    {
        //        Necromante_Invoker.GetComponent<Classe_Magica>().Trocar_Classe();
        //    }else
        //    {
        //        Metamorfo_Lunari.GetComponent<Classe_Fisica>().Trocar_Classe();
        //    }
        //}
    }

    #region Excluir Futuramente
    //private void OnTriggerEnter ( Collider Entrei)
    //{
    //    if(Entrei && Status_Jogador.Classe_Escolhida == true)
    //    {
    //        Necromante_Invoker.GetComponent<Classe_Magica>().Atributos_Da_Classe.mecanica.pode_trocar_classe=1;
    //        Metamorfo_Lunari.GetComponent<Classe_Fisica>().atributos.mecanica.pode_trocar_classe=1;
    //    }
    //}
    //void OnTriggerExit (Collider Saindo)
    //{
    //    if(Saindo)
    //    {
    //        Necromante_Invoker.GetComponent<Classe_Magica>().Atributos_Da_Classe.mecanica.pode_trocar_classe = 0;
    //        Metamorfo_Lunari.GetComponent<Classe_Fisica>().atributos.mecanica.pode_trocar_classe = 0;
    //    }
    //}
    //public void Ativar_Magico()
    //{
    //    Necromante_Invoker.SetActive(true);
    //    Status_Jogador.Classe_Magica=true;
    //    Painel_Classe_Magica.SetActive(true);
    //    Painel_De_Classes.SetActive(false);
    //    Ativar_HUD_Skil.Ativar_Painel();
    //}
    //public void Ativar_fisico()
    //{
    //    Status_Jogador.Classe_Escolhida=true;
    //    Metamorfo_Lunari.SetActive(true);
    //    Status_Jogador.Classe_Fisica=true;
    //    Painel_De_Classes.SetActive(false);
    //    Ativar_HUD_Skil.Ativar_Painel();
    //}
    #endregion

}
