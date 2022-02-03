using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBoboneco : BASEStatus
{
    public override void TomarDano(float dano)
    {
        StartCoroutine(TomarDanoAnim());
        vida -= dano;

        StopAllCoroutines();
        StartCoroutine(ResetaVida());
    }

    IEnumerator ResetaVida()
    {
        yield return new WaitForSeconds(3);
        vida = vidaMax;
    }

    IEnumerator TomarDanoAnim()
    {
        GetComponent<FSMBoboneco>().TomarDano();
        yield return new WaitForSeconds(0.3f);
        GetComponent<FSMBoboneco>().NaoTomarDano();
    }

    public override void Morrer()
    {
        return;
    }
}
