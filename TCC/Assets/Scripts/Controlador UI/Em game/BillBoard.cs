using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform cam;
    [SerializeField] private TextMeshPro dinheiroTxt;
    [SerializeField] private ScriptablePlayer status;

    private void Start()
    {
        dinheiroTxt.text = ("+ " + status.moneyEarn.ToString());
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        Destroy(this.gameObject, 1f);
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
