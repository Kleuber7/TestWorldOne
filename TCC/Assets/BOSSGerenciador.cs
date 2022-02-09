using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSGerenciador : MonoBehaviour
{
    public bool atirar;
    public bool atravessar;
    public bool enfurecido;
    public GameObject alvo;
    public BOSSStatus status;
    public BOSSPath scriptPath;
    public BOSSTiros scriptTiros;

    void Start()
    {
        alvo = GameManager.gameManager.GetPlayer();
    }

    void FixedUpdate()
    {
        if(status.vida <= (status.vidaMax * .3f))
        {
            enfurecido = true;
        }
    }

    public IEnumerator AlteraEstado()
    {
        yield return new WaitForSeconds(1);
    }
}
