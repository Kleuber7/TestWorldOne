using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public Transform teleporteAlvo;
    public GameObject player;

    public static bool teleportando = false;

    public static bool podeExcluirP = false;

    public GameObject spawnCima, TP1;  /*, TP2*/ /*spawndireita,*/

    public static bool AtivaGravidade = false;

    public static bool cima = false; // direita = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        


    }

    private void Update()
    {
        if(teleportando)
        {
            teleportando = false;
        }

        
    }

    IEnumerator EsperarSpawner()
    {
        yield return new WaitForSeconds(0.1f);
        cima = false;
        //direita = false;
        
    }

    

    void OnTriggerEnter(Collider other)
    {
        INIStatus.danoUp += 0.5f;
        INIStatus.vidaUp += 10;
        
        if (other.gameObject.tag == "Player")
        {
            
            teleportando = true;

            GameManager.gameManager.GetPlayer().GetComponent<Gravidade>().enabled = false;
            AtivaGravidade = false;
            player.transform.position = teleporteAlvo.transform.position;


            if (gameObject.name == "Outono")
            {
                cima = true;
                //direita = true;
                RoomSpawner.outono = true;
                RoomSpawner.verao = false;
                RoomSpawner.primavera = false;
                RoomSpawner.inverno = false;

                StartCoroutine(EsperarSpawner());
                AtivaGravidade = true;
                Destroy(spawnCima);
            }
            else if (gameObject.name == "Verao")
            {
                cima = true;
                //direita = true;
                RoomSpawner.outono = false;
                RoomSpawner.verao = true;
                RoomSpawner.primavera = false;
                RoomSpawner.inverno = false;

                StartCoroutine(EsperarSpawner());
                AtivaGravidade = true;
                Destroy(spawnCima);
            }
            else if (gameObject.name == "Primavera")
            {
                cima = true;
               // direita = true;
                RoomSpawner.outono = false;
                RoomSpawner.verao = false;
                RoomSpawner.primavera = true;
                RoomSpawner.inverno = false;

                StartCoroutine(EsperarSpawner());
                AtivaGravidade = true;
                Destroy(spawnCima);
            }
            else if (gameObject.name == "Inverno")
            {
                cima = true;
               // direita = true;
                RoomSpawner.outono = false;
                RoomSpawner.verao = false;
                RoomSpawner.primavera = false;
                RoomSpawner.inverno = true;

                StartCoroutine(EsperarSpawner());
                AtivaGravidade = true;
                Destroy(spawnCima);
            }


            #region OLD DG SCRIPT
            //if (CompareTag("SpawnDireita") && gameObject.name == "Outono")
            //{
            //    cima = false;
            //    direita = true;
            //    RoomSpawner.outono = true;
            //    RoomSpawner.verao = false;
            //    RoomSpawner.primavera = false;
            //    RoomSpawner.inverno = false;

            //    StartCoroutine(EsperarSpawner());
            //    AtivaGravidade = true;
            //    Destroy(spawnCima);
            //}
            //else if (CompareTag("SpawnCima") && gameObject.name == "Outono")
            //{
            //    cima = true;
            //    direita = false;
            //    RoomSpawner.outono = true;
            //    RoomSpawner.verao = false;
            //    RoomSpawner.primavera = false;
            //    RoomSpawner.inverno = false;

            //    StartCoroutine(EsperarSpawner());
            //    AtivaGravidade = true;
            //    Destroy(spawndireita);

            //    //Destroy(TP2, 2f);
            //    //Destroy(TP1, 2f);
            //}

            //if (CompareTag("SpawnDireita") && gameObject.name == "Verao")
            //{
            //    cima = false;
            //    direita = true;
            //    RoomSpawner.outono = false;
            //    RoomSpawner.verao = true;
            //    RoomSpawner.primavera = false;
            //    RoomSpawner.inverno = false;

            //    StartCoroutine(EsperarSpawner());
            //    AtivaGravidade = true;
            //    Destroy(spawnCima);
            //}
            //else if (CompareTag("SpawnCima") && gameObject.name == "Verao")
            //{
            //    cima = true;
            //    direita = false;
            //    RoomSpawner.outono = false;
            //    RoomSpawner.verao = true;
            //    RoomSpawner.primavera = false;
            //    RoomSpawner.inverno = false;

            //    StartCoroutine(EsperarSpawner());
            //    AtivaGravidade = true;
            //    Destroy(spawndireita);

            //    //Destroy(TP2, 2f);
            //    //Destroy(TP1, 2f);
            //}

            //if (CompareTag("SpawnDireita") && gameObject.name == "Primavera")
            //{
            //    cima = false;
            //    direita = true;
            //    RoomSpawner.outono = false;
            //    RoomSpawner.verao = false;
            //    RoomSpawner.primavera = true;
            //    RoomSpawner.inverno = false;

            //    StartCoroutine(EsperarSpawner());
            //    AtivaGravidade = true;
            //    Destroy(spawnCima);
            //}
            //else if (CompareTag("SpawnCima") && gameObject.name == "Primavera")
            //{
            //    cima = true;
            //    direita = false;
            //    RoomSpawner.outono = false;
            //    RoomSpawner.verao = false;
            //    RoomSpawner.primavera = true;
            //    RoomSpawner.inverno = false;

            //    StartCoroutine(EsperarSpawner());
            //    AtivaGravidade = true;
            //    Destroy(spawndireita);

            //    //Destroy(TP2, 2f);
            //    //Destroy(TP1, 2f);
            //}

            //if (CompareTag("SpawnDireita") && gameObject.name == "Inverno")
            //{
            //    cima = false;
            //    direita = true;
            //    RoomSpawner.outono = false;
            //    RoomSpawner.verao = false;
            //    RoomSpawner.primavera = false;
            //    RoomSpawner.inverno = true;

            //    StartCoroutine(EsperarSpawner());
            //    AtivaGravidade = true;
            //    Destroy(spawnCima);
            //}
            //else if (CompareTag("SpawnCima") && gameObject.name == "Inverno")
            //{
            //    cima = true;
            //    direita = false;
            //    RoomSpawner.outono = false;
            //    RoomSpawner.verao = false;
            //    RoomSpawner.primavera = false;
            //    RoomSpawner.inverno = true;

            //    StartCoroutine(EsperarSpawner());
            //    AtivaGravidade = true;
            //    Destroy(spawndireita);

            //    //Destroy(TP2, 2f);
            //    //Destroy(TP1, 2f);
            //}
            #endregion
        }
    }
    
}
