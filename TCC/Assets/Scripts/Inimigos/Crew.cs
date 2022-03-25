using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour
{
    [SerializeField] public List<INIPerseguir> crews;
    public bool checkCrew;

    public void CallCrew(Transform target)
    {
        foreach (INIPerseguir crew in crews)
        {
            crew.alvo = target;
            crew.Perseguir();
            crew.inCrew = true;
            checkCrew = true;
        }
    }

    public void CheckCrew()
    {
        foreach (INIPerseguir crew in crews)
        {
            if (crew.inCrew)
            {
                if (Vector3.Distance(crew.transform.position, crew.alvo.position) < crew.areaVisao)
                {
                    checkCrew = true;
                    break;
                }
                else
                {
                    checkCrew = false;
                }
            }
        }

        if (!checkCrew)
        {
            foreach (INIPerseguir crew in crews)
            {
                crew.NaoPerseguir();
                crew.inCrew = false;
            }
        }

    }
}
