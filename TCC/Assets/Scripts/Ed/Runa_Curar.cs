using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runa_Curar : MonoBehaviour
{
    public Runa Habilidade;
    public Jogador_Status Jogador;
    [Range(0,25)]
    public float Cura;
    public void Curar()
    {
        if(Habilidade.Lista_Invocacao.Count>0 && Jogador.Mana>= 20)
        {
            for (int i = 0; i <=Habilidade.Lista_Invocacao.Count; i++)
            {
                Destroy(Habilidade.Lista_Invocacao[i]);
                Jogador.Vida+=Cura;
            }
        }
    }
}
