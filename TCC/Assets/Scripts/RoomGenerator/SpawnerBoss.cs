using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnerBoss : MonoBehaviour
{
    private GameObject spawnerBoss;
    private RoomTemplates templates;
    public int salasBoss;

    void Start()
    {
        spawnerBoss = this.gameObject;
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    // Update is called once per frame
    void Update()
    {
        salasBoss = templates.salasBoss.Count;
        while (templates.contadorSalasBoss > 1)
        {
            RemoverSalasBoss();
        }
    }


    public async void RemoverSalasBoss()
    {
        await RemoverSalasAsync();
    }
    public async Task RemoverSalasAsync()
    {
        Destroy(spawnerBoss.transform.GetChild(templates.contadorSalasBoss - 1).gameObject);
        templates.contadorSalasBoss--;
        await Task.Yield();
    }
    

    
}
