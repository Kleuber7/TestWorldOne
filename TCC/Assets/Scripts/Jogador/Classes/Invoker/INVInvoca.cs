using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INVInvoca : MonoBehaviour
{
    private GameObject aliadoPrefab;
    [SerializeField] private GameObject[] listaPrefabsAliados = new GameObject[4];
    [SerializeField] private Transform pontoDeInvocacao;

    public void Invoca()
    {
        Instantiate(aliadoPrefab, pontoDeInvocacao.position + new Vector3 (0f, aliadoPrefab.transform.position.y, 0f), aliadoPrefab.transform.rotation);
    }

    public void SetAliado(int indexAliado)
    {
        aliadoPrefab = listaPrefabsAliados[indexAliado];
    }
}
