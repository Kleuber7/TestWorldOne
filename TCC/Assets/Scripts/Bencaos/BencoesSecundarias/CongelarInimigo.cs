using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongelarInimigo : MonoBehaviour
{
    [SerializeField] private string tagColisor;
    public List<GameObject> colliders = new List<GameObject>();

    private void Start()
    {
        
    }
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
        {
            foreach (GameObject inimigos in colliders)
            {
                inimigos.GetComponentInChildren<INIPerseguir>().AjustarVelocidadeAtaque();

            }
            colliders.Remove(other.gameObject);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == tagColisor)
        {
            foreach (GameObject inimigos in colliders)
            {

                if (inimigos != null)
                {
                    foreach (GameObject inimigosColisores in colliders)
                    {
                        if (inimigosColisores == null)
                        {
                            colliders.Remove(inimigosColisores);
                        }
                    }



                    inimigos.GetComponentInChildren<INIPerseguir>().DiminuirVelocidadeAtaque();



                    Debug.Log("Arma congelada");

                }
            }
        }
    }
}
