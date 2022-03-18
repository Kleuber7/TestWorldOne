using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FerreiroAtributos : MonoBehaviour
{
    [Header("Referências")]
    public DinheiroFerreiro dinheiroFerreiro;
    public ScriptablePlayer status;
    private InformacoesHUDJogador barras;
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

    [Header("Potion de Mana UI Info")]
    public GameObject potionManaInfo;
    public int precoPotionMana;
    public Text textoPrecoPotionMana;

    [Header("Scriptable Objects")]
    public VidaSO vidaSO;
    public ManaSO manaSO;
    public AtaqueSO ataqueSO;
    public DefesaSO defesaSO;
    public PotionVidaSO potionVidaSO;
    public PotionManaSO potionManaSO;

    private void Start()
    {
        barras = GameObject.FindGameObjectWithTag("InfoJogador").GetComponent<InformacoesHUDJogador>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                HUDFerreiro.SetActive(true);
                dinheiroFerreiro.dinheiroTxt.text = status.money.ToString();

                powerUpVida = vidaSO.powerUp;
                precoVida = vidaSO.preco;
                levelVida = status.levelVida;
                textoLevelVida.text = "Level " + levelVida;
                textoPrecoVida.text = precoVida.ToString();

                powerUpMana = manaSO.powerUp;
                precoMana = manaSO.preco;
                levelMana = status.levelMana;
                textoLevelMana.text = "Level " + levelMana;
                textoPrecoMana.text = precoMana.ToString();

                powerUpAtaque = ataqueSO.powerUp;
                precoAtaque = ataqueSO.preco;
                levelAtaque = status.levelAtaque;
                textoLevelAtaque.text = "Level " + levelAtaque;
                textoPrecoAtaque.text = precoAtaque.ToString();

                powerUpDefesa = defesaSO.powerUp;
                precoDefesa = defesaSO.preco;
                levelDefesa = status.levelDefesa;
                textoLevelDefesa.text = "Level " + levelDefesa;
                textoPrecoDefesa.text = precoDefesa.ToString();

                precoPotionVida = potionVidaSO.preco;
                textoPrecoPotionVida.text = precoPotionVida.ToString();

                precoPotionMana = potionManaSO.preco;
                textoPrecoPotionMana.text = precoPotionMana.ToString();
            }
        }
    }

    public void EvoluirVidaMax()
    {
        if (status.money >= precoVida)
        {
            status.maxHealth += powerUpVida;
            status.health += powerUpVida;
            status.money -= precoVida;
            UpaVida();
            barras.AtualizaDinheiro(status.money);
            dinheiroFerreiro.dinheiroTxt.text = status.money.ToString();
            barras.SetHealth(status.health);
        }

    }

    public void EvoluirManaMax()
    {
        if (status.money >= precoMana)
        {
            status.maxMana += powerUpMana;
            status.Mana += powerUpMana;
            barras.SetMana(status.Mana);
            status.money -= precoMana;
            UpaMana();
            barras.AtualizaDinheiro(status.money);
            dinheiroFerreiro.dinheiroTxt.text = status.money.ToString();
        }
    }

    public void EvoluirAtaque()
    {
        if (status.money >= precoAtaque)
        {
            status.maxAttack += powerUpAtaque;
            status.attack += powerUpAtaque;
            status.money -= precoAtaque;
            UpaAtaque();
            barras.AtualizaDinheiro(status.money);
            dinheiroFerreiro.dinheiroTxt.text = status.money.ToString();
        }
    }

    public void EvoluirDefesa()
    {
        if (status.money >= precoDefesa)
        {
            status.maxDefense += powerUpDefesa;
            status.defense += powerUpDefesa;
            status.money -= precoDefesa;
            UpaDefesa();
            barras.AtualizaDinheiro(status.money);
            dinheiroFerreiro.dinheiroTxt.text = status.money.ToString();
        }
    }

    public void ComprarPotionVida()
    {
        if (status.money >= precoPotionVida)
        {
            status.qntdPotionVida++;
            status.money -= precoPotionVida;
            barras.AtualizaDinheiro(status.money);
            dinheiroFerreiro.dinheiroTxt.text = status.money.ToString();
        }
    }

    public void ComprarPotionMana()
    {
        if (status.money >= precoPotionMana)
        {
            status.qntdPotionMana++;
            status.money -= precoPotionMana;
            barras.AtualizaDinheiro(status.money);
            dinheiroFerreiro.dinheiroTxt.text = status.money.ToString();
        }
    }

    public void UpaVida()
    {
        vidaSO.powerUp += 50;
        vidaSO.preco += 50 * status.levelVida;
        status.levelVida++;
        powerUpVida = vidaSO.powerUp;
        precoVida = vidaSO.preco;
        levelVida = status.levelVida;
        textoLevelVida.text = "Level " + levelVida;
        textoPrecoVida.text = precoVida.ToString();
    }
    public void UpaMana()
    {
        manaSO.powerUp += 50;
        manaSO.preco += 50 * status.levelMana;
        status.levelMana++;
        powerUpMana = manaSO.powerUp;
        precoMana = manaSO.preco;
        levelMana = status.levelMana;
        textoLevelMana.text = "Level " + levelMana;
        textoPrecoMana.text = precoMana.ToString();
    }
    public void UpaAtaque()
    {
        ataqueSO.powerUp += 50;
        ataqueSO.preco += 50 * status.levelAtaque;
        status.levelAtaque++;
        powerUpAtaque = ataqueSO.powerUp;
        precoAtaque = ataqueSO.preco;
        levelAtaque = status.levelAtaque;
        textoLevelAtaque.text = "Level " + levelAtaque;
        textoPrecoAtaque.text = precoAtaque.ToString();
    }
    public void UpaDefesa()
    {
        defesaSO.powerUp += 50;
        defesaSO.preco += 50 * status.levelDefesa;
        status.levelDefesa++;
        powerUpDefesa = defesaSO.powerUp;
        precoDefesa = defesaSO.preco;
        levelDefesa = status.levelDefesa;
        textoLevelDefesa.text = "Level " + levelDefesa;
        textoPrecoDefesa.text = precoDefesa.ToString();
    }
}
