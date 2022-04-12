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
        
        if(other.gameObject.tag == tagColisor && tagColisor == "Player" && !status.GetStunado() && !Jogador_Status.morreu)
        {
            if(critico != null)
            {
                critico.DoAttack();
            }

            other.GetComponent<FSMJogador>().ChangeAnimationState(other.GetComponent<FSMJogador>().TomarDano());
            other.GetComponent<AtaqueBasico>().ManageDamage();
            other.GetComponent<ParticleManagerDamageInPlayer>().PlayParticleEffect();
            other.GetComponent<Jogador_Status>().TomarDano(dano);
        }
        
    }
}
