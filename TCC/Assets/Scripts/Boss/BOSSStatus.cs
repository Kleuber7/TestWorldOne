using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSStatus : BASEStatus
{
    public float velocidade;
    public bool enfurecido;
    public float danoAtaqueBasico;
    public FSMBoss fsm;
    public GameObject entidade;

    private void FixedUpdate() 
    {
        if(vida <= 0)
        {
            StartCoroutine(DelayMorte());
        }   
    }

    public IEnumerator DelayMorte()
    {
        fsm.ChangeAnimationState(fsm.Morte());
        yield return new WaitForSeconds(6);
        Morrer();
    }

    public override void Morrer()
    {
        entidade.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }
}
