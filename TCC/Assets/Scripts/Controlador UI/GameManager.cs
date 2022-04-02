using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] protected GameObject jogador;
    [SerializeField] public float dinheiroJogador;
    [SerializeField] public GameObject info;
    [SerializeField] public GameObject loadTela;
    [SerializeField] private Scene[] cenas;
    [SerializeField] private int cenaIndex;
    [SerializeField] public bool teleportando = false;
    [SerializeField] public bool atacando = false;
    public GameObject[] contI;
    public int numeroI;
    [SerializeField] public GameObject menuOpções;
    [SerializeField] private ScriptablePlayer status;

    public Tela_De_Load load;
    
    private void Awake() 
    {
        cenas = new Scene[SceneManager.sceneCount];
        GameFeatures();

        numeroI = 1;
        teleportando = false;
        cenaIndex = SceneManager.GetSceneAt(0).buildIndex;
    }

    private void LateUpdate()
    {
        SceneChanges();
    }

    private void Update()
    {
        Menu();
        ContEnemys();
    }

    public GameObject GetPlayer()
    {
        return jogador;
    }

    void GameFeatures()
    {
        if (gameManager != null)
        {
            Destroy(gameManager.gameObject);
            gameManager = this;
        }
        else
        {
            gameManager = this;
        }

        if (jogador != null)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
            {
                if (GameObject.FindGameObjectsWithTag("Player")[i] != jogador)
                {
                    Destroy(GameObject.FindGameObjectsWithTag("Player")[i]);
                }
            }
        }
        else
        {
            jogador = GameObject.FindGameObjectWithTag("Jogador");
        }

        if (info != null)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Info").Length; i++)
            {
                if (GameObject.FindGameObjectsWithTag("Info")[i] != info)
                {
                    Destroy(GameObject.FindGameObjectsWithTag("Info")[i]);
                }
            }
        }
        else
        {
            info = GameObject.FindGameObjectWithTag("Info");
        }
    }
    void SceneChanges()
    {

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if(i < cenas.Length)
            {
                cenas[i] = SceneManager.GetSceneAt(i);
            }
        }

        if (SceneManager.GetSceneAt(0).buildIndex != cenaIndex)
        {
            SceneManager.MoveGameObjectToScene(jogador.gameObject, SceneManager.GetSceneAt(0));
            SceneManager.MoveGameObjectToScene(info.gameObject, SceneManager.GetSceneAt(0));
            SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetSceneAt(0));
            cenaIndex = SceneManager.GetSceneAt(0).buildIndex;
        }

        

    }
    void Menu()
    {
        if (menuOpções.activeSelf == false)
        {
            if (Input.GetKeyDown("escape"))
            {
                menuOpções.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown("escape"))
            {
                menuOpções.SetActive(false);
            }
        }
    }
    void ContEnemys()
    {
        contI = GameObject.FindGameObjectsWithTag("Inimigo");
        numeroI = contI.Length;
    }
}
