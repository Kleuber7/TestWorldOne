using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INIReprodutor : MonoBehaviour
{
    [SerializeField] private Transform pontoDeDesova;
    [SerializeField] private GameObject prefabInimigo;
    [SerializeField] private float tempoReproducao;
    [SerializeField] private bool reproduzindo = false;

    private void Update() 
    {
        if(!reproduzindo)
        {
            StartCoroutine(ContadorReproduz());
        }
    }

    IEnumerator ContadorReproduz()
    {
        reproduzindo = true;
        yield return new WaitForSeconds(tempoReproducao);
        Produz(prefabInimigo);
        reproduzindo = false;
    }

    void Produz(GameObject _prefabInimigo)
    {
        Instantiate(prefabInimigo, pontoDeDesova.position, prefabInimigo.transform.rotation);
    }
}
