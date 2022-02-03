using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderArmaCongelada : MonoBehaviour
{
    [SerializeField] private Collider colisor;

    public void AtivarColisorCongelar()
    {
        colisor.enabled = true;
    }
}
