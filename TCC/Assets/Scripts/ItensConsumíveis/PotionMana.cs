using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMana : MonoBehaviour
{
    public ScriptablePlayer statusJogador;
    public Jogador_Status status;
    public PotionManaSO potionManaSO;
    public KeyCode teclaPotionMana;
    public InventarioConsumiveis inventarioConsumiveis;

    private void Update() 
    {
        if(!status.morreu)
        {
            if(inventarioConsumiveis.qntdPotionMana > 0)
            {
                if(Input.GetKeyDown(teclaPotionMana))
                {
                    UsaPotionMana();
                }
            }
        }
    }

    public void UsaPotionMana()
    {
        if(statusJogador.Mana + potionManaSO.quantidadeCura > statusJogador.maxMana)
        {
            statusJogador.Mana = statusJogador.maxMana;
        }
        else
        {
            statusJogador.Mana += potionManaSO.quantidadeCura;
        }
        statusJogador.qntdPotionMana--;
    }
}
