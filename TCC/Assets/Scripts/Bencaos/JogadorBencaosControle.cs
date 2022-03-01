using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorBencaosControle : MonoBehaviour
{
    
    [SerializeField] private SunFire sunfire;
    [SerializeField] private Congelar congelar;
    [SerializeField] private Dash dash;
    [SerializeField] private Camuflagem camuflagem;
    [SerializeField] private ColisorSunFire colisorS;
    [SerializeField] private FontedeVida fontedeVida;
    [SerializeField] private ScriptablePlayer status;
    public void Congelar()
    {
        congelar.enabled = true;
        Time.timeScale = 1;
        TooltipSystem.Hide();
    }
    public void SunFire()
    {
        colisorS.AtivarColisor();
        sunfire.enabled = true;
        Time.timeScale = 1;
        TooltipSystem.Hide();
    }
    
    public void Reviver()
    {
        status.ExtraLife += 1;
        Time.timeScale = 1;
        TooltipSystem.Hide();
    }

    public void FontedeVida()
    {
        fontedeVida.enabled = true;
        Time.timeScale = 1;
        TooltipSystem.Hide();
    }
    public void Camuflagem()
    {
        camuflagem.enabled = true;
        Time.timeScale = 1;
        TooltipSystem.Hide();
    }
   
}
