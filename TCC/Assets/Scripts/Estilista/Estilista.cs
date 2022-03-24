using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estilista : MonoBehaviour
{
    [SerializeField] private GameObject stylistCanvas;
    [SerializeField] private ScriptablePlayer status;
    [SerializeField] private Jogador_Status skinStatus;
    [SerializeField] private FSMJogador animaPlayer;
    [SerializeField] private bool canOpen;


    private void Update()
    {
        

        if (canOpen)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                stylistCanvas.SetActive(true);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            animaPlayer = other.GetComponent<FSMJogador>();
            skinStatus = other.GetComponent<Jogador_Status>();
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
        }
    }

    public void ChangeSkin(int skin)
    {
        if(skin == (int)Skin.Default)
        {
            status.skin = Skin.Default;
            skinStatus.skin[(int)Skin.Fire].SetActive(false);
            skinStatus.skin[((int)status.skin)].SetActive(true);
            animaPlayer.jogadorAnima = skinStatus.skin[((int)status.skin)].GetComponent<Animator>();
        }
        else if(skin == (int)Skin.Fire)
        {
            status.skin = Skin.Fire;
            skinStatus.skin[(int)Skin.Default].SetActive(false);
            skinStatus.skin[((int)status.skin)].SetActive(true);
            animaPlayer.jogadorAnima = skinStatus.skin[((int)status.skin)].GetComponent<Animator>();
        }

    }

   
}
