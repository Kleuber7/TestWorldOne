using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontedeVida : MonoBehaviour
{
    float curaPorcentagem = 10;
    private Jogador_Status jogador;

    private void Start()
    {
        jogador = GetComponent<Jogador_Status>();
    }
    public void CurarP()
    {

        jogador.Vida += jogador.Ataque * curaPorcentagem / 100;

    }
}

