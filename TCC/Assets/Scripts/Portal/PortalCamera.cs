using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform outroPortal;

    

    
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - outroPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;
    }
}
