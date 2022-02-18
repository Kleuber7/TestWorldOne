using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionamentoInicial : MonoBehaviour
{
    [SerializeField] private Transform posicaoInicial;
    private bool spawnou;


    private void Update()
    {
        Posiciona();
    }
    public void Posiciona()
    {
        if (Teleporting.podeExcluirP)
        {
            Destroy(posicaoInicial.gameObject);
        }

        if (posicaoInicial == null || Teleporting.podeExcluirP)
        {
            if (GameManager.gameManager.teleportando)
            {
                posicaoInicial = GameObject.FindGameObjectWithTag("PontoInicialTeleport").transform;
                if (Vector3.Distance(transform.position, posicaoInicial.position) > .1f)
                {

                    this.gameObject.transform.position = posicaoInicial.transform.position;
                    this.gameObject.transform.rotation = posicaoInicial.transform.rotation;

                    
                }
            }
            GameManager.gameManager.teleportando = true;
        }
        else
        {
            GameManager.gameManager.teleportando = false;
        }

       
    }

    IEnumerator Check()
    {
        yield return new WaitForSeconds(0.5f);

        if(Vector3.Distance(transform.position, posicaoInicial.position) > .1f)
        {
            this.gameObject.transform.position = posicaoInicial.transform.position;
            this.gameObject.transform.rotation = posicaoInicial.transform.rotation;
        }
    }
}
