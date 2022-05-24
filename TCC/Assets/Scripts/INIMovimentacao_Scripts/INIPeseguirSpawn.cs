using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INIPeseguirSpawn : MonoBehaviour
{
    [SerializeField] private GameObject alvo;
    [SerializeField] private float velocidade;
    [SerializeField] public float velocidadeDeAtaque;
    [SerializeField] private Transform inimigo;
    [SerializeField] private bool perseguir = false;
    [SerializeField] private bool atacando = false;
    private float distanciaParar;
    [SerializeField] private INIStatus status;
    [SerializeField] private bool podeDardano = true;

    private void Start() 
    {
        
        distanciaParar = GetComponent<INIStatus>().range;
    }

    private void Update() 
    {
        alvo = GameObject.FindGameObjectWithTag("Aliado");
        if(alvo == null)
        {
            alvo = GameObject.FindGameObjectWithTag("Player");
        }
        
        if(alvo == GameObject.FindGameObjectWithTag("Player") || alvo == GameObject.FindGameObjectWithTag("Aliado"))
        {
            perseguir = true;
        }

        if(perseguir)
        {
            Perseguir();
        }
    }

    void Perseguir()
    {
        if(Vector3.Distance(transform.position, alvo.transform.position) > distanciaParar && !Jogador_Status.Invisivel)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(alvo.transform.position.x, transform.position.y, alvo.transform.position.z), Time.deltaTime * velocidade);
        }
        else if(Vector3.Distance(transform.position, alvo.transform.position) <= distanciaParar && !status.GetStunado() && !Jogador_Status.Invisivel)
        {
            if (!atacando)
            {
                //if (Jogador_Status.podeDarDano)
                //{
                    StartCoroutine(DanoInimigo());
                //}
            }
        }
        if (Jogador_Status.Invisivel)
        {
            NaoPerseguir();
        }
    }

    public void NaoPerseguir()
    {
        perseguir = false;
        alvo = null;
        atacando = false;
    }

    IEnumerator DanoInimigo()
    {
        atacando = true;
        yield return new WaitForSecondsRealtime(1/velocidadeDeAtaque);
       
        if(alvo.gameObject.tag == "Player" && !Jogador_Status.morreu)
        {
            if (!PLASkills.castingSkill)
                alvo.GetComponent<FSMJogador>().ChangeAnimationState(alvo.GetComponent<FSMJogador>().TomarDano());
            alvo.GetComponent<AtaqueBasico>().ManageDamage();
            alvo.GetComponent<Jogador_Status>().TomarDano(status.dano);
        }
        atacando = false;
    }
}
