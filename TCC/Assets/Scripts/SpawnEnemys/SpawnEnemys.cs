using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemys;
    [SerializeField] private List<Transform> spawnLocations;

    public void SpawnEnemy()
    {
        foreach (GameObject enemy in enemys)
        {
            int rSpawn = Random.Range(0, spawnLocations.Count);
            Instantiate(enemy, spawnLocations[rSpawn].position, transform.rotation);
        }
    }
}
