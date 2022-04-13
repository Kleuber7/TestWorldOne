using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolver : MonoBehaviour
{
    //[Range(0.0f, 1.0f)]
    //public float dissolverValor = 1;
    //public Renderer render;
    //private Jogador_Status player;
    //private void Start()
    //{
    //    render = GetComponent<Renderer>();
    //    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador_Status>();
        
    //}
    //void Update()
    //{
    //    //if (dissolverValor > 0)
    //    //{

    //    //    StartCoroutine(DissolverSegundos());
    //    //}
    //}

    //public IEnumerator DissolverReviverVolta()
    //{
        

    //    yield return new WaitForSeconds(1.5f);

    //    render.material.SetFloat("_DissolverController", dissolverValor);

    //    dissolverValor += 0.01f;


    //    if (player.VidaExtra == 1)
    //        player.VidaExtra = 0;

    //    else if (player.VidaExtra == 2)
    //        player.VidaExtra = 1;


    //    if (dissolverValor < 0)
    //    {
    //        dissolverValor = 0;
    //    }
    //    else if (dissolverValor > 1)
    //    {
    //        dissolverValor = 1;
    //    }

      
    //}
    //public IEnumerator DissolverReviver()
    //{
        
    //    render.material.SetFloat("_DissolverController", dissolverValor);
    //    dissolverValor -= 0.01f;


    //    yield return new WaitForSeconds(0.5f);


    //    player.Vida = player.Vida_Maxima;


    //    if (player.VidaExtra == 1)
    //        player.VidaExtra = 0;

    //    else if (player.VidaExtra == 2)
    //        player.VidaExtra = 1;


    //    if (dissolverValor < 0)
    //    {
    //        dissolverValor = 0;
    //    }
    //    else if (dissolverValor > 1)
    //    {
    //        dissolverValor = 1;
    //    }

        
    //}

    //public IEnumerator DissolverSegundos()
    //{
    //    render.material.SetFloat("_DissolverController", dissolverValor);
    //    yield return new WaitForSeconds(0.5f);
    //    dissolverValor -= 0.01f;

    //    if(dissolverValor < 0)
    //    {
    //        dissolverValor = 0;
    //    }
    //    else if (dissolverValor > 1)
    //    {
    //        dissolverValor = 1;
    //    }
        
    //}
}
