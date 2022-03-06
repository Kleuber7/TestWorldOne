using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionVida : MonoBehaviour
{
    public ScriptablePlayer statusJogador;
    public Jogador_Status status;
    public PotionVidaSO potionVidaSO;
    public KeyCode teclaPotionVida;
    public InventarioConsumiveis inventarioConsumiveis;

    private void Update() 
    {
        if(!status.morreu)
        {
            if(inventarioConsumiveis.qntdPotionVida > 0)
            {
                if(Input.GetKeyDown(teclaPotionVida))
                {
                    UsaPotionVida();
                }
            }
        }
    }

    public void UsaPotionVida()
    {
        if(statusJogador.health + potionVidaSO.quantidadeCura > statusJogador.maxHealth)
        {
            statusJogador.health = statusJogador.maxHealth;
        }
        else
        {
            statusJogador.health += potionVidaSO.quantidadeCura;
        }
        statusJogador.qntdPotionVida--;
    }
}
