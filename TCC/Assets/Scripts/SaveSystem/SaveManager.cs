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
        GameManager.gameManager.dinheiroJogador = data.money;
        player.Mana = data.Mana;
        player.defense = data.defense;
        player.attack = data.attack;
        player.speed = data.speed;

    }

    #region
    //Vector3 position;
    //position.x = data.position[0];
    //position.y = data.position[1];
    //position.z = data.position[2];
    //transform.position = position;
    #endregion
}
