using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Permitir_Troca_Classe : MonoBehaviour
{
    private GameObject jogador;
    void Start()
    {
        jogador = GameObject.Find("Jogador");
    }
    public void OnTriggerEnter  ( Collider entrou)
    {
        if(entrou==true)
        {
            jogador.GetComponent<Classe_Magica>().Atributos_Da_Classe.mecanica.pode_trocar_classe=1;
        }
    }
    void OnTriggerExit(Collider Saiu)
    {
        if(Saiu==true)
        {
            jogador.GetComponent<Classe_Magica>().Atributos_Da_Classe.mecanica.pode_trocar_classe=0;
        }
    }
}