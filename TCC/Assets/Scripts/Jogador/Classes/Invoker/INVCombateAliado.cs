using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INVCombateAliado : INVAliado
{
    [SerializeField] public float dano;
    [SerializeField] public float velocidadeDeAtaque;
    [SerializeField] public float alcanceDoAtaque;
    [SerializeField] public bool proximoSuficiente = false;
    [SerializeField] public bool podeAtacar = true;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(TempoDeVida()); 

        podeAtacar = true;     
    }

    private void Update() 
    {
        if(alvo != null && alvo != player)
        {
            if(Vector3.Distance(transform.position, alvo.transform.position) < alcanceDoAtaque)
            {
                proximoSuficiente = true;
            }
            else
            {
                proximoSuficiente = false;
            }

            if(proximoSuficiente)
            {
                if(podeAtacar && !stunado)
                {
                    StartCoroutine(IntervaloAtaque());
                }
            }
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Inimigo")
        {
            alvo = other.gameObject;
        }
    }

    public void Ataque()
    {
        alvo.GetComponent<INIStatus>().vida -= dano;
        
    }

    public IEnumerator IntervaloAtaque()
    {
        podeAtacar = false;
        yield return new WaitForSeconds(1/velocidadeDeAtaque);
        
        Ataque();
        podeAtacar = true;
    }

    public bool GetPodeAtacar()
    {
        return podeAtacar;
    }

    public void SetPodeAtacar(bool valor)
    {
        podeAtacar = valor;
    }
}
