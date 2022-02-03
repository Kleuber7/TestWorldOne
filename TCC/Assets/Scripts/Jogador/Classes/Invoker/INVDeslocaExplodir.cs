using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INVDeslocaExplodir : OBJDesloca
{
    [SerializeField] private INVExplosivo scriptDeExplosao;
    [SerializeField] public bool explodindo;
    public Collider[] inimigosAtingidos;

    private void Update() 
    {
        if(explodindo)
        {
            inimigosAtingidos = scriptDeExplosao.inimigosAtingidos;
            for(int i = 0; i < inimigosAtingidos.Length; i++)
            {
                if(inimigosAtingidos[i].gameObject.tag == "Inimigo")
                {
                    objeto = inimigosAtingidos[i].gameObject;
                    direcaoDeslocar = (objeto.transform.position - this.gameObject.transform.position);
                    direcaoDeslocar.y = Mathf.Sqrt((forcaStun / 2) * -2 * INIMovimento.gravidade * Time.deltaTime);
                    StartCoroutine(objeto.GetComponent<INIMovimento>().Stunado(tempoStun - 0.1f));
                    StartCoroutine(Descolca(objeto, direcaoDeslocar));
                    desloca = true;
                }
            }
            explodindo = false;
        }

        if(desloca)
        {
            if(tempoStunContador > 0)
            {
                Deslocar(objeto, direcaoDeslocar);
            }
            else
            {
                tempoStunContador = tempoStun;
                Destroy(this.gameObject);
            }
        }    
    }
}
