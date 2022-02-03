using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBoss : MonoBehaviour
{
    private GameObject spawnerBoss;
    private RoomTemplates templates;

    void Start()
    {
        spawnerBoss = this.gameObject;
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    // Update is called once per frame
    void Update()
    {
        while (templates.contadorSalasBoss > 1)
        {
            RemoverSalaBoss();
        }
    }


    public void RemoverSalaBoss()
    {

        Destroy(GetComponent<Transform>().GetChild(templates.contadorSalasBoss - 1).gameObject);
        templates.contadorSalasBoss--;

    }

    
}
