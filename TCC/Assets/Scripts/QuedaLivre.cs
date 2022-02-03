using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuedaLivre : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Inimigo")
        {
            other.gameObject.GetComponent<INIStatus>().Morrer();
        }
        else if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Jogador_Status>().Morrer();
        }
    }
}
