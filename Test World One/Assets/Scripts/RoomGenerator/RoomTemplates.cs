using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] salasBaixo;
    public GameObject[] salasCima;
    public GameObject[] salasEsquerda;
    public GameObject[] salasDireita;
    public GameObject salaBoss;

    public GameObject fecharSala;

    public List<GameObject> salas;

   

    public float tempoEspera;
    private bool spawnedBoss = false;
   // public GameObject boss;
    public int numerosSalas;
    public int contadorSalasBoss;
    public int contadorSalas = 1;
    
    
    
  

    private void Start()
    {
        
    }
    private void Update()
    {
        if(tempoEspera <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < salas.Count; i++)
            {
                if(i == salas.Count-1)
                {
                   // Instantiate(boss, salas[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }
        else
        {
            tempoEspera -= Time.deltaTime;
        }
        

        

       



    }
}
