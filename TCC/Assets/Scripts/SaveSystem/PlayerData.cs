using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public float health, maxHealth;
    public float money;
    public float Mana, maxMana;
    public float defense, maxDefense;
    public float attack, maxAttack;
    public float speed, maxSpeed;

    public PlayerData(SaveManager player)
    {
        health = player.player.health;
        money = GameManager.gameManager.dinheiroJogador;
        Mana = player.player.Mana;
        defense = player.player.defense;
        attack = player.player.attack;
        speed = player.player.speed;
        maxHealth = player.player.maxHealth;
        maxMana = player.player.maxMana;
        maxDefense = player.player.maxDefense;
        maxAttack = player.player.maxAttack;
        maxSpeed = player.player.maxSpeed;
    }

    #region
    //position = new float[3];

    //position[0] = player.transform.position.x;
    //position[1] = player.transform.position.y;
    //position[2] = player.transform.position.z;
    #endregion
}