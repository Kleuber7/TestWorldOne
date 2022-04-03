using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PLASkills : MonoBehaviour
{
    [SerializeField] private bool skill1Ativa;
    [SerializeField] private bool podeAtivarSkill1 = true;
    [SerializeField] private float skill1TempoDeRecarga;
    [SerializeField] private KeyCode teclaSkill1;
    [SerializeField] private float tempoDeCastSkill1;
    [SerializeField] private PLAImpactoAbissal scriptImpactoAbissal;
    [SerializeField] private ParticleManagerSkillQ skillParticle;
    [SerializeField] private float timeParticleActivate = 1.02f;
    [SerializeField] private float custoDeMana;
    [SerializeField] private ScriptablePlayer status;
    [SerializeField] private float timeCorrection = 0.4f;
    public static bool castingSkill = false;

    private void Start()
    {
        podeAtivarSkill1 = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(teclaSkill1) && !castingSkill && !GameManager.gameManager.atacando && !Jogador_Status.morreu)
        {
            if (podeAtivarSkill1)
            {
                if(status.Mana >= custoDeMana)
                {
                    status.Mana -= custoDeMana;
                    StartCoroutine(TimeSnare());
                    StartCoroutine(CastSkill1());
                    StartCoroutine(ContaTempoRecagra(skill1TempoDeRecarga));
                }
                
            }
        }
    }

    public IEnumerator ContaTempoRecagra(float tempoDeRecarga)
    {
        podeAtivarSkill1 = false;
        yield return new WaitForSeconds(tempoDeRecarga);
        podeAtivarSkill1 = true;
    }

    public IEnumerator CastSkill1()
    {
        yield return new WaitForSeconds(tempoDeCastSkill1 - timeCorrection);
        scriptImpactoAbissal.ImpactoAbissal(scriptImpactoAbissal.inimigos);
    }

    

    IEnumerator TimeSnare()
    {
        castingSkill = true;
        GameManager.gameManager.atacando = true;
        GetComponent<FSMJogador>().ChangeAnimationState(GetComponent<FSMJogador>().Snare());
        StartCoroutine(TimeParticles());
        yield return new WaitForSeconds(tempoDeCastSkill1);
        GameManager.gameManager.atacando = false;
        GetComponent<FSMJogador>().ChangeAnimationState("");
        castingSkill = false;
    }

    IEnumerator TimeParticles()
    {
        yield return new WaitForSeconds(timeParticleActivate);
        skillParticle.PlayParticleEffect();
    }
}
