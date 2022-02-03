using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionaCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] float sensibilidade;
    [SerializeField] Vector3 direcao;
    private bool cameraSetada = false;

    private void Update() 
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            if(!cameraSetada)
            {
                SetCamera();
            }            
            Vector3 NovaPosicao = player.position + direcao;
            transform.position = Vector3.Slerp(transform.position,NovaPosicao,sensibilidade);
        }
    }

    public void SetCamera()
    {
        direcao = transform.position - player.position;
        cameraSetada = true;
    }
}
