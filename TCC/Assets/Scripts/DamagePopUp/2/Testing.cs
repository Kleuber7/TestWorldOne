﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour {

    public Transform pfDamagePopUp;
    private void Start() {
       // Instantiate(GameAssets.i.pfDamagePopUp, Vector3.zero, Quaternion.identity);
        //DamagePopup.Create(Vector3.zero, 300, false);
    }

    private void Update() {
        

        if (Input.GetMouseButtonDown(0)) {
            bool isCriticalHit = Random.Range(0, 100) < 30;
           // DamagePopup.Create(pfDamagePopUp, Vector3.zero, Quaternion.identity);
            //DamagePopup.Create(UtilsClass.GetMouseWorldPosition(), 100, isCriticalHit);
        }
    }
}
