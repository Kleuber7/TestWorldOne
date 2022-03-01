using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PotionMana", menuName = "PotionMana")]
public class PotionManaSO :ScriptableObject
{
    public int quantidadeCura;
    public int preco;
    public Sprite arte;
    public string descricao;
}
