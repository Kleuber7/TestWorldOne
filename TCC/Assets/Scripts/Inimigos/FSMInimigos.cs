using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMInimigos : MonoBehaviour
{
    public Animator InimigoAnima;
    private string currentState;


    public void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play the animation
        InimigoAnima.CrossFade(newState, 0.2f);
        //InimigoAnima.Play(newState);

        //reassign the current state
        currentState = newState;
    }
    public void StopAnimationState(string newState)
    {
        InimigoAnima.Play(newState, -1, 0);
    }

    
    public void ResetAnimation()
    {
        InimigoAnima.enabled = false;
        InimigoAnima.enabled = true;
    }
    public string Patrulhando()
    {
        const string Enemy_Patrol = "Patrulhar";

        return Enemy_Patrol;

    }

    public string Perseguindo()
    {
        const string Enemy_Chase = "Perseguir";

        return Enemy_Chase;

    }

    public string Atacar()
    {
        const string Enemy_Atack = "Atacar";

        return Enemy_Atack;

    }

    public string TomarDano()
    {
        const string Enemy_TakeDamage = "TomarDano";

        return Enemy_TakeDamage;

    }

    public string Iddle()
    {
        const string Enemy_Iddle = "Iddle";

        return Enemy_Iddle;
    }

    public string Morte()
    {
        const string Enemy_Death = "Morrer";

        return Enemy_Death;

    }


    public IEnumerator TomarDanoDelay()
    {
        ChangeAnimationState(TomarDano());

        yield return new WaitForSeconds(0.5f);
    }
}
