using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int abrirDirecao;
    // 1 > Direcao baixo
    // 2 > Direcao cima
    // 3 > Direcao esquerda
    // 4 > Direcao direita

    private RoomTemplates templates;
    private int aleatorio;
    public bool spawned = false;
    private Spawner objetoPai;
    private SpawnerBoss objetoPaiBoss;
    public int espacoLiberado = 1;

    public static bool verao, outono, primavera, inverno, boss;

    public void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        objetoPai = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        objetoPaiBoss = GameObject.FindGameObjectWithTag("SpawnerBoss").GetComponent<SpawnerBoss>();

        verao = false;
        outono = false;
        primavera = false;
        inverno = false;
    }



    private void Update()
    {
        if (Teleporting.cima == true && !boss)
        {
            if (Teleporting.podeExcluirP)
                return;

            WaitTime();
            spawned = false;
        }
        else if (Teleporting.cima == true && boss)
        {
            if (Teleporting.podeExcluirP)
                return;

            SpawnBoss();
            spawned = false;
        }

    }

    async void WaitTimeBoss()
    {
        await WaitTimeBossAsync();
    }
    async Task WaitTimeBossAsync()
    {
        await Task.Delay(100);
        SpawnBoss();
    }
    async void WaitTime()
    {
        await WaitTimeAsync();
    }
    async Task WaitTimeAsync()
    {
        await Task.Delay(100);
        SpawnCima();
    }

    void SpawnCima()
    {

        if (spawned == false)
        {
            if (verao)
            {
                aleatorio = Random.Range(0, templates.salasVerao.Length);
                Instantiate(templates.salasVerao[aleatorio], transform.position, templates.salasVerao[aleatorio].transform.rotation, objetoPai.transform);

                verao = false;
                Teleporting.podeExcluirP = true;
            }
            else if (outono)
            {
                aleatorio = Random.Range(0, templates.salasOutono.Length);
                Instantiate(templates.salasOutono[aleatorio], transform.position, templates.salasOutono[aleatorio].transform.rotation, objetoPai.transform);

                outono = false;
                Teleporting.podeExcluirP = true;

            }
            else if (primavera)
            {
                aleatorio = Random.Range(0, templates.salasPrimavera.Length);
                Instantiate(templates.salasPrimavera[aleatorio], transform.position, templates.salasPrimavera[aleatorio].transform.rotation, objetoPai.transform);

                primavera = false;
                Teleporting.podeExcluirP = true;

            }
            else if (inverno)
            {
                aleatorio = Random.Range(0, templates.salasInverno.Length);
                Instantiate(templates.salasInverno[aleatorio], transform.position, templates.salasInverno[aleatorio].transform.rotation, objetoPai.transform);

                inverno = false;
                Teleporting.podeExcluirP = true;

            }
            spawned = true;
        }

            templates.contadorSalas = templates.salas.Count;
    }

    void SpawnBoss()
    {
        if (spawned == false)
        {
            templates.salaBoss[0].gameObject.SetActive(true);
            boss = false;

            templates.contadorSalasBoss = templates.salasBoss.Count;

            spawned = true;

            Teleporting.podeExcluirP = true;
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{

    //    if (other.CompareTag("SpawnPoint"))
    //    {

    //        espacoLiberado = 0;


    //    }
    //    else
    //    {
    //        espacoLiberado = 1;
    //    }

    //    //if (espacoLiberado == 0)
    //    //{

    //    //    Destroy(other.gameObject);

    //    //}
    //}


    #region coments

    //if (templates.salas.Count < templates.numerosSalas)
    //{

    //    Invoke("SpawnCima", 1f);
    //}
    //else if (templates.salas.Count < templates.numerosSalas + 1)
    //{
    //    Invoke("SpawnBoss", 1f);

    //}

    //if (abrirDirecao == 1)
    //{
    //    verao = true;
    //    outono = false;
    //    inverno = false;
    //    primavera = false;
    //}


    //if (abrirDirecao == 2)
    //{
    //    verao = false;
    //    outono = true;
    //    inverno = false;
    //    primavera = false;
    //}


    //if (abrirDirecao == 1)
    //{
    //    // Precisa Spawnar a Porta baixo
    //    aleatorio = Random.Range(0, templates.salasBaixo.Length);
    //    Instantiate(templates.salasBaixo[aleatorio], transform.position, templates.salasBaixo[aleatorio].transform.rotation, objetoPai.transform);
    //    //objetoPai.spawner.transform.parent = templates.salasBaixo[aleatorio].transform;    

    //}
    //if (abrirDirecao == 2)
    //{
    // Precisa Spawnar a Porta cima
    //aleatorio = Random.Range(0, templates.salasCima.Length);
    //Instantiate(templates.salasCima[aleatorio], transform.position, templates.salasCima[aleatorio].transform.rotation, objetoPai.transform);
    //objetoPai.spawner.transform.parent = templates.salasBaixo[aleatorio].transform;
    // }
    //else if (abrirDirecao == 3)
    //{
    //    // Precisa Spawnar a Porta esquerda
    //    aleatorio = Random.Range(0, templates.salasEsquerda.Length);
    //    Instantiate(templates.salasEsquerda[aleatorio], transform.position, templates.salasEsquerda[aleatorio].transform.rotation, objetoPai.transform);
    //   // objetoPai.spawner.transform.parent = templates.salasBaixo[aleatorio].transform;
    //}
    //else if (abrirDirecao == 3)
    //{
    //    // Precisa Spawnar a Porta direita
    //    aleatorio = Random.Range(0, templates.salasDireita.Length);
    //    Instantiate(templates.salasDireita[aleatorio], transform.position, templates.salasDireita[aleatorio].transform.rotation, objetoPai.transform);
    //    //objetoPai.spawner.transform.parent = templates.salasBaixo[aleatorio].transform;
    //}


    //templates.index[templates.contadorSalas] = templates.contadorSalas
    // GameObject.FindGameObjectWithTag("sala").GetComponent<AddRoom>().index = templates.index[templates.contadorSalas];

    //while (templates.contadorSalas > templates.numerosSalas)
    //{

    //    //colocar no final do index
    //    Destroy(GetComponent<Transform>().GetChild(templates.contadorSalas - 1).gameObject);
    //    Debug.Log("to aq2");
    //    templates.contadorSalas--;
    //}

    //if (templates.numerosSalas - 1 == templates.salas.Count)
    //{
    //    Debug.Log("ToAq");
    //    Invoke("SpawnBoss", 0.2f);
    //}


    //if (Teleporting.cima == !false || Teleporting.direita == !false)
    //{

    //}


    //while (templates.contadorSalasBoss > 1)
    //{
    //   // Destroy(objetoPai.spawner.transform.GetChild(templates.contadorSalasBoss));
    //    //templates.salas.RemoveAt(templates.salas.Count - 1);
    //    Debug.Log("to aq");
    //    templates.contadorSalasBoss--;
    //}

    //void SpawnDireita()
    //{

    //    if (spawned == false)
    //    {

    //            if (abrirDirecao == 3)
    //            {
    //                // Precisa Spawnar a Porta direita
    //                aleatorio = Random.Range(0, templates.salasDireita.Length);
    //                Instantiate(templates.salasDireita[aleatorio], transform.position, templates.salasDireita[aleatorio].transform.rotation, objetoPai.transform);
    //                //objetoPai.spawner.transform.parent = templates.salasBaixo[aleatorio].transform;
    //            }
    //            spawned = true;

    //    }

    //    if (GameObject.FindGameObjectWithTag("sala"))
    //    {
    //        templates.contadorSalas = objetoPai.transform.childCount;

    //    }

    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("SpawnPoint"))
    //    {
    //        if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
    //        {
    //            //sumona paredes bloqueando as aberturas
    //            Instantiate(templates.fecharSala, transform.position, Quaternion.identity); 
    //            Destroy(gameObject);
    //        }
    //        spawned = true;
    //    }
    //}

    #endregion
}
