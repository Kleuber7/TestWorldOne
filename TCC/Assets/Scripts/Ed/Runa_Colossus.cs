using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runa_Colossus : MonoBehaviour
{
    public Runa Habilidade;
    public Jogador_Status Jogador;
    public GameObject Colossus;
    public Jogador_Habilidades_Magica Posicao;

    public void Invocar_Colossus()
    {
        if(Habilidade.Lista_Invocacao.Count>=3 && Jogador.Mana>= 20)
        {
            for (int i = 0; i <=3; i++)
            {
                Destroy(Habilidade.Lista_Invocacao[i]);
            }
            Instantiate(Colossus,Posicao.Lancador.transform);
        }
    }
}