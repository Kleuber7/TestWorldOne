using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto : MonoBehaviour
{
    public float Dano;
    public Jogador_Habilidades_Magica Jogador;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Perseguir();
    }

    public void Perseguir()
    {
        transform.LookAt(Jogador.Alvo.transform);
        this.gameObject.transform.Translate(transform.forward*1*Time.deltaTime);
    }

    void OnCollisionEnter(Collision Colidiu)
    {
        if(Colidiu.gameObject.tag == "Inimigo")
        {
            GetComponent<INIStatus>().vida -= Dano;
        }
    }
}