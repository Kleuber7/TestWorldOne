using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INIMovimento : MonoBehaviour
{
    public Transform inimigo;
    [SerializeField] private bool estaNoChao;
    public static float gravidade = -20;
    private Vector3 velocidadeDaGravidade;
    [SerializeField] private LayerMask layerChao;
    [SerializeField] private float tamanhoDoCheck;
    [SerializeField] private Transform pontoDoCheck;
    
    private void Update() 
    {
        AplicaGravidade();
    }

    public void AplicaGravidade()
    {
        estaNoChao = Physics.CheckSphere(pontoDoCheck.position, tamanhoDoCheck, layerChao);

        if(estaNoChao)
        {
            velocidadeDaGravidade.y = -2f;
        }
        else
        {
            Gravidade();
        }
    }

    public void Gravidade()
    {
        velocidadeDaGravidade.y += gravidade * Time.deltaTime;
        inimigo.transform.Translate(velocidadeDaGravidade * Time.deltaTime, Space.World);
    }

    public IEnumerator Stunado(float tempoStun)
    {
        StopAllCoroutines();
        this.gameObject.GetComponent<INIStatus>().SetStunado(true);
        GetComponent<INIStatus>().NaoDarDano();
        yield return new WaitForSeconds(tempoStun);
        this.gameObject.GetComponent<INIStatus>().SetStunado(false);
        GetComponent<INIStatus>().DarDano();
    }
}
