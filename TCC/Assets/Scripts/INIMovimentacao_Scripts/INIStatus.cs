using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INIStatus : BASEStatus
{
    public float dano, danoReal;
    public static float danoUp = 2, vidaUp = 50;
    public float range;

    public bool Efeito_Comromper;
    public GameObject Forma_Aliado;
    [SerializeField] private bool stunado = false;
    [SerializeField] public bool podeTomardanoSunFire = true;

    public bool teste;
    

    public override void Morrer()
    {
        Runa_Comromper();
        

        StartCoroutine(MorrerAnim());
        
        //Destroy(this.gameObject);
    }


    IEnumerator MorrerAnim()
    {
        GetComponentInChildren<INIPerseguir>().enabled = false;
        //GetComponent<INIPatrulha>().enabled = false;
        
        GetComponent<FSMInimigos>().ChangeAnimationState(GetComponent<FSMInimigos>().Morte());
        dano = 0;
        yield return new WaitForSeconds(4f);

        this.GetComponent<INIDropar>().Dropar();
        Destroy(this.gameObject);
    }

    void Start()
    {
        teste = true;
        dano += danoUp;
        vidaMax += vidaUp;
        vida += vidaUp;
        danoReal = dano;
    }
    void Update()
    {

        if(teste)
        {
            if(Efeito_Comromper == true)
            {
                StartCoroutine(Corompimento());
            }
        }

        if(vida <= 0)
        {
            Morrer();
        }
    }
    //Metodos para tirar o dano do inimigo quando ele for congelado.
    public void NaoDarDano()
    {
        dano = 0;
    }
    public void DarDano()
    {
        dano = danoReal;
    }

    public bool GetStunado()
    {
        return stunado;
    }

    public void SetStunado(bool _stunado)
    {
        stunado = _stunado;
    }
    public void Runa_Comromper()
    {
        if(Efeito_Comromper==true && vida<=0)
        {
            Instantiate(Forma_Aliado,this.transform.position,this.transform.rotation);
            Debug.Log("Rodei");
        }
    }

    IEnumerator Corompimento()
    {
        teste = false;
        yield return new WaitForSeconds(10);
        Efeito_Comromper=false; 
        teste = true;
    }
}
