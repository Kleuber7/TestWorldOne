using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DanoAtaqueBasico : MonoBehaviour
{
    [SerializeField] public float dano;
    [SerializeField] public GameObject inimigo;
    [SerializeField] private string tagColisor;
    [SerializeField] private AtaqueBasico ataqueBasico;
    [SerializeField] private float timeStun = 0.5f;
    private Critico critico;
    public Testing damagePop;
    [SerializeField] private FireAttack fireAttack;

    private void Start()
    {
        critico = GetComponent<Critico>();

    }

    private void OnTriggerEnter(Collider other)
    {
        inimigo = other.gameObject;

        if (other.gameObject.tag == tagColisor && tagColisor == "Inimigo")
        {
            critico.DoAttack();
            DamagePopup.Create(other.transform.position, dano, critico.critou, damagePop.pfDamagePopUp);
            other.GetComponentInChildren<INIPerseguir>().ManageDamage();
            other.GetComponent<FSMInimigos>().ChangeAnimationState("");
            other.GetComponent<FSMInimigos>().ChangeAnimationState(other.GetComponent<FSMInimigos>().TomarDano());
            other.GetComponent<INIStatus>().TakeDamageEffect();
            if (ataqueBasico.contadorCombo < 3)
            {
                fireAttack.AttackFire(other.GetComponent<INIStatus>());
                other.GetComponent<INIStatus>().TomarDano(dano);
            }
            else if (ataqueBasico.contadorCombo == 3)
            {
                StartCoroutine(DividedDamage(other.GetComponent<INIStatus>()));
                fireAttack.AttackFire(other.GetComponent<INIStatus>());
            }
        }
        else if (other.gameObject.tag == "Boboneco")
        {
            critico.DoAttack();
            DamagePopup.Create(other.transform.position, dano, critico.critou, damagePop.pfDamagePopUp);
            other.GetComponent<StatusBoboneco>().TomarDano(dano);
        }

        //if(ataqueBasico.contadorCombo == 3)
        //{
        //    congelar.CongelarINI(other.gameObject);
        //}
    }


    IEnumerator DividedDamage(INIStatus inimigo)
    {
        inimigo.GetComponent<INIStatus>().TomarDano(dano);
        yield return new WaitForSeconds(ataqueBasico.duracaoAtaques[ataqueBasico.contadorCombo] - (ataqueBasico.respectTime * 1.5f));
        inimigo.GetComponent<INIStatus>().TomarDano(dano);
    }


}
