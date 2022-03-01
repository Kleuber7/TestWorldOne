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
    public float ExtraLife;
    public int levelVida, levelMana, levelAtaque, levelDefesa;

    public PlayerData(SaveManager player)
    {
        health = player.player.health;
        money = player.player.money;
        Mana = player.player.Mana;
        defense = player.player.defense;
        attack = player.player.attack;
        speed = player.player.speed;
        maxHealth = player.player.maxHealth;
        maxMana = player.player.maxMana;
        maxDefense = player.player.maxDefense;
        maxAttack = player.player.maxAttack;
        maxSpeed = player.player.maxSpeed;
        ExtraLife = player.player.ExtraLife;
        levelVida = player.player.levelVida;
        levelMana = player.player.levelMana;
        levelAtaque = player.player.levelAtaque;
        levelDefesa = player.player.levelDefesa;

    }



    #region
    //position = new float[3];

    //position[0] = player.transform.position.x;
    //position[1] = player.transform.position.y;
    //position[2] = player.transform.position.z;
    #endregion
}