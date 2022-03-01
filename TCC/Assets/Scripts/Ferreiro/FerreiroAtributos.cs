using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FerreiroAtributos : MonoBehaviour
{
    private ScriptablePlayer status;
    private InformacoesHUDJogador barras;
    public GameObject HUDFerreiro;
    public GameObject vida1; /*, vida2, vida3, vida4;*/
    public GameObject mana1; /*, mana2, mana3, mana4;*/
    public GameObject forca1; /*, forca2, forca3, forca4;*/
    public GameObject defesa1; /*, defesa2, defesa3, defesa4;*/
    public int preco1 = 50, preco2 = 100, preco3 = 150, preco4 = 200;

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
                DinheiroFerreiro.dinheiroTxt = GameObject.Find("ValorFerreiro").GetComponent<Text>();
                DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();

            }
        }
    }

    public void EvoluirVidaMax50()
    {
        if (GameManager.gameManager.dinheiroJogador >= preco1 && vida1.GetComponentInChildren<Text>().text != "X")
        {
            status.maxHealth += 50;
            status.health += 50;
            GameManager.gameManager.dinheiroJogador -= 50;
            barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
            DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
            barras.SetHealth(status.health);

            vida1.GetComponentInChildren<Text>().text = "X";
            //vida2.gameObject.SetActive(true);
        }

    }

    //public void EvoluirVidaMax100()
    //{
    //    if (GameManager.gameManager.dinheiroJogador >= preco2 && vida2.GetComponentInChildren<Text>().text != "X")
    //    {
    //        status.Vida_Maxima += 100;
    //        status.Vida += 100;
    //        barras.SetHealth(status.Vida);
    //        GameManager.gameManager.dinheiroJogador -= 100;
    //        barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
    //        DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
    //        vida2.GetComponentInChildren<Text>().text = "X";
    //        vida3.gameObject.SetActive(true);
    //    }
    //}
    //public void EvoluirVidaMax150()
    //{
    //    if (GameManager.gameManager.dinheiroJogador >= preco3 && vida3.GetComponentInChildren<Text>().text != "X")
    //    {
    //        status.Vida_Maxima += 150;
    //        status.Vida += 150;
    //        barras.SetHealth(status.Vida);
    //        GameManager.gameManager.dinheiroJogador -= 150;
    //        barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
    //        DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
    //        vida3.GetComponentInChildren<Text>().text = "X";
    //        vida4.gameObject.SetActive(true);
    //    }
    //}
    //public void EvoluirVidaMax200()
    //{
    //    if (GameManager.gameManager.dinheiroJogador >= preco4 && vida4.GetComponentInChildren<Text>().text != "X")
    //    {
    //        status.Vida_Maxima += 200;
    //        status.Vida += 200;
    //        barras.SetHealth(status.Vida);
    //        GameManager.gameManager.dinheiroJogador -= 200;
    //        barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
    //        DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
    //        vida4.GetComponentInChildren<Text>().text = "X";
    //    }

    //}


    public void EvoluirManaMax50()
    {
        if (GameManager.gameManager.dinheiroJogador >= preco1 && mana1.GetComponentInChildren<Text>().text != "X")
        {
            status.maxMana += 50;
            status.Mana += 50;
            barras.SetHealth(status.Mana);
            GameManager.gameManager.dinheiroJogador -= 50;
            barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
            DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
            mana1.GetComponentInChildren<Text>().text = "X";
            //mana2.gameObject.SetActive(true);
        }
    }
    //public void EvoluirManaMax100()
    //{
    //    if (GameManager.gameManager.dinheiroJogador >= preco2 && mana2.GetComponentInChildren<Text>().text != "X")
    //    {
    //        status.Mana_Maxima += 100;
    //        status.Mana += 100;
    //        barras.SetHealth(status.Mana);
    //        GameManager.gameManager.dinheiroJogador -= 100;
    //        barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
    //        DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
    //        mana2.GetComponentInChildren<Text>().text = "X";
    //        mana3.gameObject.SetActive(true);
    //    }
    //}
    //public void EvoluirManaMax150()
    //{
    //    if (GameManager.gameManager.dinheiroJogador >= preco3 && mana3.GetComponentInChildren<Text>().text != "X")
    //    {
    //        status.Mana_Maxima += 150;
    //        status.Mana += 150;
    //        barras.SetHealth(status.Mana);
    //        GameManager.gameManager.dinheiroJogador -= 150;
    //        barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
    //        DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
    //        mana3.GetComponentInChildren<Text>().text = "X";
    //        mana4.gameObject.SetActive(true);
    //    }
    //}
    //public void EvoluirManaMax200()
    //{
    //    if (GameManager.gameManager.dinheiroJogador >= preco4 && mana4.GetComponentInChildren<Text>().text != "X")
    //    {
    //        status.Mana_Maxima += 200;
    //        status.Mana += 200;
    //        barras.SetHealth(status.Mana);
    //        GameManager.gameManager.dinheiroJogador -= 200;
    //        barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
    //        DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
    //        mana4.GetComponentInChildren<Text>().text = "X";
    //    }
    //}

    public void EvoluirForca10()
    {
        if (GameManager.gameManager.dinheiroJogador >= preco1 && forca1.GetComponentInChildren<Text>().text != "X")
        {
            status.maxAttack += 10;
            status.attack += 10;
            GameManager.gameManager.dinheiroJogador -= 50;
            barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
            DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
            forca1.GetComponentInChildren<Text>().text = "X";
            //forca2.gameObject.SetActive(true);
        }
    }
    //public void EvoluirForca20()
    //{
    //    if (GameManager.gameManager.dinheiroJogador >= preco2 && forca2.GetComponentInChildren<Text>().text != "X")
    //    {
    //        status.Ataque_Maximo += 20;
    //        status.Ataque += 20;
    //        GameManager.gameManager.dinheiroJogador -= 100;
    //        barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
    //        DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
    //        forca2.GetComponentInChildren<Text>().text = "X";
    //        forca3.gameObject.SetActive(true);
    //    }
    //}
    //public void EvoluirForca30()
    //{
    //    if (GameManager.gameManager.dinheiroJogador >= preco3 && forca3.GetComponentInChildren<Text>().text != "X")
    //    {
    //        status.Ataque_Maximo += 30;
    //        status.Ataque += 30;
    //        GameManager.gameManager.dinheiroJogador -= 150;
    //        barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
    //        DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
    //        forca3.GetComponentInChildren<Text>().text = "X";
    //        forca4.gameObject.SetActive(true);
    //    }
    //}
    //public void EvoluirForca40()
    //{
    //    if (GameManager.gameManager.dinheiroJogador >= preco4 && forca4.GetComponentInChildren<Text>().text != "X")
    //    {
    //        status.Ataque_Maximo += 40;
    //        status.Ataque += 40;
    //        GameManager.gameManager.dinheiroJogador -= 200;
    //        barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
    //        DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
    //        forca4.GetComponentInChildren<Text>().text = "X";

    //    }
    //}

    public void EvoluirDefesa10()
    {
        if (GameManager.gameManager.dinheiroJogador >= preco1 && defesa1.GetComponentInChildren<Text>().text != "X")
        {
            status.maxDefense += 10;
            status.defense += 10;
            GameManager.gameManager.dinheiroJogador -= 50;
            barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
            DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
            defesa1.GetComponentInChildren<Text>().text = "X";
            //defesa2.gameObject.SetActive(true);
        }
    }
    //public void EvoluirDefesa20()
    //{
    //    if (GameManager.gameManager.dinheiroJogador >= preco2 && defesa2.GetComponentInChildren<Text>().text != "X")
    //    {
    //        status.Defesa_Maxima += 20;
    //        status.Defesa += 20;
    //        GameManager.gameManager.dinheiroJogador -= 100;
    //        barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
    //        DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
    //        defesa2.GetComponentInChildren<Text>().text = "X";
    //        defesa3.gameObject.SetActive(true);
    //    }
    //}
    //public void EvoluirDefesa30()
    //{
    //    if (GameManager.gameManager.dinheiroJogador >= preco3 && defesa3.GetComponentInChildren<Text>().text != "X")
    //    {
    //        status.Defesa_Maxima += 30;
    //        status.Defesa += 30;
    //        GameManager.gameManager.dinheiroJogador -= 150;
    //        barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
    //        DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
    //        defesa3.GetComponentInChildren<Text>().text = "X";
    //        defesa4.gameObject.SetActive(true);
    //    }
    //}
    //public void EvoluirDefesa40()
    //{
    //    if (GameManager.gameManager.dinheiroJogador >= preco4 && defesa4.GetComponentInChildren<Text>().text != "X")
    //    {
    //        status.Defesa_Maxima += 40;
    //        status.Defesa += 40;
    //        GameManager.gameManager.dinheiroJogador -= 200;
    //        barras.AtualizaDinheiro(GameManager.gameManager.dinheiroJogador);
    //        DinheiroFerreiro.dinheiroTxt.text = GameManager.gameManager.dinheiroJogador.ToString();
    //        defesa4.GetComponentInChildren<Text>().text = "X";
    //    }
    //}

}
