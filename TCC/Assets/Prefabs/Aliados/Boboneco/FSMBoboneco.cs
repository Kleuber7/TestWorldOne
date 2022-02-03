using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMBoboneco : MonoBehaviour
{
    public Animator bobonecoAnima;

    public void TomarDano()
    {
        bobonecoAnima.SetBool("TomarDano", true);
    }

    public void NaoTomarDano()
    {
        bobonecoAnima.SetBool("TomarDano", false);
    }
}
