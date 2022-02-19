using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] salasInverno;
    public GameObject[] salasVerao;
    public GameObject[] salasOutono;
    public GameObject[] salasPrimavera;
    public GameObject salaBoss;

    public List<GameObject> salas;

    public float tempoEspera;
    private bool spawnedBoss = false;
    public int numerosSalas;
    public int contadorSalasBoss;
    public int contadorSalas = 1;

    #region comentsUpdate
    //if(tempoEspera <= 0 && spawnedBoss == false)
    //{
    //    for (int i = 0; i < salas.Count; i++)
    //    {
    //        if(i == salas.Count-1)
    //        {
    //           // Instantiate(boss, salas[i].transform.position, Quaternion.identity);
    //            spawnedBoss = true;
    //        }
    //    }
    //}
    //else
    //{
    //    tempoEspera -= Time.deltaTime;
    //}
    #endregion
}
