using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliado : MonoBehaviour
{
    public GameObject Classe;
    public Jogador_Habilidades_Magica Lista;
    public float Vida; 
    // Start is called before the first frame update
    void Start()
    {
        Vida = 100;
        Classe = GameObject.Find("Necromante/Invoker");
        Lista = Classe.GetComponent<Jogador_Habilidades_Magica>();
        Lista.Lista_Invocacao.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
