using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManagerDashTP : MonoBehaviour
{
    public List<ParticleSystem> particlesDash;
   

    public void PlayParticleDash()
    {
        foreach(ParticleSystem particles in particlesDash)
        {
            particles.Play();
        }

    }
}
