using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemys : MonoBehaviour
{
   
    public ArcoSpawn arco;
    public int numberOfSpawns = 1, contSpawns = 0;

    public static bool liberadoE = false;
    void Start()
    {

    }

    private void Update()
    {
        Spawnar();
    }

    public void Spawnar()
    {
        if(GameManager.gameManager.numeroI <= 0 && contSpawns < numberOfSpawns)
        {
            arco.SpawnBow();

            contSpawns++;
        }
        else if(GameManager.gameManager.numeroI <= 0 && contSpawns >= numberOfSpawns)
        {
            liberadoE = true;
        }

        
    }


}
