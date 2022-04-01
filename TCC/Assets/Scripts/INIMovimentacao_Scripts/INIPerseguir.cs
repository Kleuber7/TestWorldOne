using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class INIPerseguir : MonoBehaviour
{
    [SerializeField] public Transform alvo;
    [SerializeField] float velocidade;
    [SerializeField] public float velocidadeDeAtaque, velocidadeAtaqueOriginal;
    [SerializeField] private Transform inimigo;
    [SerializeField] private bool perseguir = false;
    [SerializeField] private bool atacando = false;
    [SerializeField] private float distanciaParar;
    [SerializeField] public float areaVisao;
    [SerializeField] private INIStatus status;
    [SerializeField] private bool podeDardano = true;
    [SerializeField] private EsquivaOfensiva esquiva;
    [SerializeField] private GameObject prefabProjetil;
    [SerializeField] private Transform pontoDeTiro;
    [SerializeField] private INITiro tiro;
    [SerializeField] private INIPatrulha scriptPatrulha;
    [SerializeField] private FSMInimigos iniAnima;
    [SerializeField] private Collider areaDoAtaque;
    [SerializeField] public bool finishAnimation = true;
    [SerializeField] public bool takingDamage = false;
    [SerializeField] private float timeAnimation;
    [SerializeField] private float timeTakeDamage;
    [SerializeField] private float timeTakeDamageIndividual = 2f;
    [SerializeField] public bool superArmor = false;
    [SerializeField] private Crew crew;
    [SerializeField] public bool inCrew = false;

    private void Start()
    {
        iniAnima = GetComponentInParent<FSMInimigos>();
        esquiva = GameObject.FindGameObjectWithTag("Player").GetComponent<EsquivaOfensiva>();
        velocidadeAtaqueOriginal = velocidadeDeAtaque;
    }

    private void Update()
    {
        TakeDamage();
    }
    private void FixedUpdate()
    {

        if (perseguir)
        {
            scriptPatrulha.SetPatrulha(false);

            if (!atacando)
            {
                Vector3 direcaoRotacao = new Vector3(alvo.position.x, inimigo.position.y, alvo.position.z);
                inimigo.transform.LookAt(direcaoRotacao);
            }

            if (Vector3.Distance(transform.position, alvo.position) > distanciaParar && !status.GetStunado() && !Jogador_Status.Invisivel && !atacando && finishAnimation)
            {
                iniAnima.ChangeAnimationState(iniAnima.Perseguindo());
                inimigo.position = Vector3.MoveTowards(inimigo.position, new Vector3(alvo.position.x, inimigo.position.y, alvo.position.z), velocidade * Time.deltaTime);
            }
            else if (Vector3.Distance(transform.position, alvo.position) <= distanciaParar && !status.GetStunado() && !Jogador_Status.Invisivel)
            {

                if (!atacando && !takingDamage)
                {
                    if (distanciaParar < 25)
                    {
                        StopCoroutine(DanoInimigo());
                        StartCoroutine(DanoInimigo());
                    }
                    else
                    {
                        if (!takingDamage)
                        {
                            StopCoroutine(AtiraProjetil());
                            StartCoroutine(AtiraProjetil());
                        }
                    }
                }
            }

            crew.CheckCrew();
        }
        else
        {
            if (!scriptPatrulha.despertando && !inCrew)
            {
                scriptPatrulha.SetPatrulha(true);
            }
        }
    }

    // private void OnTriggerEnter(Collider other) 
    // {
    //     if(other.gameObject.tag == "Player")
    //     {
    //         Debug.Log("player entrou");
    //         alvo = other.gameObject;
    //         Perseguir();
    //     }
    // }

    //Está utilizando "OnTriggerStay" porque o "OnTriggerEnter" por algum motivo não funciona. - Ian
    private void OnTriggerStay(Collider other)
    {
        if (alvo == null && other.gameObject.tag == "Player")
        {
            alvo = other.gameObject.transform;
            Perseguir();

            crew.CallCrew(alvo);
        }
    }

    public void DiminuirVelocidadeAtaque()
    {
        velocidadeDeAtaque /= 2;
    }

    public void AjustarVelocidadeAtaque()
    {
        velocidadeAtaqueOriginal = velocidadeDeAtaque;
    }

    public void Perseguir()
    {
        perseguir = true;
    }

    public void NaoPerseguir()
    {
        perseguir = false;
        alvo = null;
        atacando = false;
    }
    public bool GetPerseguir()
    {
        return perseguir;
    }

    public bool GetAtacando()
    {
        return atacando;
    }

    IEnumerator DanoInimigo()
    {
        finishAnimation = false;
        atacando = true;

        iniAnima.ChangeAnimationState("");
        iniAnima.ChangeAnimationState(iniAnima.Atacar());

        yield return new WaitForSecondsRealtime(1 / velocidadeDeAtaque);
        timeAnimation = iniAnima.InimigoAnima.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (alvo != null)
        {
            if (EsquivaOfensiva.esquivar == true)
            {
                EsquivaOfensiva.Esquivou();
            }
            else if (alvo.gameObject.tag == "Player" && !takingDamage)
            {

                //GetComponentInParent<FSMInimigos>().Atacar();
                areaDoAtaque.gameObject.SetActive(true);
            }
        }
        GetAnimationState();
        StartCoroutine(ResetaAtaque());
    }


    void TakeDamage()
    {
        if (timeTakeDamage <= 0)
        {
            takingDamage = false;
            timeTakeDamage = 0;
        }
        else
        {
            timeTakeDamage -= Time.deltaTime;
        }

    }

    public void ManageDamage()
    {
        timeTakeDamage = timeTakeDamageIndividual;
        takingDamage = true;
        StopCoroutine(DanoInimigo());
        StopCoroutine(AtiraProjetil());
    }

    async void GetAnimationState()
    {
        await GetAnimationStateAsync();
        finishAnimation = true;
    }
    async Task GetAnimationStateAsync()
    {
        int delay = (int)timeAnimation;
        await Task.Delay(1000 * delay);

    }

    public IEnumerator ResetaAtaque()
    {
        yield return new WaitForSeconds(.5f);
        atacando = false;
    }

    public IEnumerator AtiraProjetil()
    {
        atacando = true;
        iniAnima.ChangeAnimationState(iniAnima.Iddle());

        yield return new WaitForSecondsRealtime(1 / velocidadeDeAtaque);

        iniAnima.ChangeAnimationState(iniAnima.Atacar());

        if (alvo != null)
        {
            yield return new WaitForSeconds(0.3f);
            tiro = Instantiate(prefabProjetil, pontoDeTiro.position, pontoDeTiro.rotation).GetComponent<INITiro>();
            Vector3 direcaoInimigo = alvo.transform.position - tiro.gameObject.transform.position;
            tiro.direcao = direcaoInimigo;
            tiro.transform.LookAt(alvo);
            tiro.atirou = true;
        }
        atacando = false;
    }


    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanciaParar);
        Gizmos.DrawWireSphere(transform.position, areaVisao);
    }
}
