using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estilista : MonoBehaviour
{
    [SerializeField] private GameObject stylistCanvas;
    [SerializeField] private ScriptablePlayer status;
    [SerializeField] private Jogador_Status skinStatus;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            skinStatus = other.GetComponent<Jogador_Status>();

            if (Input.GetKeyDown(KeyCode.R))
            {
                stylistCanvas.SetActive(true);
            }
        }
    }


    public void ChangeSkin(int skin)
    {
        if(skin == (int)Skin.Default)
        {
            status.skin = Skin.Default;
            skinStatus.skin[(int)Skin.Fire].SetActive(false);
            skinStatus.skin[((int)status.skin)].SetActive(true);
        }
        else if(skin == (int)Skin.Fire)
        {
            status.skin = Skin.Fire;
            skinStatus.skin[(int)Skin.Default].SetActive(false);
            skinStatus.skin[((int)status.skin)].SetActive(true);
        }

    }

   
}
