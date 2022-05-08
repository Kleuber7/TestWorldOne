using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estilista : MonoBehaviour
{
    [SerializeField] public GameObject stylistCanvas;
    [SerializeField] private ScriptablePlayer status;
    [SerializeField] private Jogador_Status skinStatus;
    [SerializeField] private FSMJogador animaPlayer;
    [SerializeField] private bool canOpen;


   
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            animaPlayer = other.GetComponent<FSMJogador>();
            skinStatus = other.GetComponent<Jogador_Status>();
        }
    }

   

    public void ChangeSkin(int skin)
    {
        if(skin == (int)Skin.Default)
        {
            status.skin = Skin.Default;
            skinStatus.AtivaDefault();
            animaPlayer.jogadorAnima = skinStatus.skin[((int)status.skin)].GetComponent<Animator>();
        }
        else if(skin == (int)Skin.Mahou)
        {
            status.skin = Skin.Mahou;
            skinStatus.AtivaMahou();
            animaPlayer.jogadorAnima = skinStatus.skin[((int)status.skin)].GetComponent<Animator>();
        }
        else if (skin == (int)Skin.Emissario)
        {
            status.skin = Skin.Emissario;
            skinStatus.AtivaEmissario();
            animaPlayer.jogadorAnima = skinStatus.skin[((int)status.skin)].GetComponent<Animator>();
        }
        else if (skin == (int)Skin.Pesadelo)
        {
            status.skin = Skin.Pesadelo;
            skinStatus.AtivaPesadelo();
            animaPlayer.jogadorAnima = skinStatus.skin[((int)status.skin)].GetComponent<Animator>();
        }
        else if (skin == (int)Skin.Abobora)
        {
            status.skin = Skin.Abobora;
            skinStatus.AtivaAbobora();
            animaPlayer.jogadorAnima = skinStatus.skin[((int)status.skin)].GetComponent<Animator>();
        }
    }

   
}
