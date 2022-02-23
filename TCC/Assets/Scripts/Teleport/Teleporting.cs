using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Teleporting : MonoBehaviour
{

    public static bool teleportando = false;

    public static bool podeExcluirP = false;

    public GameObject TP1;

    public static bool cima = false;

    [SerializeField] private GameObject passLevel;
    private string nameRoom;
    private bool canPass = false;

    private void Start()
    {
        StartCoroutine(Disable());
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(0.1f);
        passLevel.SetActive(false);
        canPass = false;
    }
    private void Update()
    {
        if (teleportando)
        {
            teleportando = false;
        }

        if (canPass)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Spawner();
                passLevel.SetActive(false);
                canPass = false;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nameRoom = gameObject.name;
            passLevel.SetActive(true);
            canPass = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            passLevel.SetActive(false);
            canPass = false;
        }
    }


    IEnumerator EsperarSpawner()
    {
        yield return new WaitForSeconds(0.1f);
        cima = false;
    }

    public void Spawner()
    {
        INIStatus.danoUp += 0.5f;
        INIStatus.vidaUp += 10;

        teleportando = true;

        if (nameRoom == "Outono")
        {
            cima = true;
            RoomSpawner.outono = true;
            RoomSpawner.verao = false;
            RoomSpawner.primavera = false;
            RoomSpawner.inverno = false;
            StartCoroutine(EsperarSpawner());

        }
        else if (nameRoom == "Verao")
        {
            cima = true;
            RoomSpawner.outono = false;
            RoomSpawner.verao = true;
            RoomSpawner.primavera = false;
            RoomSpawner.inverno = false;

            StartCoroutine(EsperarSpawner());
        }
        else if (nameRoom == "Primavera")
        {
            cima = true;
            RoomSpawner.outono = false;
            RoomSpawner.verao = false;
            RoomSpawner.primavera = true;
            RoomSpawner.inverno = false;

            StartCoroutine(EsperarSpawner());
        }
        else if (nameRoom == "Inverno")
        {
            cima = true;
            RoomSpawner.outono = false;
            RoomSpawner.verao = false;
            RoomSpawner.primavera = false;
            RoomSpawner.inverno = true;

            StartCoroutine(EsperarSpawner());
        }
    }

    public void TimeScale()
    {
        Time.timeScale = 1;
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
