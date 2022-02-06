using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsquivaOfensiva : MonoBehaviour
{
    public static float esquivarChance = 2.0f;
    public static bool esquivar = false;


    public static void Esquivou()
    {
        
        float randValue = Random.Range(1, 6);
        if (esquivarChance > randValue)
        {
            Jogador_Status.podeDarDano = false;
            Debug.Log("Esquivou");
        }
        else if (esquivarChance < randValue)
        {
            Debug.Log("Não esquivou");
            Jogador_Status.podeDarDano = true;
        }
    }
}
