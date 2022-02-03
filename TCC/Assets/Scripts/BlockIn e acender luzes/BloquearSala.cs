using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloquearSala : MonoBehaviour
{
    
    private GameManager qInimigos;

    void Start()
    {

        qInimigos = GameManager.gameManager.gameObject.GetComponent<GameManager>();
    }

    private void Update()
    {
        DesbloquearSala();
    }

   public void DesbloquearSala()
   {
        //Tirar comentario depois
        if (qInimigos.numeroI <= 0 /*&& GenerateEnemys.liberadoE*/)
        {
           gameObject.SetActive(false);
        }
       

   }

    
}
