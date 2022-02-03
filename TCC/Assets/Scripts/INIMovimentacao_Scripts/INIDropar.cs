using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INIDropar : MonoBehaviour
{
    [SerializeField] private GameObject drop;

    public void Dropar()
    {
        Instantiate(drop, this.transform.position, drop.transform.rotation);
    }
}
