using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PotionVida", menuName = "PotionVida")]
public class PotionVidaSO : ScriptableObject
{
    public int quantidadeCura;
    public int preco;
    public Sprite arte;
    public string descricao;
}
