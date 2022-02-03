using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates templates;
    public bool espacoLiberado = true;
   

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.salas.Add(this.gameObject);
       
        
        
    }


    //private void OnTriggerEnter(Collider other)
    //{
       
          
    //        Destroy(other.gameObject);
    //            espacoLiberado = false;

          
    //      //else
    //      //{
    //      //  Destroy(other.gameObject);
    //      //  espacoLiberado = true;

    //      //}
        


    //}

    // Update is called once per frame
    void Update()
    {
       
    }
}
