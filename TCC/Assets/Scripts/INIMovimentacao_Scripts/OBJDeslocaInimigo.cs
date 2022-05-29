using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJDeslocaInimigo : MonoBehaviour
{
    public float tLerp;

    public void DeslocaI(Vector3 vetor)
    {

        Vector3.Lerp(transform.position, vetor, tLerp);
    }

    
}
