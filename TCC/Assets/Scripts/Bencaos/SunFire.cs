using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFire : MonoBehaviour
{
    [SerializeField] private bool podeTomardano = true;
    [SerializeField] private float dano = 20;
    [SerializeField] private string tagColisor;
    public List<GameObject> colliders = new List<GameObject>();

   
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


    

    private void OnTriggerStay(Collider other)
    {
       


        if (other.gameObject.tag == tagColisor)
        {


            if (podeTomardano)
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
                       
                        if (Vector3.Distance(inimigos.transform.position, this.gameObject.transform.position) <= 100)
                        {
                            StartCoroutine(DanoPorSegundo());

                            inimigos.GetComponent<INIStatus>().TomarDano(dano);                            
                        }
                    }
                    

                    
                }
            }
        }  
    }

    IEnumerator DanoPorSegundo()
    {
        podeTomardano = false;
        
        yield return new WaitForSecondsRealtime(1f);
        podeTomardano = true;
    }

}
