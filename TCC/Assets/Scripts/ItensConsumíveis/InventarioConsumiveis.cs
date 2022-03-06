using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioConsumiveis : MonoBehaviour
{
    public Image artePotionVidaUI;
    public Image artePotionManaUI;
    public int qntdPotionVida;
    public int qntdPotionMana;
    public Text textoQntdPotionVida;
    public Text textoQntdPotionMana;
    public PotionVidaSO potionVidaSO;
    public PotionManaSO potionManaSO;
    public ScriptablePlayer status;

    private void Start() 
    {
        artePotionVidaUI.sprite = potionVidaSO.arte;
        artePotionVidaUI.preserveAspect = true;
        artePotionManaUI.sprite = potionManaSO.arte;
        artePotionManaUI.preserveAspect = true;
        qntdPotionVida = status.qntdPotionVida;
        textoQntdPotionVida.text = qntdPotionVida.ToString();
        qntdPotionMana = status.qntdPotionMana;
        textoQntdPotionMana.text = qntdPotionMana.ToString();
    }

    private void FixedUpdate() 
    {
        if(status.qntdPotionVida <= 0)
        {
            qntdPotionVida = 0;
            textoQntdPotionVida.text = qntdPotionVida.ToString();
            artePotionVidaUI.gameObject.SetActive(false);
        }
        else
        {
            qntdPotionVida = status.qntdPotionVida;
            artePotionVidaUI.gameObject.SetActive(true);
            textoQntdPotionVida.text = qntdPotionVida.ToString();
        }

        if(status.qntdPotionMana <= 0)
        {
            qntdPotionMana = 0;
            textoQntdPotionMana.text = qntdPotionMana.ToString();
            artePotionManaUI.gameObject.SetActive(false);
        }
        else
        {
            qntdPotionMana = status.qntdPotionMana;
            artePotionManaUI.gameObject.SetActive(true);
            textoQntdPotionMana.text = qntdPotionMana.ToString();
        }
    }
}
