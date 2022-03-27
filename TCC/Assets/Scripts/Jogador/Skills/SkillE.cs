using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SkillE : MonoBehaviour
{
    [SerializeField] private bool podeTomardano = true, ativacao = false, cdSkill = true;
    [SerializeField] private float dano = 20;
    [SerializeField] private float cooldownTime = 5;
    [SerializeField] private Collider tentaculo;
    [SerializeField] FSMJogador jogadorA;
    [SerializeField] ParticleManagerSkillE skillEffect;
    [SerializeField] private KeyCode key = KeyCode.E;
    [SerializeField] private ScriptablePlayer status;
    [SerializeField] private float speedReduction = 5f;
    [Header("Time in miliseconds")]
    [SerializeField] private int animTime = 3000;
    [SerializeField] private int manaCost;
   
    private void Update()
    {
        Ativacao();
    }


    public void Ativacao()
    {
        if (cdSkill && status.Mana >= manaCost)
        {
            if (Input.GetKeyDown(key) && !PLASkills.castingSkill && !GameManager.gameManager.atacando)
            {
                status.Mana -= manaCost;
                StartCoroutine(TimeTentacles());
                CDSkill();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Inimigo")
        {
            if (podeTomardano)
            {
                StartCoroutine(Duracao());
                other.GetComponent<INIStatus>().TomarDano(dano);
                other.GetComponentInChildren<INIPerseguir>().ManageDamage();
            }
            ativacao = false;
        }
        if (other.gameObject.tag == "Boboneco")
        {
            if (podeTomardano)
            {
                StartCoroutine(Duracao());
                other.GetComponent<StatusBoboneco>().TomarDano(dano);
            }
            ativacao = false;
        }
        if (other.gameObject.tag == "Boss")
        {
            if (podeTomardano)
            {
                StartCoroutine(Duracao());
                other.gameObject.GetComponent<BOSSStatus>().TomarDano(dano);
            }
            ativacao = false;
        }
    }

    IEnumerator Duracao()
    {
        podeTomardano = false;
        yield return new WaitForSecondsRealtime(0.5f);
        podeTomardano = true;

    }


    public async void CDSkill()
    {
        await CDSkillAsync();
    }
    public async Task CDSkillAsync()
    {
        cdSkill = false;
        await Task.Delay(1500 * (int)cooldownTime);
        cdSkill = true;
    }
    //async void TimeTentacles()
    //{
    //    //await TimeTentaclesAsync();
    //    tentaculo.enabled = false;
    //    status.speed = status.maxSpeed;
    //    jogadorA.ChangeAnimationState("");
    //    PLASkills.castingSkill = false;
    //}

    IEnumerator TimeTentacles()
    {
        PLASkills.castingSkill = true;
        status.speed = speedReduction;
        tentaculo.enabled = true;
        jogadorA.ChangeAnimationState(jogadorA.Testaculos());
        skillEffect.PlayParticleEffect();
        yield return new WaitForSeconds(animTime);
        
        tentaculo.enabled = false;
        status.speed = status.maxSpeed;
        jogadorA.ChangeAnimationState("");
        PLASkills.castingSkill = false;
    }
}
