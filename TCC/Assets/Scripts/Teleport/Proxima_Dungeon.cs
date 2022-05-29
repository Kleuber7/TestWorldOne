using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proxima_Dungeon : MonoBehaviour
{
    public GameObject   Jogador,
                        Load;
    public Tela_De_Load Codigo_Load;
    public AudioManager audiomanager;
    public bool entrou;
    
    void Start()
    {   
        Jogador = GameObject.Find("Jogador");

        //Load = GameObject.FindGameObjectWithTag("Load");
        //Codigo_Load = Load.GetComponent<Tela_De_Load>();

        //StartCoroutine(ChamarLoad());

        Load.transform.GetChild(0).gameObject.SetActive(false);
    }

     private void Update() 
     {
        EnterDungeon();
     }


    void EnterDungeon()
    {
        if (entrou)
        {
            if (!GameManager.gameManager.teleportando)
            {
                Load.SetActive(true);
                Codigo_Load.Carregar_Scena(2);
                
            }
            entrou = false;
        }
    }
    IEnumerator ChamarLoad()
    {
        yield return new WaitForSeconds(0.5f);
        Load = GameObject.FindGameObjectWithTag("Load");
        Codigo_Load = Load.GetComponent<Tela_De_Load>();
    }
    private void OnTriggerEnter (Collider Entrei)
    {
        
        if(Entrei.gameObject.tag == "Player")
        {
            entrou = true;
        }
    }
}
