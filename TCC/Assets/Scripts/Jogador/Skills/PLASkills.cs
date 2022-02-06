using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLASkills : MonoBehaviour
{
    [SerializeField] private bool skill1Ativa;
    [SerializeField] private bool podeAtivarSkill1 = true;
    [SerializeField] private float skill1TempoDeRecarga;
    [SerializeField] private KeyCode teclaSkill1;
    [SerializeField] private float tempoDeCastSkill1;
    [SerializeField] private PLAImpactoAbissal scriptImpactoAbissal;

    private void Start() 
    {
        podeAtivarSkill1 = true;
    }

    private void Update() 
    {
        if(Input.GetKeyDown(teclaSkill1))
        {
            if(podeAtivarSkill1)
            {
                StartCoroutine(CastSkill1());
                StartCoroutine(ContaTempoRecagra(skill1TempoDeRecarga));
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
        yield return new WaitForSeconds(tempoDeCastSkill1);
        scriptImpactoAbissal.ImpactoAbissal(scriptImpactoAbissal.inimigos);
    }
}
