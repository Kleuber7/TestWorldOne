using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SkillE : MonoBehaviour
{
    [SerializeField] private string tagColisor;
    //public List<GameObject> colliders = new List<GameObject>();
    [SerializeField] private bool podeTomardano = true, ativacao = false;
    [SerializeField] private float dano = 20;
    [SerializeField] private float cooldownTime = 5, nextAttack, contDuracao = 0;
    [SerializeField] private Collider tentaculo;
    [SerializeField] FSMJogador jogadorA;
    [SerializeField] ParticleManagerSkillE skillEffect;
    [SerializeField] private KeyCode key = KeyCode.E;
    [SerializeField] private ScriptablePlayer status;
    [SerializeField] private float speedReduction = 5f;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (!colliders.Contains(other.gameObject) && other.gameObject.tag == tagColisor)
    //    {
    //        colliders.Add(other.gameObject);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == tagColisor)
    //        colliders.Remove(other.gameObject);
    //}


    private void Update()
    {
        Ativacao();
    }


    public void Ativacao()
    {
        if (Time.time > nextAttack)
        {
            if (Input.GetKeyDown(key) && !PLASkills.castingSkill)
            {
                TimeTentacles();
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == tagColisor)
        {
            if (podeTomardano)
            {
                StartCoroutine(Duracao());
                other.GetComponent<INIStatus>().TomarDano(dano);
            }
            contDuracao = 0;
            ativacao = false;
            nextAttack = Time.time + cooldownTime;


            //foreach (GameObject inimigos in colliders)
            //{

            //    if (inimigos == null)
            //    {
            //        colliders.Remove(inimigos);
            //        break;
            //    }

            //    if (inimigos != null)
            //    {
            //        if (podeTomardano)
            //        {
            //            StartCoroutine(Duracao());

            //            inimigos.GetComponent<INIStatus>().TomarDano(dano);
            //        }
            //        contDuracao = 0;
            //        ativacao = false;
            //        nextAttack = Time.time + cooldownTime;
            //    }
            //}
        }
    }

    IEnumerator Duracao()
    {
        podeTomardano = false;

        yield return new WaitForSecondsRealtime(0.5f);
        podeTomardano = true;

    }

    async void TimeTentacles()
    {
        await TimeTentaclesAsync();
        tentaculo.enabled = false;
        status.speed = status.maxSpeed;
        jogadorA.ChangeAnimationState("");
        PLASkills.castingSkill = false;
    }

    async Task TimeTentaclesAsync()
    {
        PLASkills.castingSkill = true;
        status.speed = speedReduction;
        tentaculo.enabled = true;
        jogadorA.ChangeAnimationState(jogadorA.Testaculos());
        skillEffect.PlayParticleEffect();
        await Task.Delay(3000);
    }
}
