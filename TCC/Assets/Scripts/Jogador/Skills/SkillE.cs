using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillE : MonoBehaviour
{
    [SerializeField] private string tagColisor;
    public List<GameObject> colliders = new List<GameObject>();
    [SerializeField] private bool podeTomardano = true, ativacao = false;
    [SerializeField] private float dano = 20;
    [SerializeField] private float cooldownTime = 5, nextAttack, contDuracao = 0;
    [SerializeField] private GameObject tentaculos;
    [SerializeField] private Collider tentaculo;

    private void OnTriggerEnter(Collider other)
    {
        if (!colliders.Contains(other.gameObject) && other.gameObject.tag == tagColisor)
        {
            colliders.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == tagColisor)
            colliders.Remove(other.gameObject);
    }


    private void Update()
    {
        Ativacao();
    }


    public void Ativacao()
    {
        if (Time.time > nextAttack)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {   
                StartCoroutine(DuracaoTentaculos());
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == tagColisor)
        {
           
               
                foreach (GameObject inimigos in colliders)
                {

                    if (inimigos == null)
                    {
                        colliders.Remove(inimigos);
                        break;
                    }

                    if (inimigos != null)
                    {

                        //  if (Vector3.Distance(inimigos.transform.position, this.gameObject.transform.position) <= 100)
                        // {

                        //if (inimigos.GetComponent<INIStatus>().podeTomardanoSunFire)
                        //{

                       
                            if (podeTomardano)
                            {
                                StartCoroutine(Duracao());

                                inimigos.GetComponent<INIStatus>().TomarDano(dano);
                            }
                        
                        contDuracao = 0;
                        tentaculos.SetActive(false);
                        ativacao = false;
                        nextAttack = Time.time + cooldownTime;
                        //  }
                    }
                }
            
        }
    }

    IEnumerator Duracao()
    {
        podeTomardano = false;

        yield return new WaitForSecondsRealtime(0.5f);
        podeTomardano = true;
      
    }

    IEnumerator DuracaoTentaculos()
    {
        tentaculo.enabled = true;
        tentaculos.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        tentaculo.enabled = false;
        tentaculos.SetActive(false);
    }
}
