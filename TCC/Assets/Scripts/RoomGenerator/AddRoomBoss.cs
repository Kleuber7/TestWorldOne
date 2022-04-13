using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoomBoss : MonoBehaviour
{
    public RoomTemplates templates;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.salasBoss.Add(this.gameObject);
    }
}
