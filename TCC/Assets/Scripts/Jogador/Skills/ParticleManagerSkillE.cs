using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManagerSkillE : MonoBehaviour
{
    public List<ParticleSystem> particlesEffect;


    public void PlayParticleEffect()
    {
        foreach (ParticleSystem particles in particlesEffect)
        {
            particles.Play();
        }
    }
}
