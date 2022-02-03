using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    public float moedas;
    public Text moedasTxt;

    void Start()
    {
        moedasTxt.text = "Moedas:" + moedas.ToString();

        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Preço
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;

        //Quantidade
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
    }

    
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Evento").GetComponent<EventSystem>().currentSelectedGameObject;

        if (moedas >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            moedas -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().itemID]++;

            moedasTxt.text = "Moedas:" + moedas.ToString();
            ButtonRef.GetComponent<ButtonInfo>().quantidadeTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().itemID].ToString();
        }
    }
}
