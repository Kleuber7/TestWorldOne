using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OBJDesloca : MonoBehaviour
{
    [SerializeField] public float deslocamentoStun;
    [SerializeField] public float forcaStun;
    [SerializeField] private string tagColisor;
    [SerializeField] public Vector3 direcaoDeslocar;
    [SerializeField] public bool desloca = false;
    [SerializeField] public GameObject objeto;
    [SerializeField] private int numJumps = 1;






    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagColisor && tagColisor == "Inimigo")
        {
            objeto = other.gameObject;
            desloca = true;
        }
    }

    private void Update()
    {
        if (desloca)
        {
            if(objeto.GetComponentInChildren<ED_Mimic>())
            {
                objeto.GetComponentInChildren<ED_Mimic>().Stun = true;
            }
            if(objeto.GetComponentInChildren<INIPerseguir>())
            {
                objeto.GetComponentInChildren<INIPerseguir>().takingDamage = true;
            }
            direcaoDeslocar = (objeto.transform.position - new Vector3(this.gameObject.transform.position.x, objeto.transform.position.y, this.gameObject.transform.position.z));
            objeto.transform.DOJump((direcaoDeslocar + objeto.transform.position), forcaStun, numJumps, deslocamentoStun).SetEase(Ease.Linear).OnComplete(()=>{if(objeto.GetComponentInChildren<ED_Mimic>()){objeto.GetComponentInChildren<ED_Mimic>().Stun = false;objeto.GetComponentInChildren<ED_Mimic>().Liberado = true;}});

            desloca = false;

            if(objeto.GetComponentInChildren<INIPerseguir>())
            {
                objeto.GetComponentInChildren<INIPerseguir>().takingDamage = false;
            }
        }
    }
}
