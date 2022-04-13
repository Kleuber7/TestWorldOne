using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSmooth : MonoBehaviour
{
    public Transform player;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void LateUpdate()
    {
        if(GameManager.gameManager != null)
        {
            if(player == null)
            {
                player = GameManager.gameManager.GetPlayer().transform;
            }
        }

        CamFollow();
    }

    void CamFollow()
    {
        Vector3 desiredPosition = player.position + offset;
       // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = desiredPosition;

        transform.LookAt(player);
    }
}
