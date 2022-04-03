using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField] private Slider barraDeVida;
    [SerializeField] private INIStatus scriptDeStatus;
    [SerializeField] private Transform cam;

    private void FixedUpdate() 
    {
        if(scriptDeStatus != null)
        {
            barraDeVida.value = (scriptDeStatus.vida * 100 / scriptDeStatus.vidaMax) / 100;
            transform.position = new Vector3(scriptDeStatus.transform.position.x, transform.position.y, scriptDeStatus.transform.position.z);
            if(scriptDeStatus.vida <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }
}
