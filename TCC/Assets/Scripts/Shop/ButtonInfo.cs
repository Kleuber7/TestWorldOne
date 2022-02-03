using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int itemID;
    public Text precoTxt;
    public Text quantidadeTxt;
    public GameObject shopManager;

    void Update()
    {
        precoTxt.text = "preço: $" + shopManager.GetComponent<ShopManagerScript>().shopItems[2, itemID].ToString();
        quantidadeTxt.text = shopManager.GetComponent<ShopManagerScript>().shopItems[3, itemID].ToString();
    }
}
