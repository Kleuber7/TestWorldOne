using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    [SerializeField] private int countFire;
    [SerializeField] private float damageFire;
    [SerializeField] private float timeTakeDamage;
    [SerializeField] private bool takingDamage = false;
    [SerializeField] private INIStatus inimigoRef;
    //[SerializeField] private StatusBoboneco bobonecoRef;
    

    private void LateUpdate()
    {
        TakeDamageFire(inimigoRef);
    }


    void TakeDamageFire(INIStatus inimigo)
    {
        inimigoRef = inimigo;
        if (timeTakeDamage <= 0)
        {
            timeTakeDamage = 0;
        }
        else
        {
            if (!takingDamage)
                StartCoroutine(FireDamageSec(inimigo));
            timeTakeDamage -= Time.deltaTime;
        }
    }

    public void AttackFire(INIStatus inimigo)
    {
        timeTakeDamage = countFire;
        TakeDamageFire(inimigo);
    }

    IEnumerator FireDamageSec(INIStatus inimigo)
    {
        takingDamage = true;
        yield return new WaitForSeconds(1f);
        inimigo.TomarDano(damageFire);
        takingDamage = false;
    }


    //BobonecoFire
    //void TakeDamageFire(StatusBoboneco boboneco)
    //{
    //    bobonecoRef = boboneco;
    //    if (timeTakeDamage <= 0)
    //    {
    //        StopCoroutine(FireDamageSecBobo(boboneco));
    //        timeTakeDamage = 0;
    //    }
    //    else
    //    {
    //        if(!takingDamage)
    //        StartCoroutine(FireDamageSecBobo(boboneco));

    //        timeTakeDamage -= Time.deltaTime;
    //    }
    //}

    //public void AttackFireBoboneco(StatusBoboneco boboneco)
    //{
    //    timeTakeDamage = countFire;
    //    TakeDamageFire(boboneco);
    //}

    //IEnumerator FireDamageSecBobo(StatusBoboneco boboneco)
    //{
    //    takingDamage = true;
    //    yield return new WaitForSeconds(1f);
    //    boboneco.TomarDano(damageFire);
    //    takingDamage = false;
    //}

}
