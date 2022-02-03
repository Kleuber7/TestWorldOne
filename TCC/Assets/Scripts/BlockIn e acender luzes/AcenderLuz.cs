using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcenderLuz : MonoBehaviour
{
    Light myLight;
    private GameManager qInimigos;
    Color corNormal = Color.white;
    Color corMudar = new Color(1, 0.56f, 0.949f);


    void Start()
    {
        myLight = GetComponent<Light>();
        qInimigos = GameManager.gameManager.gameObject.GetComponent<GameManager>();
    }

    void Update()
    {
        MudarLuz();
    }

    public void MudarLuz()
    {
        //tirar comentario depois
        if (qInimigos.numeroI <= 0 /*&& GenerateEnemys.liberadoE*/)
        {

            myLight.color = corNormal;

            //Piscando
            // myLight.intensity = Mathf.Lerp(1, 3, Mathf.PingPong(Time.time, 1f));
            //while (myLight.intensity < 2)
            //{
            //    myLight.intensity += 2 * Time.deltaTime;
            //}

        }
        else
        {
            myLight.color = corMudar;

        }

    }

   
}
