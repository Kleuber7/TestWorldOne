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

        GameManager.gameManager.GetPlayer().GetComponent<Jogador_Status>().status.health = GameManager.gameManager.GetPlayer().GetComponent<Jogador_Status>().status.maxHealth;
        GameManager.gameManager.GetPlayer().GetComponent<Jogador_Status>().barras.SetHealth(GameManager.gameManager.GetPlayer().GetComponent<Jogador_Status>().status.health);
        Destroy(this.gameObject);
    }
}
