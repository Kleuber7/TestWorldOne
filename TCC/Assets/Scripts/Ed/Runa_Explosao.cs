using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runa_Explosao : MonoBehaviour
{
    public GameObject Esqueleto;
    public Jogador_Status Jogador;
    public Jogador_Habilidades_Magica Posicao;
    public GameObject Referencia;
    void Start()
    {
        Referencia = GameObject.Find("Necromante/Invoker");
    }
    public void Jogar_Esqueleto()
    {
        Instantiate(Esqueleto,Posicao.Lancador.transform);
        Esqueleto.GetComponent<Esqueleto>().Jogador = Referencia.GetComponent<Jogador_Habilidades_Magica>();;
    }
}