using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    public RoomTemplates templates;
    public bool espacoLiberado = true;
    public int quantidadeInimigos;
   
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.salas.Add(this.gameObject);
    }
}
