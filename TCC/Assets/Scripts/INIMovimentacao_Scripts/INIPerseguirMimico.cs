using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INIPerseguirMimico : INIPerseguir
{
    [SerializeField] private Transform mimico;
    private bool investindo = false;
    private bool podeInvestir = false;
    [SerializeField] private float tempoRecargaInvestida;
    [SerializeField] private float contador;
    [SerializeField] private float tempoPreparo;
    [SerializeField] private float forcaInvestida;
    [SerializeField] private Transform alvo;

    private void Update() 
    {
        if(alvo != null)
        {
            if(podeInvestir)
            {
                podeInvestir = false;

                if(!investindo)
                {
                    StartCoroutine(Investida());
                }
            }
            else
            {
                contador -= 1 * Time.deltaTime;

                if(contador <= 0)
                {
                    podeInvestir = true;
                    contador = tempoRecargaInvestida;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            alvo = other.gameObject.transform;
        }
    }

    IEnumerator Investida()
    {
        investindo = true;
        yield return new WaitForSeconds(tempoPreparo);
        transform.Translate((alvo.position - transform.position) * forcaInvestida, Space.World);
        investindo = false;
    }
}
