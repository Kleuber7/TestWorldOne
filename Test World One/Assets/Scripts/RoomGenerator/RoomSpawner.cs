using System.Collections;
using System.Collections.Generic;
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
    
    

    public float waitTime = 0.5f;

    public void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        objetoPai = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        objetoPaiBoss = GameObject.FindGameObjectWithTag("SpawnerBoss").GetComponent<SpawnerBoss>();
        

        if (templates.salas.Count < templates.numerosSalas )
        {

            Invoke("Spawn", 1f);
        }
        else if (templates.salas.Count < templates.numerosSalas + 1)
        {
            Invoke("SpawnBoss", 1f);
  
        }
        
    }


    

    void Spawn()
    {
        aleatorio = Random.Range(3, 5);
        abrirDirecao = aleatorio;

        if (spawned == false )
            {

                if (abrirDirecao == 1)
                {
                    // Precisa Spawnar a Porta baixo
                    aleatorio = Random.Range(0, templates.salasBaixo.Length);
                    Instantiate(templates.salasBaixo[aleatorio], transform.position, templates.salasBaixo[aleatorio].transform.rotation, objetoPai.transform);
                    //objetoPai.spawner.transform.parent = templates.salasBaixo[aleatorio].transform;    

                }
                else if (abrirDirecao == 2)
                {
                    // Precisa Spawnar a Porta cima
                    aleatorio = Random.Range(0, templates.salasCima.Length);
                    Instantiate(templates.salasCima[aleatorio], transform.position, templates.salasCima[aleatorio].transform.rotation, objetoPai.transform);
                    //objetoPai.spawner.transform.parent = templates.salasBaixo[aleatorio].transform;
            }
                else if (abrirDirecao == 3)
                {
                    // Precisa Spawnar a Porta esquerda
                    aleatorio = Random.Range(0, templates.salasEsquerda.Length);
                    Instantiate(templates.salasEsquerda[aleatorio], transform.position, templates.salasEsquerda[aleatorio].transform.rotation, objetoPai.transform);
                   // objetoPai.spawner.transform.parent = templates.salasBaixo[aleatorio].transform;
            }
                else if (abrirDirecao == 4)
                {
                    // Precisa Spawnar a Porta direita
                    aleatorio = Random.Range(0, templates.salasDireita.Length);
                    Instantiate(templates.salasDireita[aleatorio], transform.position, templates.salasDireita[aleatorio].transform.rotation, objetoPai.transform);
                    //objetoPai.spawner.transform.parent = templates.salasBaixo[aleatorio].transform;
            }
                spawned = true;
            }

        if (GameObject.FindGameObjectWithTag("sala"))
        {
            templates.contadorSalas = objetoPai.transform.childCount;


            //templates.index[templates.contadorSalas] = templates.contadorSalas
            // GameObject.FindGameObjectWithTag("sala").GetComponent<AddRoom>().index = templates.index[templates.contadorSalas];

            //while (templates.contadorSalas > templates.numerosSalas)
            //{

            //    //colocar no final do index
            //    Destroy(GetComponent<Transform>().GetChild(templates.contadorSalas - 1).gameObject);
            //    Debug.Log("to aq2");
            //    templates.contadorSalas--;
            //}
        }

    }

     void SpawnBoss()
     {
        Instantiate(templates.salaBoss, transform.position, templates.salaBoss.transform.rotation, objetoPaiBoss.transform);

        if (GameObject.FindGameObjectWithTag("salaBoss"))
        {
            templates.contadorSalasBoss = objetoPaiBoss.transform.childCount;

            //while (templates.contadorSalasBoss > 1)
            //{
            //   // Destroy(objetoPai.spawner.transform.GetChild(templates.contadorSalasBoss));
            //    //templates.salas.RemoveAt(templates.salas.Count - 1);
            //    Debug.Log("to aq");
            //    templates.contadorSalasBoss--;
            //}
        }


    }
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

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("SpawnPoint"))
        {
            
            espacoLiberado = 0;

            
        }
        else
        {
            espacoLiberado = 1;
        }

        if (espacoLiberado == 0)
        {

            Destroy(other.gameObject);

        }
    }
}
