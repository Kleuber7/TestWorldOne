using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManagerAttack : MonoBehaviour
{
    public List<ParticleSystem> particlesAttack;


    public void PlayParticleAttack()
    {
        foreach (ParticleSystem particles in particlesAttack)
        {
            particles.Play();
        }
    }
}
