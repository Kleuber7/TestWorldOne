using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INIPontos : MonoBehaviour
{
    public Transform[] GetPontos()
    {
        Transform[] pontos = new Transform[this.transform.childCount];

        for(int i = 0; i < this.transform.childCount; i++)
        {
            pontos[i] = this.transform.GetChild(i);
        }

        return pontos;
    }
}
