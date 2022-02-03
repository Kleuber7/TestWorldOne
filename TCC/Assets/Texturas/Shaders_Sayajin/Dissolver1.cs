using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolver1 : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float dissolverValor;
    public Renderer render;
    private void Start()
    {
        render = GetComponent<Renderer>();

        
    }
    void Update()
    {
        //if (dissolverValor > 0)
        //{

        //    StartCoroutine(DissolverSegundos());
        //}
    }



    public IEnumerator DissolverSegundos()
    {
        render.material.SetFloat("_DissolverController", dissolverValor);
        yield return new WaitForSeconds(1f);
        dissolverValor -= 0.001f;
    }
}
