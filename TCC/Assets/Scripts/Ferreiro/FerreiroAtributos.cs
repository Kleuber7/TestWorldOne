using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FerreiroAtributos : MonoBehaviour
{
    [Header("Referências")]
    public DinheiroFerreiro dinheiroFerreiro;
    public ScriptablePlayer status;
    public InformacoesHUDJogador barras;
    public GameObject HUDFerreiro;

    [Header("Vida UI Info")]
    public GameObject vidaInfo;
    public int powerUpVida;
    public int levelVida;
    public Text textoLevelVida;
    public int precoVida;
    public Text textoPrecoVida;
    public Text descricaoVida;

    [Header("Mana UI Info")]
    public GameObject manaInfo;
    public int powerUpMana;
    public int levelMana;
    public Text textoLevelMana;
    public int precoMana;
    public Text textoPrecoMana;
    public Text descricaoMana;

    [Header("Ataque UI Info")]
    public GameObject AtaqueInfo;
    public int powerUpAtaque;
    public int levelAtaque;
    public Text textoLevelAtaque;
    public int precoAtaque;
    public Text textoPrecoAtaque;
    public Text descricaoAtaque;

    [Header("Defesa UI Info")]
    public GameObject defesaInfo;
    public int powerUpDefesa;
    public int levelDefesa;
    public Text textoLevelDefesa;
    public int precoDefesa;
    public Text textoPrecoDefesa;
    public Text descricaoDefesa;

    [Header("Potion de Vida UI Info")]
    public GameObject potionVidaInfo;
    public int precoPotionVida;
    public Text textoPrecoPotionVida;
    public Text descricaoPotionVida;

    [Header("Potion de Mana UI Info")]
    public GameObject potionManaInfo;
    public int precoPotionMana;
    public Text textoPrecoPotionMana;
    public Text descricaoPotionMana;

    [Header("Scriptable Objects")]
    public VidaSO vidaSO;
    public ManaSO manaSO;
    public AtaqueSO ataqueSO;
    public DefesaSO defesaSO;
    public PotionVidaSO potionVidaSO;
    public PotionManaSO potionManaSO;

    public bool canOpen;

    private void Start()
    {
        barras = GameObject.FindGameObjectWithTag("InfoJogador").GetComponent<InformacoesHUDJogador>();
    }

    private void Update()
    {

        if (canOpen)
        {
                dinheiroFerreiro.dinheiroTxt.text = status.money.ToString();

                vidaSO.powerUp = (status.levelVida * 100);
                vidaSO.preco = (status.levelVida * 100);
                powerUpVida = vidaSO.powerUp;
                precoVida = vidaSO.preco;
                levelVida = status.levelVida;
                textoLevelVida.text = "Level " + levelVida;
                textoPrecoVida.text = precoVida.ToString();
                descricaoVida.text = vidaSO.descricao + powerUpVida + " pontos.";

                manaSO.powerUp = (status.levelMana * 100);
                manaSO.preco = (status.levelMana * 100);
                powerUpMana = manaSO.powerUp;
                precoMana = manaSO.preco;
                levelMana = status.levelMana;
                textoLevelMana.text = "Level " + levelMana;
                textoPrecoMana.text = precoMana.ToString();
                descricaoMana.text = manaSO.descricao + powerUpMana + " pontos.";

                ataqueSO.powerUp = (status.levelAtaque * 50);
                ataqueSO.preco = (status.levelAtaque * 50);
                powerUpAtaque = ataqueSO.powerUp;
                precoAtaque = ataqueSO.preco;
                levelAtaque = status.levelAtaque;
                textoLevelAtaque.text = "Level " + levelAtaque;
                textoPrecoAtaque.text = precoAtaque.ToString();
                descricaoAtaque.text = ataqueSO.descricao + powerUpAtaque + " pontos.";

                defesaSO.powerUp = (status.levelDefesa * 50);
                defesaSO.preco = (status.levelDefesa * 50);
                powerUpDefesa = defesaSO.powerUp;
                precoDefesa = defesaSO.preco;
                levelDefesa = status.levelDefesa;
                textoLevelDefesa.text = "Level " + levelDefesa;
                textoPrecoDefesa.text = precoDefesa.ToString();
                descricaoDefesa.text = defesaSO.descricao + powerUpDefesa + " pontos.";

                precoPotionVida = potionVidaSO.preco;
                textoPrecoPotionVida.text = precoPotionVida.ToString();
                descricaoPotionVida.text = potionVidaSO.descricao;
                

                precoPotionMana = potionManaSO.preco;
                textoPrecoPotionMana.text = precoPotionMana.ToString();
                descricaoPotionMana.text = potionManaSO.descricao;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canOpen = false;
        }
    }

    public void EvoluirVidaMax()
    {
        if (status.money >= precoVida)
        {
            status.maxHealth += powerUpVida;
            status.health = status.maxHealth;
            status.money -= precoVida;
            UpaVida();
            dinheiroFerreiro.dinheiroTxt.text = status.money.ToString();
        }

    }

    public void EvoluirManaMax()
    {
        if (status.money >= precoMana)
        {
            status.maxMana += powerUpMana;
            status.Mana = status.maxMana;
            status.money -= precoMana;
            UpaMana();
            dinheiroFerreiro.dinheiroTxt.text = status.money.ToString();
        }
    }

    public void EvoluirAtaque()
    {
        if (status.money >= precoAtaque)
        {
            status.maxAttack += powerUpAtaque;
            status.attack = status.maxAttack;
            status.money -= precoAtaque;
            UpaAtaque();
            dinheiroFerreiro.dinheiroTxt.text = status.money.ToString();
        }
    }

    public void EvoluirDefesa()
    {
        if (status.money >= precoDefesa)
        {
            status.maxDefense += powerUpDefesa;
            status.defense = status.maxDefense;
            status.money -= precoDefesa;
            UpaDefesa();
            dinheiroFerreiro.dinheiroTxt.text = status.money.ToString();
        }
    }

    public void ComprarPotionVida()
    {
        if (status.money >= precoPotionVida)
        {
            status.qntdPotionVida++;
            status.money -= precoPotionVida;
            dinheiroFerreiro.dinheiroTxt.text = status.money.ToString();
        }
    }

    public void ComprarPotionMana()
    {
        if (status.money >= precoPotionMana)
        {
            status.qntdPotionMana++;
            status.money -= precoPotionMana;
            dinheiroFerreiro.dinheiroTxt.text = status.money.ToString();
        }
    }

    public void UpaVida()
    {
        status.levelVida++;
        vidaSO.powerUp = (status.levelVida * 100);
        vidaSO.preco = (status.levelVida * 100);
        powerUpVida = vidaSO.powerUp;
        precoVida = vidaSO.preco;
        levelVida = status.levelVida;
        textoLevelVida.text = "Level " + levelVida;
        textoPrecoVida.text = precoVida.ToString();
        descricaoVida.text = vidaSO.descricao + powerUpVida + " pontos.";
    }
    public void UpaMana()
    {
        status.levelMana++;
        manaSO.powerUp = (status.levelMana * 100);
        manaSO.preco = (status.levelMana * 100);
        powerUpMana = manaSO.powerUp;
        precoMana = manaSO.preco;
        levelMana = status.levelMana;
        textoLevelMana.text = "Level " + levelMana;
        textoPrecoMana.text = precoMana.ToString();
        descricaoMana.text = manaSO.descricao + powerUpMana + " pontos.";
    }
    public void UpaAtaque()
    {
        status.levelAtaque++;
        ataqueSO.powerUp = (status.levelAtaque * 50);
        ataqueSO.preco = (status.levelAtaque * 50);
        powerUpAtaque = ataqueSO.powerUp;
        precoAtaque = ataqueSO.preco;
        levelAtaque = status.levelAtaque;
        textoLevelAtaque.text = "Level " + levelAtaque;
        textoPrecoAtaque.text = precoAtaque.ToString();
        descricaoAtaque.text = ataqueSO.descricao + powerUpAtaque + " pontos.";
    }
    public void UpaDefesa()
    {
        status.levelDefesa++;
        defesaSO.powerUp = (status.levelDefesa * 50);
        defesaSO.preco = (status.levelDefesa * 50);
        powerUpDefesa = defesaSO.powerUp;
        precoDefesa = defesaSO.preco;
        levelDefesa = status.levelDefesa;
        textoLevelDefesa.text = "Level " + levelDefesa;
        textoPrecoDefesa.text = precoDefesa.ToString();
        descricaoDefesa.text = defesaSO.descricao + powerUpDefesa + " pontos.";
    }
}
