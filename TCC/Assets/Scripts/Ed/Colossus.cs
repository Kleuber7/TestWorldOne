using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colossus : MonoBehaviour
{
    public float Vida;
    public GameObject Alvo;
    public Jogador_Habilidades_Magica Jogador;
    // Start is called before the first frame update
    void Start()
    {
        Jogador.Lista_Invocacao.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Perseguir();
    }

    public void Perseguir()
    {
        // Segui Alvo
    }
}