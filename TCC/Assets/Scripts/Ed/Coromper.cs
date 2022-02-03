using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coromper : MonoBehaviour
{
    public float Destruir;
    void Update()
    {
        StartCoroutine(Apagar());
    }
    void OnTriggerStay(Collider Colidiu)
    {
        if(Colidiu.gameObject.tag == "Inimigo")
        {
            Colidiu.gameObject.GetComponent<INIStatus>().Efeito_Comromper = true;
            Debug.Log("entrei iann");
        }
    }
    IEnumerator Apagar()
    {
        yield return new WaitForSeconds(Destruir);
        Destroy(this.gameObject);
    }
}