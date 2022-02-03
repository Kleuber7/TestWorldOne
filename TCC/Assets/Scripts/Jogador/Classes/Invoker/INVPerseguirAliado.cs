using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INVPerseguirAliado : INVAliado
{
    [SerializeField] public float velocidade;
    [SerializeField] public float distanciaParar;
    [SerializeField] private Gravidade scriptDeGravidade;

    private void Update() 
    {
        if(alvo != null && alvo != player)
        {
            if(Vector3.Distance(transform.position, alvo.transform.position) >= distanciaParar && !stunado && scriptDeGravidade.estaNoChao)
            {
                Perseguir();
            }
        }
        else
        {
            alvo = player;
            if(Vector3.Distance(transform.position, alvo.transform.position) >= distanciaParar && !stunado && scriptDeGravidade.estaNoChao)
            {
                Perseguir();
            }
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Inimigo")
        {
            if(alvo == null || alvo == player)
            {
                alvo = other.gameObject;
            }
        }
    }

    public void Perseguir()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(alvo.transform.position.x, transform.position.y, alvo.transform.position.z), velocidade * Time.deltaTime);
    }
    public void NaoPerseguir()
    {
        velocidade = 0;
    }
}
