using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador_Status : MonoBehaviour
{
    public ScriptablePlayer status;
    public List<GameObject> skin;
    public GameObject dinheiroS;


    public InformacoesHUDJogador barras;

    public static int mortes;
    public bool morreu;
    public static bool Invisivel;
    public static bool podeDarDano = true;
    [SerializeField] private Transform pointHUD;
    
    void Start()
    {
       
        status.health = status.maxHealth;
        status.Mana = status.maxMana;
        status.defense = status.maxDefense;
        status.attack = status.maxAttack;
        status.speed = status.maxSpeed;

        status.levelVida = 1;
        status.levelMana = 1;
        status.levelAtaque = 1;
        status.levelDefesa = 1;

        //barras.MaximoVida(status.maxHealth);
       // barras.MaximoMana(status.maxMana);
        
        if(status.skin == Skin.Default)
        {
            skin[(int)Skin.Fire].SetActive(false);
            skin[((int)status.skin)].SetActive(true);
        }
        else if(status.skin == Skin.Fire)
        {
            skin[(int)Skin.Default].SetActive(false);
            skin[((int)status.skin)].SetActive(true);
        }

    }
    void Update()
    {

        //RegenerarVida();
        RegenerarMana();
         
        if (status.health <= 0 && status.ExtraLife <= 0)
        {
            //Ligar novamente quando tiver shader   
            //if (GetComponentInChildren<Dissolver>().dissolverValor > 0)
                //{
                //   StartCoroutine(GetComponentInChildren<Dissolver>().DissolverSegundos());
                //}
                //GetComponent<Dissolver>().render.material.SetFloat("_DissolverController", GetComponent<Dissolver>().dissolverValor);
                mortes++;
                StartCoroutine(MorrerContagem());
            
        }
        //Ligar novamente quando tiver shader de dissolver
        //else if(Vida <= 0 && VidaExtra >= 1)
        //{
            
        //    StartCoroutine(GetComponentInChildren<Dissolver>().DissolverReviver());


        //    StartCoroutine(GetComponentInChildren<Dissolver>().DissolverReviverVolta());
        //}


        AtualizaValoresMaximos();
        
    }
    #region (Rgeneração de vida e Mana)
    public void RegenerarVida()
    {
        if(status.health < status.maxHealth)
        {
            status.health += 0.5f*Time.deltaTime;
        }else
        {
            status.health = status.maxHealth;
        }
    }
    public void RegenerarMana()
    {
        if(status.Mana < status.maxMana)
        {
            status.Mana += 0.8f*Time.deltaTime;
        }else
        {
            status.Mana = status.maxMana;
        }
    }
#endregion

   
    public void Morrer()
    {

        GameObject.Find("Controlador").GetComponent<GameManager>().load.Carregar_CenaInicio(1);

        status.health = status.maxHealth;
        barras.SetHealth(status.health);
        morreu = false;
        
        Destroy(this.gameObject);
    }

    IEnumerator MorrerContagem()
    {
        morreu = true;
        GameManager.gameManager.teleportando = true;
        yield return new WaitForSeconds(2.5f);
        Morrer();
    }

    

    public void AtualizaValoresMaximos()
    {
        if (status.moneyHUD)
        {
            Instantiate(dinheiroS, pointHUD.position, Quaternion.identity);
            status.moneyHUD = false;
        }
        


        if (barras == null)
        {
            barras = GameObject.FindGameObjectWithTag("InfoJogador").GetComponent<InformacoesHUDJogador>();
        }

        if (status.health > status.maxHealth)
        {
            status.health = status.maxHealth;
            //barras.MaximoVida(status.maxHealth);
        }
        if(status.Mana > status.maxMana)
        {
            status.Mana = status.maxMana;
            //barras.MaximoMana(status.maxMana);
        }
        if (status.defense > status.maxDefense)
        {
            status.defense = status.maxDefense;
        }
        if (status.attack > status.maxAttack)
        {
            status.attack = status.maxAttack;
        }
        if (status.speed > status.maxSpeed)
        {
            status.speed = status.maxSpeed;
        }
        if(status.money < 0)
        {
            status.money = 0;
        }
    }

    public void TomarDano(float dano)
    {
        status.health -= dano;

        barras.SetHealth(status.health);
    }
}
