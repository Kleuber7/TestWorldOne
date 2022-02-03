using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoCamera : MonoBehaviour
{

    public GameObject Player;
    public Transform posicaoCamera;
    private Vector3 CameraAlvo;
    private bool cameraSetada = false;
    public float Suavizador;

    void Update()
    {
        // if(!cameraSetada)
        // {
        //     SetCamera();
        // }
        // Vector3 NovaPosicao = Player.transform.position + CameraAlvo;

        if(posicaoCamera == null)
        {
            posicaoCamera = GameObject.FindGameObjectWithTag("PosicaoCamera").transform;
        }
        else
        {
            transform.position = Vector3.Slerp(transform.position,posicaoCamera.position,Suavizador);
        }

        //transform.position = Vector3.Slerp(transform.position,NovaPosicao,Suavizador);
    }

    public void SetCamera()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        CameraAlvo = transform.position - Player.transform.position;
        cameraSetada = true;
    }
}
