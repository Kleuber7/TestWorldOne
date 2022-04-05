using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorSecret : MonoBehaviour
{
    bool canOpen;
    public GameObject canvasMirror;


    private void Update()
    {
        if (canOpen)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                canvasMirror.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canOpen = true;
    }
    private void OnTriggerExit(Collider other)
    {
        canOpen = false;
    }
}
