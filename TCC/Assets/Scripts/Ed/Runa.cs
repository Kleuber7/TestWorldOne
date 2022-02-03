using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runa : MonoBehaviour
{

    [Range(0,15)]
    public float Coldow_Runa;
    public bool Habiliade_Livre;
    public Jogador_Status Mana;
    public Runa_Reviver Runa_1;
    public Runa_Curar Runa_2;
    public Runa_Explosao Runa_3;
    public Runa_Colossus Runa_4;
    
    public List<GameObject> Lista_Invocacao;


    void Start()
    {
        Habiliade_Livre = true;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && Habiliade_Livre == true && Mana.Mana >= 10)
        {
            Debug.Log("Entrei f1");
            Mana.Mana -= 10;
            Runa_1.Acionar_Nevoa();
            StartCoroutine(Coldow_Runas());
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && Habiliade_Livre == true && Mana.Mana >= 10)
        {
            Debug.Log("Entrei f2");
            Mana.Mana -= 10;
            Runa_2.Curar();
            StartCoroutine(Coldow_Runas());
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && Habiliade_Livre == true && Mana.Mana >= 10)
        {
            Debug.Log("Entrei f3");
            Mana.Mana -= 10;
            Runa_3.Jogar_Esqueleto();
            StartCoroutine(Coldow_Runas());
        }
        if(Input.GetKeyDown(KeyCode.Alpha4) && Habiliade_Livre == true && Mana.Mana >= 10)
        {
            Debug.Log("Entrei f4");
            Mana.Mana -= 10;
            Runa_4.Invocar_Colossus();
            StartCoroutine(Coldow_Runas());
        }
    }
    IEnumerator Coldow_Runas()
    {
        Habiliade_Livre = false;
        yield return new WaitForSeconds(Coldow_Runa);
        Habiliade_Livre = true;
    }


}
