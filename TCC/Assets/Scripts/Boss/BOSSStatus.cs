using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSStatus : BASEStatus
{
    public float velocidade;
    public bool enfurecido;
    public float danoAtaqueBasico;

    private void FixedUpdate() 
    {
        if(vida <= 0)
        {
            StartCoroutine(DelayMorte());
        }   
    }

    public IEnumerator DelayMorte()
    {
        yield return new WaitForSeconds(3);
        Morrer();
    }

    public override void Morrer()
    {
        GameObject.Find("Controlador").GetComponent<GameManager>().load.Carregar_CenaInicio(1);

        Destroy(this.gameObject);
    }
}
