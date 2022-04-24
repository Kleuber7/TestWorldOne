using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMBoss : MonoBehaviour
{
    public Animator BOSSAnima;
    private string currentState;

    public void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play the animation
        BOSSAnima.CrossFade(newState, 0.2f);
        //BOSSAnima.Play(newState);

        //reassign the current state
        currentState = newState;
    }
    public void StopAnimationState(string newState)
    {
        BOSSAnima.Play(newState, -1, 0);
    }

    public void ResetAnimation()
    {
        BOSSAnima.enabled = false;
        BOSSAnima.enabled = true;
    }

    public string Iddle()
    {
        const string BOSS_Iddle = "Iddle";

        return BOSS_Iddle;
    }

    public string Atirando()
    {
        const string BOSS_Atirando = "Atirando";

        return BOSS_Atirando;
    }

    public string PreparandoDash()
    {
        const string BOSS_PDash = "PreparandoDash";

        return BOSS_PDash;
    }

    public string Dash()
    {
        const string BOSS_Dash = "Dash";

        return BOSS_Dash;
    }

    public string PreparandoPulo()
    {
        const string BOSS_PPulo = "PreparandoPulo";

        return BOSS_PPulo;
    }

    public string Pulo()
    {
        const string BOSS_Pulo = "Pulo";

        return BOSS_Pulo;
    }

    public string Queda()
    {
        const string BOSS_Queda = "Queda";

        return BOSS_Queda;
    }

    public string Morte()
    {
        const string BOSS_Morte = "Morte";

        return BOSS_Morte;
    }
}
