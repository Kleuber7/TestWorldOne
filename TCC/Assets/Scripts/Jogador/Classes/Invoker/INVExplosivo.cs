using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INVExplosivo : INVAliado
{
    //[SerializeField] private float danoDaExplosao;
    //[SerializeField] private float tempoDaExplosao;
    //[SerializeField] private LayerMask layerDaExplosao;
    //[SerializeField] private Transform centroDaExplosao;
    //[SerializeField] private float alcanceDaExplosao;
    //public Collider[] inimigosAtingidos;
    //private bool podeExplodir;
    //[SerializeField] INVDeslocaExplodir scriptDeDeslocar;

    //private void Start() 
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");

    //    StartCoroutine(TempoDeVida());      
    //}

    //private void Update() 
    //{
    //    if(alvo != null && alvo.gameObject.tag == "Inimigo")
    //    {
    //        if(Vector3.Distance(transform.position, alvo.transform.position) <= alcanceDaExplosao)
    //        {
    //            StartCoroutine(CarregaExplodir());
    //        }
    //    }
    //    // else
    //    // {
    //    //     SetAlvo();
    //    // }
    //}

    //private void OnTriggerStay(Collider other) 
    //{
    //    if(other.gameObject.tag == "Inimigo")
    //    {
    //        if(alvo == null || alvo == player)
    //        {
    //            alvo = other.gameObject;
    //        }
    //    }
    //}

    //public void Explosao()
    //{
    //    inimigosAtingidos = Physics.OverlapSphere(centroDaExplosao.position, alcanceDaExplosao, layerDaExplosao);
    //    scriptDeDeslocar.explodindo = true;

    //    for(int i = 0; i < inimigosAtingidos.Length; i++)
    //    {
    //        if(inimigosAtingidos[i] != null)
    //        {
    //            if(inimigosAtingidos[i].tag == "Inimigo")
    //            {
    //                inimigosAtingidos[i].gameObject.GetComponent<INIStatus>().TomarDano(danoDaExplosao);
    //            }
    //        }
    //    }

    //    Destroy(this.gameObject);
    //}

    //IEnumerator CarregaExplodir()
    //{
    //    yield return new WaitForSeconds(tempoDaExplosao);
    //    Explosao();
    //}
}
