using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BASEStatus : MonoBehaviour
{
    public float vida;
    public float vidaMax;

    private void Start() 
    {
        vida = vidaMax;
    }

    private void FixedUpdate() 
    {
        ChecaMorrer();
    }

    void ChecaMorrer()
    {
        if(vida <= 0)
        {
            Morrer();
        }
    }

    public virtual void TomarDano(float dano)
    {
        vida -= dano;
    }

    public virtual void Morrer()
    {
        Destroy(this.gameObject);
    }
}
