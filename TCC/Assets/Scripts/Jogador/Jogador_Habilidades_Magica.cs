using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogador_Habilidades_Magica : MonoBehaviour
{
    public Jogador_Status Atributos;
    public GameObject Lancador;
    public List<GameObject> Lista_Invocacao;
    public GameObject Alvo;
    void Start()
    {
        Lancador = GameObject.Find("Lancador");
    }
}