using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JogoSlime : MonoBehaviour
{
    public Image MenuInicial;
    public GameObject CanvasFase;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                MenuInicial.gameObject.SetActive(true);
                CanvasFase.gameObject.SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
