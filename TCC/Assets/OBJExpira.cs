using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJExpira : MonoBehaviour
{
    public float duracao;
    public bool iniciou;

    void Update()
    {
        if(!iniciou)
        {
            StartCoroutine(Expira());
        }
    }

    public IEnumerator Expira()
    {
        iniciou = true;
        yield return new WaitForSeconds(duracao);
        iniciou = false;
        this.gameObject.SetActive(false);
    }
}
