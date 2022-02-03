using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BauBencao : MonoBehaviour
{

    [SerializeField] private GameObject hudBencao;
    [SerializeField] private Collider colisor;
    [SerializeField] GameObject player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        hudBencao = GameObject.Find("BencaoC").transform.GetChild(0).gameObject;
        hudBencao.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                hudBencao.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }


    public void DeletarHud()
    {
        hudBencao.gameObject.SetActive(false);
        Destroy(GameObject.Find("Bau Bencao"));
    }

    public void Despausar()
    {
        Time.timeScale = 1;
    }


    public void Congelar()
    {
        player.GetComponent<JogadorBencaosControle>().Congelar();
    }
    public void SunFire()
    {
        player.GetComponent<JogadorBencaosControle>().SunFire();
    }
    
    public void Reviver()
    {
        player.GetComponent<JogadorBencaosControle>().Reviver();
    }

    public void FontedeVida()
    {
        player.GetComponent<JogadorBencaosControle>().FontedeVida();
    }
    public void Camuflagem()
    {
        player.GetComponent<JogadorBencaosControle>().Camuflagem();
    }

}
