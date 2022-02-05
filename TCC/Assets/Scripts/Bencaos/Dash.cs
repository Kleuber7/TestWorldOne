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
       

        if (Input.GetKeyDown(KeyCode.Space) && !canDash && !Dialog.dialogoB && GetComponent<Andar>().Direcao != Vector3.zero)
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
        //else if (DashWall.dashWall == true)
        //{
        //    dashWall = GameObject.FindGameObjectWithTag("DashWall").GetComponent<Collider>();
        //    dashWall.enabled = false;
        //    GetComponent<Andar>().ControladorMov.Move(GetComponent<Andar>().Direcao * dashSpeedWall);
        //    yield return new WaitForSeconds(0.2f);
        //    dashWall.enabled = true;
        //}
        else if (DashWall.dashWall == true)
        {
            GetComponent<Andar>().ControladorMov.enabled = false;
            transform.position = GameObject.FindGameObjectWithTag("DashWall").transform.position;
        }

        currentDashTime = 0;
    }






    //IEnumerator DashEnum()
    //{
    //    while (currentDashTime > dashTime )
    //    {
    //        GetComponent<Andar>().ControladorMov.Move(GetComponent<Andar>().Direcao * dashSpeed * Time.deltaTime);
    //        yield return null;
    //    }
    //}
}
