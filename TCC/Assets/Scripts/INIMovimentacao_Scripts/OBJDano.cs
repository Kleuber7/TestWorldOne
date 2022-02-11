using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJDano : MonoBehaviour
{
    [SerializeField] private float dano, danoReal;
    [SerializeField] private string tagColisor;
    private Critico critico;
    [SerializeField] private INIStatus status;

    private void Start()
    {
        danoReal = dano;
        critico = GetComponent<Critico>();
    }

    public void NoDamage()
    {
        dano = 0;
    }

    public void TakeDamage()
    {
        dano = danoReal;
    }

    private void OnTriggerEnter(Collider other) 
    {
        //if(other.gameObject.tag == tagColisor && tagColisor == "Inimigo")
        //{
        //    if(critico != null)
        //    {
        //        critico.DoAttack();
        //    }
        //    other.GetComponent<INIStatus>().TomarDano(dano);
        //}

        if(other.gameObject.tag == tagColisor && tagColisor == "Player" && !status.GetStunado())
        {
            if(critico != null)
            {
                critico.DoAttack();
            }
           
            other.GetComponent<Jogador_Status>().TomarDano(dano);
        }
        
        //if (other.gameObject.tag == tagColisor && tagColisor == "Boboneco")
        //{
        //    if(critico != null)
        //    {
        //        critico.DoAttack();
        //    }
        //    other.GetComponent<StatusBoboneco>().TomarDano(dano);
        //}
    }
}
