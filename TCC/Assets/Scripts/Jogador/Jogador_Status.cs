using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador_Status : MonoBehaviour
{
    [Header("Status maximo do atributo")]
    public float    Vida_Maxima,
                    Mana_Maxima,
                    Ataque_Maximo,
                    Defesa_Maxima,
                    Velocidade_Maxima;
    public float Vida,
                    Mana,
                    Ataque,
                    Defesa,
                    Velocidade,
                    alcance,
                    VidaExtra;

    public ScriptablePlayer status;
    public GameObject dinheiroS, vidaMaxS, manaMaxS, velocidadeMaxS;

    public InformacoesHUDJogador barras;

    public static int mortes;
    public static bool Invisivel;
    public static bool podeDarDano = true;

    void Start()
    {
        barras = GameObject.FindGameObjectWithTag("InfoJogador").GetComponent<InformacoesHUDJogador>();


        status.health = status.maxHealth;
        status.Mana = status.maxMana;
        status.defense = status.maxDefense;
        status.attack = status.maxAttack;
        status.speed = status.maxSpeed;

        

        barras.MaximoVida(status.maxHealth);
        barras.MaximoMana(status.maxMana);
        
    }
    void Update()
    {

        //RegenerarVida();
        RegenerarMana();
         
        if (status.health <= 0 && VidaExtra <= 0)
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
        if(Vida<Vida_Maxima)
        {
            Vida += 0.5f*Time.deltaTime;
        }else
        {
            Vida = Vida_Maxima;
        }
    }
    public void RegenerarMana()
    {
        if(Mana<Mana_Maxima)
        {
            Mana += 0.8f*Time.deltaTime;
        }else
        {
            Mana = Mana_Maxima;
        }
    }
#endregion

   
    public void Morrer()
    {

        GameObject.Find("Controlador").GetComponent<GameManager>().load.Carregar_CenaInicio(1);

        status.health = status.maxHealth;
        barras.SetHealth(status.health);
        
        Destroy(this.gameObject);
    }

    IEnumerator MorrerContagem()
    {
        GameManager.gameManager.teleportando = true;
        yield return new WaitForSeconds(2.5f);
        Morrer();
    }

    public void AtualizaValoresMaximos()
    {
        if(status.health > status.maxHealth)
        {
            status.health = status.maxHealth;
            barras.MaximoVida(status.maxHealth);
        }
        if(status.Mana > status.maxMana)
        {
            status.Mana = status.maxMana;
            barras.MaximoMana(status.maxMana);
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
        if(GameManager.gameManager.dinheiroJogador < 0)
        {
            GameManager.gameManager.dinheiroJogador = 0;
        }
    }

    public void TomarDano(float dano)
    {
        status.health -= dano;

        barras.SetHealth(status.health);
    }
}
