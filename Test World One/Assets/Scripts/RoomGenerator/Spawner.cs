using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject spawner;
    private RoomTemplates templates;
    

    void Start()
    {
        spawner = this.gameObject;
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
      
        
    }

    private void Update()
    {
        while (templates.contadorSalas > templates.numerosSalas)
        {
            RemoverSalas();
        }

        
    }


        public void RemoverSalas()
        {
       
            Destroy(GetComponent<Transform>().GetChild(templates.contadorSalas - 1).gameObject);
            
            templates.contadorSalas--;
        }

    

}
