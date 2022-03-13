using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLATiro : MonoBehaviour
{
    [SerializeField] private float velocidadeDisparo;
    [SerializeField] private float danoDisparo;
    [SerializeField] public Vector3 direcao;
    [SerializeField] public bool atirou = false;

    private void Start() 
    {
        StartCoroutine(Expira());
    }

    private void Update() 
    {
        if(atirou)
        {
            Desloca();
        }   
    }

    public void Desloca()
    {
        this.gameObject.transform.Translate(new Vector3(direcao.x, 0, direcao.z).normalized * Time.deltaTime * velocidadeDisparo, Space.World);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Inimigo")
        {
            other.GetComponent<INIStatus>().TomarDano(danoDisparo);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Boboneco")
        {
            other.GetComponent<StatusBoboneco>().TomarDano(danoDisparo);
            Destroy(this.gameObject);
        }
    }

    public IEnumerator Expira()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}

