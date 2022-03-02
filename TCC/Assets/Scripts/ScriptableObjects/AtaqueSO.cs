using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Ataque", menuName = "Ataque")]
public class AtaqueSO : ScriptableObject
{
    public Sprite arteAtaque;
    public int preco;
    public int powerUp;
    public string descricao; 
}
