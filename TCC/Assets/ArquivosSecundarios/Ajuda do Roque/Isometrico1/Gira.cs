using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gira : MonoBehaviour
{

    public Vector3 pos;
    Camera cam;
    void Start()
    {
        cam = Camera.main;
        pos = transform.position + transform.forward;
    }

    void Update() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)){
            pos = hit.point;
            pos.y = transform.position.y;
        } 
        Vector3 dir = pos - transform.position;
        transform.rotation = Quaternion.LookRotation(dir);

        //pegar a direção em relação ao mouse
        Vector3 relativeDir = pos - transform.position;
        //Pego o sinal se ele está à esquerda ou à direita do mouse
        Debug.Log("Direção horizontal" + Mathf.Sign(relativeDir.x));
        //Pego o sinal se ele está acima ou abaixo do mouse 
        Debug.Log("Direção vertical" + Mathf.Sign(relativeDir.z));
    }
}
