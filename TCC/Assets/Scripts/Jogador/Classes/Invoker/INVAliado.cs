using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INVAliado : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject alvo;
    [SerializeField] public float tempoDeVida;
    [SerializeField] public bool stunado = false;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(TempoDeVida());      
    }

    public void ExpiraInvocacao()
    {
        Destroy(this.gameObject);
    }

    
    public IEnumerator TempoDeVida()
    {
        
        yield return new WaitForSeconds(tempoDeVida);

        ExpiraInvocacao();
        
    }

    public void Stunado()
    {
        stunado = true;
    }

    public virtual void SetAlvo()
    {
        alvo = GameObject.FindGameObjectWithTag("Inimigo");
    }
}
