using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congelar : MonoBehaviour
{
    public float stunCongelar = 2;
 
    

  
    public void CongelarINI(GameObject _inimigo) 
    {
        _inimigo.GetComponent<INIMovimento>().Stunado(stunCongelar);
    }

}
