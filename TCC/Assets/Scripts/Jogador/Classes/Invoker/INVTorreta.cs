using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INVTorreta : INVCombateAliado
{
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(MorteAim());

        podeAtacar = true;   
    }

    public IEnumerator MorteAim()
    {

        yield return new WaitForSeconds(tempoDeVida - 0.7f);
        GetComponent<FSMInvocacoes>().Morrer();
        StartCoroutine(TempoDeVida());

    }

    private void Update()
    {
        if(alvo != null)
        {
            if(Vector3.Distance(transform.position, alvo.transform.position) < alcanceDoAtaque)
            {
                proximoSuficiente = true;
            }
            else
            {
                proximoSuficiente = false;
                GetComponent<FSMInvocacoes>().ParadoAtaque();
            }

            if(proximoSuficiente)
            {
                if(podeAtacar && !stunado)
                {
                    GetComponent<FSMInvocacoes>().Atacar();
                    StartCoroutine(IntervaloAtaque());
                }
            }
        }
        else
        {
            GetComponent<FSMInvocacoes>().ParadoAtaque();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Inimigo")
        {
            alvo = other.gameObject;
        }
    }
}
