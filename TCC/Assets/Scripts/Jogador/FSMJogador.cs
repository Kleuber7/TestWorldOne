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
       
    }


    //public string SetHorizontal()
    //{
    //    const string player_Horizontal = "Horizontal";

    //    return player_Horizontal;
    //    jogadorAnima.SetFloat("Horizontal", valor);
    //}

    public string Testaculos()
    {
        const string player_Testacles = "Testaculos";

        return player_Testacles;

    }
    public string Tiro()
    {
        const string player_Shoot = "Tiro";

        return player_Shoot;

    }
    public string Critico()
    {
        const string player_Critical = "Critico";

        return player_Critical;
    }

    public string Bater1()
    {
        const string player_PunchOne = "Bater 1";

        return player_PunchOne;
    }

    public string Bater2()
    {
        const string player_PunchTwo = "Bater 2";

        return player_PunchTwo;
    }

    public string Bater3()
    {
        const string player_PunchThree = "Bater 3";
        return player_PunchThree;
    }
    public string Bater4()
    {
        const string player_PunchThree = "Bater 4";
        return player_PunchThree;
    }
    public string Bater5()
    {
        const string player_PunchThree = "Bater 5";
        return player_PunchThree;
    }
    public string Bater6()
    {
        const string player_PunchThree = "Bater 6";
        return player_PunchThree;
    }
}
