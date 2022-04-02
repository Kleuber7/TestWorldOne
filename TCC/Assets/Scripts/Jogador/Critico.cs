using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critico : MonoBehaviour
{
    public float critChance = 0.0f;
    public DanoAtaqueBasico dano;
    public float danoReal = 0;
    public bool critou;
    public FSMJogador jogadorAnima;
    public ScriptablePlayer status;


    private void Start()
    {
        danoReal = dano.dano;
    }

   

    //void CritChance(/*float critInc*/)
    //{
    //   // float randValue = Random.RandomRange();
    //    critChance = 2;


    //   // critChance += critInc;
    //    ////Never let the crit chance go out of range
    //    //if (critChance > 100.0f)
    //    //{
    //    //    critChance = 100.0f;
    //    //}
    //}

    public void DoAttack()
    {
        
        bool criticalHit = Random.Range(0, 100) < 15;
        if (criticalHit)
        {
            danoReal = dano.dano;
            dano.dano *= 1.5f;
            dano.dano += (status.attack / 100) * dano.dano;

            critou = true;
            jogadorAnima.ChangeAnimationState(jogadorAnima.Critico());

        }
        else
        {
            critou = false;
            danoReal = dano.dano;
            dano.dano += (status.attack / 100) * dano.dano;
        }
    }

    public void ResetAttack()
    {
        dano.dano = danoReal;
    }
}
