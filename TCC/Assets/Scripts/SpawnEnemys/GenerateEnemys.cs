using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemys : MonoBehaviour
{
   
    [SerializeField] private SpawnEnemys enemys;
    public int numberOfSpawns = 1, contSpawns = 0;

    public static bool liberadoE = false;
  
    private void Update()
    {
        Spawnar();
    }

    public void Spawnar()
    {
        if(GameManager.gameManager.numeroI <= 0 && contSpawns < numberOfSpawns)
        {
            enemys.SpawnEnemy();

            contSpawns++;
        }
        else if(GameManager.gameManager.numeroI <= 0 && contSpawns >= numberOfSpawns)
        {
            liberadoE = true;
        }

        
    }


}
