using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject spawner;
    private RoomTemplates templates;
    public int salas;
    [SerializeField] private GameObject currentSpawn;

    void Start()
    {
        spawner = this.gameObject;
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        
        
    }



    private void LateUpdate()
    {
        

        salas = templates.salas.Count;

        while (templates.contadorSalas > templates.numerosSalas)
        {
            RemoverSalas();
        }

       DeleteLastSpawn();


    }

    public async void DeleteLastSpawn()
    {
        await DeleteLastSpawnAsync();
    }
    public async Task DeleteLastSpawnAsync()
    {
        currentSpawn = spawner.transform.GetChild(0).gameObject;

        if (Teleporting.podeExcluirP == true)
        {
            //StartCoroutine(Esconder());
            // Destroy(GetComponent<Transform>().GetChild(templates.salas.Count - 1).gameObject, 0.5f);

            //GetComponent<Transform>().GetChild(templates.salas.Count - 2).gameObject.SetActive(false);

            Destroy(currentSpawn, 0.1f);

            await Task.Yield();

            Teleporting.podeExcluirP = false;
        }
    }

    IEnumerator Esconder()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<Transform>().GetChild(templates.salas.Count - 2).gameObject.SetActive(false);
    }


    public async void RemoverSalas()
    {
        await RemoverSalasAsync();
    }
    public async Task RemoverSalasAsync()
    {
        Destroy(spawner.transform.GetChild(templates.contadorSalas - 1).gameObject);
        templates.contadorSalas--;
        await Task.Yield();
    }
        

    

}
