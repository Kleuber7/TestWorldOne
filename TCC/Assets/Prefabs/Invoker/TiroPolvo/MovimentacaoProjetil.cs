using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoProjetil : MonoBehaviour
{
    public float vel;
    public float quant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vel != 0)
        {
            transform.position += transform.forward * (vel * Time.deltaTime);

        }
        else
        {
            Debug.Log("Sem vel");
        }
    }
}
