using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador_Status : MonoBehaviour
{
    public ScriptablePlayer status;
    public List<GameObject> skin;
    public GameObject dinheiroS;
    public FSMJogador animaPlayer;

    public static int mortes;
    public static bool morreu;
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

        if(status.skin == Skin.Default)
        {
            skin[(int)Skin.Fire].SetActive(false);
            skin[((int)status.skin)].SetActive(true);
            animaPlayer.jogadorAnima = skin[((int)status.skin)].GetComponent<Animator>();
        }
        else if(status.skin == Skin.Fire)
        {
            skin[(int)Skin.Default].SetActive(false);
            skin[((int)status.skin)].SetActive(true);
            animaPlayer.jogadorAnima = skin[((int)status.skin)].GetComponent<Animator>();
        }

    }
    void Update()
    { 
        if (status.health <= 0 && status.ExtraLife <= 0)
        {
                mortes++;
                StartCoroutine(MorrerContagem());
           
        }
        
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
        morreu = false;

        gameObject.SetActive(false);
    }

    IEnumerator MorrerContagem()
    {
        if (!morreu)
        {
            morreu = true;
            animaPlayer.ChangeAnimationState(animaPlayer.Morte());
        }
        yield return new WaitForSeconds(3f);
        Morrer();
    }

    

    public void AtualizaValoresMaximos()
    {
        RegenerarMana();

        if (status.moneyHUD)
        {
            Instantiate(dinheiroS, pointHUD.position, Quaternion.identity);
            status.moneyHUD = false;
        }
        
        if (status.health > status.maxHealth)
        {
            status.health = status.maxHealth;
        }
        if(status.Mana > status.maxMana)
        {
            status.Mana = status.maxMana;
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
        status.health -= dano/* - (status.defense / 10)*/;

    }
}
