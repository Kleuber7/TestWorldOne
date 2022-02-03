using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public Transform teleporteAlvo;
    public GameObject jogador;

    void OnTriggerEnter(Collider other)
    {
        jogador.transform.position = teleporteAlvo.transform.position;
    }
}
