using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour
{
    [SerializeField] List<INIPerseguir> crews;
    

    public void CallCrew(Transform target)
    {
        foreach(INIPerseguir crew in crews)
        {
            crew.alvo = target;
            crew.Perseguir();
            crew.inCrew = true;
        }
    }
}
