using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJDesloca : MonoBehaviour
{
    [SerializeField] public float tempoStun;
    [SerializeField] public float tempoStunContador;
    [SerializeField] public float forcaStun;
    [SerializeField] private string tagColisor;
    [SerializeField] public Vector3 direcaoDeslocar;
    [SerializeField] public bool desloca = false;
    [SerializeField] public GameObject objeto;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == tagColisor)
        {
            objeto = other.gameObject;
            direcaoDeslocar = (other.gameObject.transform.position - this.gameObject.transform.position);
            direcaoDeslocar.y = Mathf.Sqrt((forcaStun / 2) * -2 * INIMovimento.gravidade * Time.deltaTime);
            StartCoroutine(other.gameObject.GetComponent<INIMovimento>().Stunado(tempoStun));
            StartCoroutine(Descolca(other.gameObject, direcaoDeslocar));
            desloca = true;
        }
    }

    private void Update() 
    {
        if(desloca)
        {
            if(tempoStunContador > 0)
            {
                Deslocar(objeto, direcaoDeslocar);
            }
            else
            {
                tempoStunContador = tempoStun;
            }
        }
    }

    public IEnumerator Descolca(GameObject objeto, Vector3 direcao)
    {
        //objeto.transform.position = Vector3.Lerp(objeto.transform.position, direcao.normalized * forcaStun, Time.deltaTime);
        //objeto.transform.Translate(direcao.normalized * forcaStun * Time.deltaTime, Space.World);
        //objeto.transform.position = Vector3.MoveTowards(objeto.transform.position, direcao.normalized * forcaStun, Time.deltaTime * forcaStun);
        tempoStunContador = tempoStun;
        yield return new WaitForSeconds(tempoStun);
        desloca = false;
    }

    public void Deslocar(GameObject _objeto, Vector3 _direcao)
    {
        if(_objeto == null || _direcao == null)
        return;
        
        _objeto.transform.Translate(_direcao * forcaStun * Time.deltaTime, Space.World);
        tempoStunContador -= Time.deltaTime;
    }
}
