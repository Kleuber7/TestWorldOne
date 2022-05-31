using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptParaTestar : MonoBehaviour
{
    public ScriptablePlayer scriptable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            scriptable.money += 10000;
        }
    }
}
