using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AtaqueBasico : MonoBehaviour
{
    [SerializeField] private Collider[] areaDeAtaque;
    [SerializeField] public int contadorCombo;
    [SerializeField] private float tempoCombo;
    [SerializeField] private float duracaoAtaque;
    [SerializeField] private AtaqueADistancia scrpitDeAtaqueADistancia;
    private bool combo;
    [SerializeField]private bool podeAtacar = true;
    [SerializeField] private FSMJogador animacaoJogador;
    [SerializeField] private ParticleManagerAttack attackEffect;
    Andar andar;


    private void Start()
    {
        andar = GetComponent<Andar>();
    }

    private void Update() 
    {
        //if(scrpitDeAtaqueADistancia.ataqueADistancia)
        //{
        //    podeAtacar = false;
        //}
        //else
        //{
        //    podeAtacar = true;
        //}

        if(contadorCombo >= areaDeAtaque.Length)
        {
            contadorCombo = 0;
        }
       
        if (Input.GetMouseButtonDown(0))
        {
            if (podeAtacar == true)
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity) && Vector3.Distance(transform.position, hit.point) > 5f)
                {
                    andar.direcaoRotacao = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                    transform.LookAt(andar.direcaoRotacao);

                }

                GameManager.gameManager.atacando = true;
                areaDeAtaque[contadorCombo].enabled = true;
                StopAllCoroutines();
                
                StartCoroutine(expiraCombo());
                StartCoroutine(CDAtaque());

                if (contadorCombo == 0)
                {
                    StartCoroutine(Effect1());
                    StartCoroutine(PlayAnimationOne());
                }
                else if (contadorCombo == 1)
                {
                    StartCoroutine(Effect2());
                    animacaoJogador.ChangeAnimationState(animacaoJogador.Bater2());
                }
                else if (contadorCombo == 2)
                {
                    StartCoroutine(Effect3());
                    animacaoJogador.ChangeAnimationState(animacaoJogador.Bater3());
                }
                if (combo)
                {
                    contadorCombo++;
                }
            }
        }
    }

    IEnumerator Effect1()
    {
        yield return new WaitForSeconds(0.2f);
        attackEffect.PlayParticleAttack();
    }
    IEnumerator Effect2()
    {
        yield return new WaitForSeconds(0.4f);
        attackEffect.PlayParticleAttack();
    }
    IEnumerator Effect3()
    {
        yield return new WaitForSeconds(0.15f);
        attackEffect.PlayParticleAttack();
    }
    IEnumerator PlayAnimationOne()
    {
        animacaoJogador.ChangeAnimationState(animacaoJogador.Bater1());
        float attackDelay = animacaoJogador.jogadorAnima.GetCurrentAnimatorStateInfo(0).normalizedTime;
        yield return new WaitForSeconds(attackDelay);
        animacaoJogador.ChangeAnimationState(animacaoJogador.Bater1Prox());

    }


    public void DesativarAtaque()
    {
        podeAtacar = false;
    }
    public void AtivarAtaque()
    {
        podeAtacar = true;
    }
    IEnumerator expiraCombo()
    {
        combo = true;
        yield return new WaitForSeconds(tempoCombo);
        combo = false;
        contadorCombo = 0;
    }

    public IEnumerator CDAtaque()
    {

        podeAtacar = false;
        yield return new WaitForSeconds(duracaoAtaque);
        podeAtacar = true;
        //GetComponent<FSMJogador>().NBater();
        GameManager.gameManager.atacando = false;
    }
}
