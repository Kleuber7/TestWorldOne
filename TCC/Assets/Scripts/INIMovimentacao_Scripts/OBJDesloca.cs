using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OBJDesloca : MonoBehaviour
{
    [SerializeField] public float tempoStun;
    [SerializeField] public float forcaStun;
    [SerializeField] private string tagColisor;
    [SerializeField] public Vector3 direcaoDeslocar;
    [SerializeField] public bool desloca = false;
    [SerializeField] public GameObject objeto;

    private void OnTriggerStay(Collider other) 
    {
       if(other.gameObject.tag == tagColisor && tagColisor == "Inimigo")
       {
           objeto = other.gameObject;
           desloca = true;
       }
    }

    private void Update() 
    {
       if(desloca)
       {
           direcaoDeslocar = (objeto.transform.position - new Vector3(this.gameObject.transform.position.x , objeto.transform.position.y, this.gameObject.transform.position.z ));
           objeto.transform.DOJump(direcaoDeslocar * direcaoDeslocar.magnitude, forcaStun, 1, tempoStun).SetEase(Ease.Flash);
           desloca = false;
       }
    }
}
