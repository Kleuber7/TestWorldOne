using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravidade : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] public bool estaNoChao;
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
            AceleracaoDaGravidade();
        }
    }

    public void AceleracaoDaGravidade()
    {
        velocidadeDaGravidade.y += gravidade * Time.deltaTime;
        player.GetComponent<CharacterController>().Move(velocidadeDaGravidade * Time.deltaTime);
    }
}
