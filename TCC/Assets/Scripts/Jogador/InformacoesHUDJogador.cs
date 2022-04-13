using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformacoesHUDJogador : MonoBehaviour
{
    public Slider sliderVida, sliderMana;
    public Text dinheiroTxt;
    public float dinheiroP;
    public ScriptablePlayer status;

    //public Gradient gradient;
    //public Image fill;

    //private void Start()
    //{
        
    //    StartCoroutine(ChamaRefs());
    //}

    //IEnumerator ChamaRefs()
    //{
    //    yield return new WaitForSeconds(.5f);
        
    //    dinheiroTxt = GameObject.Find("Valor").GetComponent<Text>();
    //    sliderVida = GameObject.Find("HealthBar").GetComponent<Slider>();
    //    sliderMana = GameObject.Find("ManaBar").GetComponent<Slider>();

    //}

    private void LateUpdate() 
    {
        dinheiroTxt.text = status.money.ToString();
        sliderVida.value = ((status.health * 100) / status.maxHealth);
        sliderMana.value = ((status.Mana * 100) / status.maxMana);
    }


    //public void AtualizaDinheiro(float dinheiro)
    //{
    //    dinheiroTxt.text = dinheiro.ToString();
    //}

    //public void MaximoVida(float vida)
    //{
    //    sliderVida.maxValue = vida;
    //    sliderVida.value = vida;
    //    //Se quiser gradiante na vida
    //   //fill.color =  gradient.Evaluate(slider.normalizedValue);

    //}

    //public void MaximoMana(float mana)
    //{
    //    sliderMana.maxValue = mana;
    //    sliderMana.value = mana;
    //}

    public void SetMana(float mana)
    {
        sliderMana.value = mana;
    }

    public void SetHealth(float vida)
    {
        sliderVida.value = vida;
    }
}
