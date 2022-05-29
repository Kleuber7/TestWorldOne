using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JogoSlime : MonoBehaviour
{
    public Image MenuInicial;
    public GameObject CanvasFase;
    public GameObject Player;
    public static bool jogando;
    public bool inRange = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Player = other.gameObject;
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            MenuInicial.gameObject.SetActive(true);
            CanvasFase.gameObject.SetActive(true);
        }

        if (CanvasFase.active)
        {
            jogando = true;
        }
        else
        {
            jogando = false;
        }

    }
}
