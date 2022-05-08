using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Skin {Default, Mahou, Emissario, Pesadelo, Abobora};
[CreateAssetMenu]
public class ScriptablePlayer : ScriptableObject
{
    public float health, maxHealth;
    public float money;
    public int qntdPotionVida;
    public int qntdPotionMana;
    public float Mana, maxMana;
    public float defense, maxDefense;
    public float attack, maxAttack;
    public float speed, maxSpeed;
    public float ExtraLife;
    public int levelVida, levelMana, levelAtaque, levelDefesa;
    public float initialMoney;
    public Skin skin;
    public bool moneyHUD;
    public int moneyEarn;
    public bool FirstTime;
}