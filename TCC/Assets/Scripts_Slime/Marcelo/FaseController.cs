using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseController : MonoBehaviour
{
    public GameObject[] fases;
    public int faseAtual = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void TrocaFase()
    {
        for (int i = 0; i < fases.Length; i++)
        {
            if (i == faseAtual)
            {
                fases[i].gameObject.SetActive(true);
            }
            else
            {
                fases[i].gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
