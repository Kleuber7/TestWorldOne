using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorSunFire : MonoBehaviour
{
    [SerializeField] private Collider colisor;


    public void AtivarColisor()
    {
        colisor.enabled = true;
    }



}
