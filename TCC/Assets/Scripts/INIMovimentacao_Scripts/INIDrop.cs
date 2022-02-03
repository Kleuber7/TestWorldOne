using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INIDrop : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float forcaMagnetismo;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    private void Update() 
    {
        transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Pegar(other.gameObject);
        }
    }

    void Pegar(GameObject player)
    {
        GameManager.gameManager.dinheiroJogador += 50;
        Destroy(this.gameObject);
    }
}
