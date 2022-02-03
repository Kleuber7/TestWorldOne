using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLATempoColisor : MonoBehaviour
{
    [SerializeField] private Collider colisor;
    [SerializeField] private float tempoColisor;

    private void Update() 
    {
        if(colisor.enabled == true)
        {
            StartCoroutine(expiraColisor());
        }
    }

    IEnumerator expiraColisor()
    {
        yield return new WaitForSeconds(tempoColisor);
        colisor.enabled = false;
    }
}
