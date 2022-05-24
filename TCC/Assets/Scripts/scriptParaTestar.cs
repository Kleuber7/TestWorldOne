using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptParaTestar : MonoBehaviour
{
    public ScriptablePlayer scriptable;

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

        if (Input.GetKeyDown(KeyCode.F5))
        {
            scriptable.money += 10000;
        }
    }
}
