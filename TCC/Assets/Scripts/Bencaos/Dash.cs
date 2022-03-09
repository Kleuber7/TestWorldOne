using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class Dash : MonoBehaviour
{

    public float dashSpeed, dashTime, currentDashTime, dashSpeedWall;
    public bool canDash;
    
    [SerializeField] private ParticleManagerDashTP particleDashTP, particleDashTPFront, particleDashExplosion;
   

    void Update()
    {
        Dashh();
    }


    private void Dashh()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !canDash && !Dialog.dialogoB && GetComponent<Andar>().Direcao != Vector3.zero && !PLASkills.castingSkill)
        {
           StartCoroutine(ParticleDash());
        }

        if (currentDashTime < dashTime && canDash)
        {
            currentDashTime += Time.deltaTime;
        }
        else
        {
            canDash = false;
        }
    }

    IEnumerator ParticleDash()
    {
        canDash = true;
        currentDashTime = 0;
        particleDashTP.PlayParticleDash();
        yield return new WaitForSeconds(0.1f);
        particleDashTPFront.PlayParticleDash();
        particleDashExplosion.PlayParticleDash();

        if (DashWall.dashWall == false)
        {
            GetComponent<Andar>().ControladorMov.Move(GetComponent<Andar>().Direcao * dashSpeed);
        }
        else if (DashWall.dashWall == true)
        {
            GetComponent<Andar>().ControladorMov.enabled = false;
            transform.position = GameObject.FindGameObjectWithTag("DashWall").transform.position;
            DashWall.dashWall = false;
        }

        currentDashTime = 0;
    }
}
