using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AtaqueBasico : MonoBehaviour
{
    [SerializeField] private Collider[] areaDeAtaque;
    [SerializeField] public int contadorCombo;
    [SerializeField] private float tempoCombo;
    [SerializeField] private AtaqueADistancia scrpitDeAtaqueADistancia;
    private bool combo;
    [SerializeField] private bool podeAtacar = true;
    [SerializeField] private FSMJogador animacaoJogador;
    Andar andar;
    [SerializeField] public List<float> duracaoAtaques;
    [SerializeField] private float timeReturnAnimation = 0.15f;
    [SerializeField] public float respectTime;
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

        if (contadorCombo >= areaDeAtaque.Length)
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
                
                StopAllCoroutines();
                StartCoroutine(expiraCombo());
                StartCoroutine(CDAtaque());
                StartCoroutine(TempoAtaqueAnim());

                if (contadorCombo == 0)
                {

                    StartCoroutine(AttackCollision(contadorCombo, respectTime));
                    animacaoJogador.ChangeAnimationState(animacaoJogador.Bater1());
                }
                else if (contadorCombo == 1)
                {
                    StartCoroutine(AttackCollision(contadorCombo, respectTime));
                    animacaoJogador.ChangeAnimationState(animacaoJogador.Bater2());
                }
                else if (contadorCombo == 2)
                {
                    StartCoroutine(AttackCollision(contadorCombo, respectTime));
                    animacaoJogador.ChangeAnimationState(animacaoJogador.Bater3());
                }
                else if (contadorCombo == 3)
                {
                    StartCoroutine(AttackCollision(contadorCombo, 0.5f));
                    animacaoJogador.ChangeAnimationState(animacaoJogador.Bater4());
                }
               
               
                if (combo)
                {
                    contadorCombo++;
                }
            }
        }
    }

    IEnumerator AttackCollision(int cont, float respectTime)
    {
        yield return new WaitForSeconds(duracaoAtaques[contadorCombo] - respectTime);
        areaDeAtaque[cont].enabled = true;
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
        yield return new WaitForSeconds(tempoCombo + duracaoAtaques[contadorCombo]);
        combo = false;
        contadorCombo = 0;
    }

    public IEnumerator CDAtaque()
    {

        podeAtacar = false;
        yield return new WaitForSeconds(duracaoAtaques[contadorCombo]);
        podeAtacar = true;
    }

    public IEnumerator TempoAtaqueAnim()
    {
        yield return new WaitForSeconds(duracaoAtaques[contadorCombo] + timeReturnAnimation);
        GameManager.gameManager.atacando = false;
    }
}
