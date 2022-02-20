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
            Destroy(currentSpawn, 0.1f);

            await Task.Yield();

            Teleporting.podeExcluirP = false;
        }
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
