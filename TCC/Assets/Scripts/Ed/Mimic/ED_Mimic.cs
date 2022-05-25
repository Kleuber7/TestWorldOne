using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ED_Mimic : MonoBehaviour
{
    private float Vida_Atual;
    private float Vida_AntDano;

    [Tooltip("Jogador que e anexado quando o jogador chega no ranged do COLLIDER")]
    public GameObject Alvo;
    [Tooltip("Barra de vida da UI ! deve ser ativada somente com jogador perto!")]
    public GameObject Barra_Vida;
    [Tooltip("Vetor que o mimic deve andar na direção (SEMPRE VAI ESTAR DENTRO DA HIERARQUIA)")]
    public Transform Local_Final;
    [Tooltip("Tempo que deve aguar para o proximo Dash")]
    public float    Proximo_Dash;
    [Tooltip("Velocidade da ação do dash")]
    public float    Velocidade_Dash;
    [Tooltip("Varive que permite ele calcular a rota do proximo dash")]
    public bool Liberado;
    [Tooltip("Controla as animaçoes do MIMIC")]
    public Animator Controlador_Animator;

    public bool Stun;
    public Transform Mimic_Origem;
    public Obj_Dano_Mimic Dano;
    public INIStatus RefVida;
    float Y_Inicial; 
    void Start()
    {
        Y_Inicial = Mimic_Origem.transform.position.y;
        Vida_AntDano = Vida_Atual;
        //Controlador_Animator = this.gameObject.GetComponent<Animator>();
        //Barra_Vida.SetActive(false);
        Liberado = true;
    }
    void Update()
    {
        Vida_Atual = RefVida.vida;
        Controlador_Animator.SetFloat("Vida", Vida_Atual);

        if(Vida_Atual<=0)
        {
            Destroy(this.gameObject,1f);
        }else
        {
            Seguir();
        }

        if(Mimic_Origem.transform.position.y < Y_Inicial)
        {
            Vector3 posicao =  new Vector3(Mimic_Origem.transform.position.x,Y_Inicial,Mimic_Origem.transform.position.z);
            Mimic_Origem.transform.position = posicao;
        }
    }
    private void OnTriggerEnter( Collider Outro)
    {
        if(Outro.gameObject.tag =="Player")
        {
            Controlador_Animator.SetBool("Alvo",true);
            Barra_Vida.SetActive(true);
            Alvo = Outro.gameObject;
        }
    }
    public void Verificar_Dano()
    {
        if(Vida_AntDano!=Vida_Atual)
        {
            Vida_AntDano=Vida_Atual;
            Controlador_Animator.SetBool("Receber Dano", true);
            // aplicar ano que o mimic ira receber aqui !!!!
            Controlador_Animator.SetBool("Receber Dano", false);
        }
    }
    void Seguir()
    {
        if(Alvo!=null && Liberado==true && !Stun)
        {
            //Dash estilo Xadrez
            StartCoroutine(Bauzada());
            Controlador_Animator.SetBool("Atacar",false);
        }
    }
    IEnumerator Bauzada()
    {
        Liberado = false;
        yield return new WaitForSeconds(Proximo_Dash);
        //movimento
        if(!Stun)
        {
            Controlador_Animator.SetBool("Atacar",true);
            Mimic_Origem.gameObject.transform.LookAt(new Vector3 (Alvo.transform.position.x,Mimic_Origem.transform.position.y,Alvo.transform.position.z));
            Mimic_Origem.gameObject.transform.DOMove(new Vector3 (Local_Final.position.x,Mimic_Origem.transform.position.y,Local_Final.position.z),Velocidade_Dash).SetEase(Ease.OutCirc).OnPlay(()=>Dano.Pode_Dar_Dano=true).OnComplete(() =>{Liberado = true;Dano.Pode_Dar_Dano=false;});
        }
    }
}