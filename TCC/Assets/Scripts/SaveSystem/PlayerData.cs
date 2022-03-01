using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public float health;
    public float money;
    public float Mana;
    public float defense;
    public float attack;
    public float speed;
    public float[] position;


    public PlayerData(SaveManager player)
    {
        health = player.player.health;
        money = GameManager.gameManager.dinheiroJogador;
        Mana = player.player.Mana;
        defense = player.player.defense;
        attack = player.player.attack;
        speed = player.player.speed;

    }

    #region
    //position = new float[3];

    //position[0] = player.transform.position.x;
    //position[1] = player.transform.position.y;
    //position[2] = player.transform.position.z;
    #endregion
}