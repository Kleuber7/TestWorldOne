using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runa_Reviver : MonoBehaviour
{
    public GameObject Nevoa_Reviver;
    public Jogador_Habilidades_Magica Posicao;

    public void Acionar_Nevoa()
    {
        Instantiate(Nevoa_Reviver,Posicao.Lancador.transform.position,Posicao.Lancador.transform.rotation);
    }
}