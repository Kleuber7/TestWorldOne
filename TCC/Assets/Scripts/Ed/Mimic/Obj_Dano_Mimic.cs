using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Dano_Mimic : MonoBehaviour
{
    [SerializeField] private float dano, danoReal;
    [SerializeField] private string tagColisor;
    private Critico critico;
    [SerializeField] private INIStatus status;

    public bool Pode_Dar_Dano;

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
            if(Pode_Dar_Dano)
            {
                if(critico != null)
                {
                    critico.DoAttack();
                }

                if (!PLASkills.castingSkill)
                    other.GetComponent<FSMJogador>().ChangeAnimationState(other.GetComponent<FSMJogador>().TomarDano());
                other.GetComponent<AtaqueBasico>().ManageDamage();
                other.GetComponent<ParticleManagerDamageInPlayer>().PlayParticleEffect();
                other.GetComponent<Jogador_Status>().TomarDano(dano);
            }
        }
        
    }
}
