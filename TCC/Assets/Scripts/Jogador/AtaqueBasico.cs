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
    [SerializeField]private bool podeAtacar = true;
    [SerializeField] private FSMJogador animacaoJogador;
    Andar andar;
    [SerializeField] private List<float> duracaoAtaques;

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
                    animacaoJogador.ChangeAnimationState(animacaoJogador.Bater1());
                }
                else if (contadorCombo == 1)
                {
                    animacaoJogador.ChangeAnimationState(animacaoJogador.Bater2());
                }
                else if (contadorCombo == 2)
                {
                    animacaoJogador.ChangeAnimationState(animacaoJogador.Bater3());
                }
                else if (contadorCombo == 3)
                {
                    animacaoJogador.ChangeAnimationState(animacaoJogador.Bater4());
                }
                else if (contadorCombo == 4)
                {
                    animacaoJogador.ChangeAnimationState(animacaoJogador.Bater5());
                }
                else if (contadorCombo == 5)
                {
                    animacaoJogador.ChangeAnimationState(animacaoJogador.Bater6());
                }
                if (combo)
                {
                    contadorCombo++;
                }
            }
        }
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
        GameManager.gameManager.atacando = false;
    }
}
