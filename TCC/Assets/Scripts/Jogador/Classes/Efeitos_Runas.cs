using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efeitos_Runas : MonoBehaviour
{
    public bool Efeito_Comromper,
                Efeito_Explosao;

    public GameObject   Forma_Aliado,
                        Bomba;
    public INIStatus Status;

    // Update is called once per frame
    void Update()
    {
        Runa_Comromper();
        Runa_Explosao();
    }
    public void Runa_Comromper()
    {
        if(Efeito_Comromper==true && Status.vida<=0)
        {
            Instantiate(Forma_Aliado,this.transform);
            // Passar Atributos para o novo objeto ou deixa setado ja ????
            Destroy(this.gameObject,0f);
        }
    }
    public void Runa_Explosao()
    {
        if(Efeito_Explosao==true && Status.vida<=0)
        {
            Instantiate(Bomba,this.transform.position,transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
