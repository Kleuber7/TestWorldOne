using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaInfo : MonoBehaviour
{
    public GameObject imagemInfo;

    public void AtivaDesativa()
    {
        if(imagemInfo.activeSelf == false)
        {
            imagemInfo.SetActive(true);
        }
        else
        {
            imagemInfo.SetActive(false);
        }
    }
}
