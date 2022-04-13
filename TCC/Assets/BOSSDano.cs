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
        if(other.gameObject.tag == tagColisor && tagColisor == "Player" && !Jogador_Status.morreu)
        {
            if(podeDarDano)
            {
                other.GetComponent<FSMJogador>().ChangeAnimationState(other.GetComponent<FSMJogador>().TomarDano());
                other.GetComponent<AtaqueBasico>().ManageDamage();
                other.GetComponent<Jogador_Status>().TomarDano(dano);
            }
        }
    }
}
