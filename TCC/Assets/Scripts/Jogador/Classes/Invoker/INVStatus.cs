using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INVStatus : BASEStatus
{
    void Update()
    {
        if(vida <= 0)
        {
            StartCoroutine(Morte());
            //Morrer();
        }
    }


    IEnumerator Morte()
    {
        GetComponent<FSMInvocacoes>().Morrer();
        yield return new WaitForSeconds(1.5f);
        Morrer();
    }
}
