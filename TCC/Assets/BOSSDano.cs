using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSDano : MonoBehaviour
{
    [SerializeField] private float dano;
    [SerializeField] private string tagColisor;
    public bool podeDarDano;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == tagColisor && tagColisor == "Player")
        {
            if(podeDarDano)
            {
                other.GetComponent<Jogador_Status>().TomarDano(dano);
            }
        }
    }
}
