using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMJogador : MonoBehaviour
{
    public Animator jogadorAnima;
    private string currentState;
    
    public void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play the animation
        if (newState == "Andar" || newState == "Parado")
            jogadorAnima.CrossFade(newState, 0.2f);

        else
            jogadorAnima.CrossFade(newState, 0);

        //reassign the current state
        currentState = newState;
    }
    public void StopAnimationState(string newState)
    {
        jogadorAnima.Play(newState, -1, 0);

    }

    public string Andar()
    {
        const string player_Walk = "Andar";

        return player_Walk;

    }

    public string Parado()
    {
        const string player_Iddle = "Parado";

        return player_Iddle;
        //jogadorAnima.SetBool("Andar", false);
        //jogadorAnima.SetBool("Parado", true);
    }

    public void Bater()
    {
        
        //jogadorAnima.SetBool("Bater 1", true);
    }

    public void NBater()
    {
        jogadorAnima.SetBool("Bater 1", false);
        jogadorAnima.SetBool("Bater 2", false);
        jogadorAnima.SetBool("Bater 3", false);
    }

    public string SetHorizontal()
    {
        const string player_Horizontal = "Horizontal";

        return player_Horizontal;
        // jogadorAnima.SetFloat("Horizontal", valor);
    }

    public string SetVertical()
    {
        const string player_Vertical = "Vertical";

        return player_Vertical;
        //jogadorAnima.SetFloat("Vertical", valor);
    }

    public string Critico()
    {
        const string player_Critical = "Critico";

        return player_Critical;
        //jogadorAnima.SetBool("Critico", valor);
    }

    public string Bater1()
    {
        const string player_PunchOne = "Bater 1";

        return player_PunchOne;
        //jogadorAnima.SetBool("Bater 1", valor);
    }

    public string Bater1Prox()
    {
        const string player_PunchOneProx = "Bater 1_5";

        return player_PunchOneProx;
        //jogadorAnima.SetBool("Bater 1", valor);
    }
    public string Bater2()
    {
        const string player_PunchTwo = "Bater 2";

        return player_PunchTwo;
        //jogadorAnima.SetBool("Bater 2", valor);
    }

    public string Bater3()
    {
        const string player_PunchThree = "Bater 3";
        return player_PunchThree;
        //jogadorAnima.SetBool("Bater 3", valor);
    }
}
