using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemys : MonoBehaviour
{

    [SerializeField] private List<GameObject> ordas;
    public int numberOfSpawns = 1, contSpawns = 0;

    public static bool liberadoE = false;

    private void Update()
    {
        Spawnar();
    }

    public void Spawnar()
    {
        if (GameManager.gameManager.numeroI <= 0 && contSpawns < numberOfSpawns)
        {
            int r = Random.Range(0, ordas.Count);
            if (ordas[r].gameObject.activeSelf != true)
            {
                ordas[r].gameObject.SetActive(true);
                contSpawns++;
            }
            else
            {
                r = Random.Range(0, ordas.Count);
                ordas[r].gameObject.SetActive(true);
                contSpawns++;
            }
        }
        else if (GameManager.gameManager.numeroI <= 0 && contSpawns >= numberOfSpawns)
        {
            liberadoE = true;
        }


    }


}
