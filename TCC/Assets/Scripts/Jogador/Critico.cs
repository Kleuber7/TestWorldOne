using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critico : MonoBehaviour
{
    public float critChance = 0.0f;
    private DanoAtaqueBasico dano;
    public float danoReal = 0;
    public bool critou;
    public FSMJogador jogadorAnima;


    private void Start()
    {
        danoReal = GetComponent<DanoAtaqueBasico>().dano;
        dano = GetComponent<DanoAtaqueBasico>();
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
            Debug.Log("Critou");
            dano.dano *= 1.5f;
            critou = true;
            jogadorAnima.ChangeAnimationState(jogadorAnima.Critico());

        }
        else
        {
            critou = false;
            dano.dano = danoReal;
        }
    }
}
