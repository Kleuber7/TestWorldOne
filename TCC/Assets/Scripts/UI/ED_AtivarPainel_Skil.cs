using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ED_AtivarPainel_Skil : MonoBehaviour
{

    public GameObject   Painel_Necro,
                        Painel_Metamorfo,
                        Painel_Invoker,
                        Classe;
    // Start is called before the first frame update
    void Start()
    {
        /*
        Painel_Necro = GameObject.Find("Skill Necro");
        Painel_Necro.SetActive(false);*/
    }
    public void Ativar_Painel()
    {
        Classe = GameObject.Find("Necromante/Invoker");

        if(Classe)
        {
            Painel_Necro.SetActive(true);
        }
    }
}
