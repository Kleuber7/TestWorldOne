using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMInvocacoes : MonoBehaviour
{
    public Animator InvocacaoAnima;


    public void Atacar()
    {
        InvocacaoAnima.SetBool("Atacar", true);
        InvocacaoAnima.SetBool("Iddle", false);
        InvocacaoAnima.SetBool("Invocado", false);
    }

    public void Invocado()
    {
        //quando acaba de ser invocado.
        InvocacaoAnima.SetBool("Invocado", true);
    }
    
    public void ParadoAtaque()
    {
        InvocacaoAnima.SetBool("Atacar", false);
        InvocacaoAnima.SetBool("Iddle", true);
        InvocacaoAnima.SetBool("Invocado", false);
    }

    public void ParadoHeal()
    {
        InvocacaoAnima.SetBool("Healing", false);
        InvocacaoAnima.SetBool("Iddle", true);
        InvocacaoAnima.SetBool("Invocado", false);
    }

    public void Healing()
    {
        
        InvocacaoAnima.SetBool("Iddle", false);
        InvocacaoAnima.SetBool("Invocado", false);
        InvocacaoAnima.SetBool("Healing", true);
        
    }

    public void Morrer()
    {
        InvocacaoAnima.SetBool("Atacar", false);
        InvocacaoAnima.SetBool("Healing", false);
        InvocacaoAnima.SetBool("Iddle", false);
        InvocacaoAnima.SetBool("Invocado", false);
        InvocacaoAnima.SetBool("Morrer", true);
    }

}
