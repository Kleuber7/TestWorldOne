using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJDano : MonoBehaviour
{
    [SerializeField] public float dano;
    [SerializeField] private string tagColisor;
    private Critico critico;
    private List<Collider> colisores;

    private void Start()
    {
        critico = GetComponent<Critico>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == tagColisor && tagColisor == "Inimigo")
        {
            if(critico != null)
            {
                critico.DoAttack();
            }
            other.GetComponent<INIStatus>().TomarDano(dano);
        }

        if(other.gameObject.tag == tagColisor && tagColisor == "Player")
        {
            if(critico != null)
            {
                critico.DoAttack();
            }
            other.GetComponent<Jogador_Status>().TomarDano(dano);
        }
        
        if (other.gameObject.tag == tagColisor && tagColisor == "Boboneco")
        {
            if(critico != null)
            {
                critico.DoAttack();
            }
            other.GetComponent<StatusBoboneco>().TomarDano(dano);
        }
    }
}
