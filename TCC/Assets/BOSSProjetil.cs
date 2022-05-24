using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSProjetil : MonoBehaviour
{
    [SerializeField] private float velocidadeDisparo;
    [SerializeField] private float danoDisparo;
    [SerializeField] public Vector3 direcao;
    [SerializeField] public bool atirou = false;

    private void Start() 
    {
        StartCoroutine(Expira());
    }

    private void Update() 
    {
        if(atirou)
        {
            Desloca();
        }   
    }

    public void Desloca()
    {
        this.gameObject.transform.Translate(direcao.normalized * Time.deltaTime * velocidadeDisparo, Space.World);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player" && !Jogador_Status.morreu)
        {
            if (!PLASkills.castingSkill)
                other.GetComponent<FSMJogador>().ChangeAnimationState(other.GetComponent<FSMJogador>().TomarDano());
            other.GetComponent<AtaqueBasico>().ManageDamage();
            other.GetComponent<Jogador_Status>().TomarDano(danoDisparo);
            Destroy(this.gameObject);
        }
    }

    public IEnumerator Expira()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
