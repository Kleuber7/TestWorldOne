using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloquearSala : MonoBehaviour
{
    
    private GameManager qInimigos;
    public GameObject portalDungeon;

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
        if (qInimigos.numeroI <= 0 && GenerateEnemys.liberadoE)
        {
            portalDungeon.SetActive(true);
           gameObject.SetActive(false);
        }
        else if(qInimigos.numeroI > 0)
        {
            portalDungeon.SetActive(false);
            gameObject.SetActive(true);
        }
       

   }

    
}
