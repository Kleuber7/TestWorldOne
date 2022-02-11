using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoAtaqueBasico : MonoBehaviour
{
    [SerializeField] public float dano;
    [SerializeField] public GameObject inimigo;
    [SerializeField] private string tagColisor;
    [SerializeField] private FontedeVida fonteedeVida;
    [SerializeField] private AtaqueBasico ataqueBasico;
    [SerializeField] private Congelar congelar;
    [SerializeField] private float timeStun = 0.5f;
    private Critico critico;
    public Testing damagePop;

    private void Start()
    {
        critico = GetComponent<Critico>();
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        inimigo = other.gameObject;

        if(other.gameObject.tag == tagColisor && tagColisor == "Inimigo")
        {
            
            critico.DoAttack();
            DamagePopup.Create(other.transform.position, dano, critico.critou, damagePop.pfDamagePopUp);
            StartCoroutine(other.GetComponent<INIMovimento>().Stunado(timeStun));
            other.GetComponent<INIStatus>().NaoDarDano();
            StartCoroutine(other.GetComponentInChildren<INIPerseguir>().TakingDamage());
            other.GetComponent<INIStatus>().TomarDano(dano);
            //fonteedeVida.CurarP();
        }
        else if(other.gameObject.tag == "Boboneco")
        {
            critico.DoAttack();
            DamagePopup.Create(other.transform.position, dano, critico.critou, damagePop.pfDamagePopUp);
            other.GetComponent<StatusBoboneco>().TomarDano(dano);
            //fonteedeVida.CurarP();
        }

        //if(ataqueBasico.contadorCombo == 3)
        //{
        //    congelar.CongelarINI(other.gameObject);
        //}
    }
    



}
