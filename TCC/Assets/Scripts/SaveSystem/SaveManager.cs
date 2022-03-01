using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public ScriptablePlayer player;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {

        PlayerData data = SaveSystem.LoadPlayer();

        player.health = data.health;
        player.money = data.money;
        player.Mana = data.Mana;
        player.defense = data.defense;
        player.attack = data.attack;
        player.speed = data.speed;
        player.maxHealth = data.maxHealth;
        player.maxMana = data.maxMana;
        player.maxDefense = data.maxDefense;
        player.maxAttack = data.maxAttack;
        player.maxSpeed = data.maxSpeed;
        player.ExtraLife = data.ExtraLife;
        player.levelVida = data.levelVida;
        player.levelMana = data.levelMana;
        player.levelAtaque = data.levelAtaque;
        player.levelDefesa = data.levelDefesa;
        player.initialMoney = data.initialMoney;
    }

    #region
    //Vector3 position;
    //position.x = data.position[0];
    //position.y = data.position[1];
    //position.z = data.position[2];
    //transform.position = position;
    #endregion
}