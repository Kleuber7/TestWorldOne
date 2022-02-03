using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoSpawn : MonoBehaviour
{

    public GameObject enemyBow;
    private GameManager qInimigos;

    private void Start()
    {
        
    }
    public void SpawnBow()
    {
        Instantiate(enemyBow, transform.position, transform.rotation);

        
    }
}
