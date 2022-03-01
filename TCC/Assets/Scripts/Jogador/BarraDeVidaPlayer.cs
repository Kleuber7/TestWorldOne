using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaPlayer : MonoBehaviour
{
    [SerializeField] private Slider barraDeVida;
    [SerializeField] private ScriptablePlayer scriptDeStatus;

    
    private void Update() 
    {
        barraDeVida.value = ((scriptDeStatus.health * 100) / scriptDeStatus.maxHealth);
    }
}
