using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptParaTestar : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F7))
        {
            if (GameManager.gameManager.contI != null)
            {
                foreach (GameObject inimigos in GameManager.gameManager.contI)
                {
                    Destroy(inimigos);
                }
            }
        }
    }
}
