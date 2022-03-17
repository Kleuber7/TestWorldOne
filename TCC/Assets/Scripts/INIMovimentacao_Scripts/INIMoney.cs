using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INIMoney : MonoBehaviour
{
    [SerializeField] private ScriptablePlayer status;
    [SerializeField] private int moneyEarn = 20;

    public void Money()
    {
        status.moneyEarn = moneyEarn;
        status.moneyHUD = true;
        status.money += moneyEarn;
    }
}
