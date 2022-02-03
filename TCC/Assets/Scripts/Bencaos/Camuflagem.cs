using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camuflagem : MonoBehaviour
{
    public float ataqueReal, ataqueAumentado = 10, coolDown = 18;
    public Jogador_Status jogador;
    public bool camuflar = true;

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador_Status>();
        ataqueAumentado += jogador.Ataque_Maximo;
    }

    // Update is called once per frame
    void Update()
    {
        Camuflar();
    }

    void Camuflar()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ataqueReal = jogador.Ataque;
            if (camuflar)
                StartCoroutine(CamuflagemSecs());

            StartCoroutine(CoolDownCamuflagem());
        }
    }

    IEnumerator CoolDownCamuflagem()
    {
        camuflar = false;
        yield return new WaitForSeconds(coolDown);
        camuflar = true;
    }

    IEnumerator CamuflagemSecs()
    {
        jogador.Ataque += ataqueAumentado;
        Jogador_Status.Invisivel = true;
        
        yield return new WaitForSeconds(20f);

        Jogador_Status.Invisivel = false;
        jogador.Ataque += ataqueReal;
    }
}
