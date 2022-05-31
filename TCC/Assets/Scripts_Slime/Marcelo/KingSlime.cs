using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KingSlime : MonoBehaviour
{
    public int vida = 3;
    public Image gameOver;
    public Image coracaoUm;
    public Image coracaoDois;
    public Image coracaoTres;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void VerificaVida()
    {
        if (vida <= 0)
        {
            coracaoTres.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(true);
        }
        if (vida == 2)
        {
            coracaoUm.gameObject.SetActive(false);
        }
        if (vida == 1)
        {
            coracaoDois.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Inimigo")
        {
            vida--;
            VerificaVida();
            col.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
