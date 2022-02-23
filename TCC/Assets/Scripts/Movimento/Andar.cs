using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class Andar : MonoBehaviour
{
    public CharacterController ControladorMov;
    public Jogador_Status Jogador;
    public Vector3  Direcao;
    public Vector3 direcaoRotacao;
    [SerializeField] private FSMJogador jogadorAnima;
    [SerializeField] public float velocidadeDesloca;
    private float distanciaAnterior;
    [SerializeField] private AtaqueADistancia scriptDeAtaqueADistancia;

    public void Start()
    {
        ControladorMov = this.gameObject.GetComponent<CharacterController>();
        
    }

    
    public void FixedUpdate()
    {
        if(!GameManager.gameManager.teleportando && !GameManager.gameManager.atacando && !Dialog.dialogoB && !Teleporting.teleportando && !scriptDeAtaqueADistancia.ataqueADistancia)
        {
            ControladorMov.enabled = true;
            Mover();
        }
        else if (GameManager.gameManager.atacando)
        {
            transform.Translate((direcaoRotacao - transform.position).normalized * velocidadeDesloca * Time.deltaTime, Space.World);
        }
        else
        {
            ControladorMov.enabled = false;
            jogadorAnima.ChangeAnimationState(jogadorAnima.Parado());
        }
        


        //if(Input.GetMouseButtonDown(0) || Input.GetMouseButton(1))
        //{
        //    RaycastHit hit;

        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity) && Vector3.Distance(transform.position, hit.point) > 5f)
        //    {
        //        direcaoRotacao = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        //        transform.LookAt(direcaoRotacao);

        //    }
        //}
    }

    public void Mover()
    {
        Direcao = Vector3.zero;

        
        Direcao.x = Input.GetAxisRaw("Horizontal") - Input.GetAxisRaw("Vertical");
        Direcao.z = Input.GetAxisRaw("Vertical") + Input.GetAxisRaw("Horizontal");

        ControladorMov.Move(new Vector3(Direcao.x, 0, Direcao.z) * Jogador.Velocidade * Time.deltaTime);
        transform.localRotation *= Quaternion.FromToRotation(transform.forward, Direcao);
        transform.rotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);

        
        
            if (Direcao.x == 0 && Direcao.z == 0)
            {
                jogadorAnima.ChangeAnimationState(jogadorAnima.Parado());
            }
            else
            {
                jogadorAnima.ChangeAnimationState(jogadorAnima.Andar());
            }
        

        // if(direcaoRotacao.x > 0)
        // {
        //     jogadorAnima.SetHorizontal(1);
        // }
        // else
        // {
        //     jogadorAnima.SetHorizontal(-1);
        // }

        // if(direcaoRotacao.z > 0)
        // {
        //     jogadorAnima.SetVertical(1);
        // }
        // else
        // {
        //     jogadorAnima.SetVertical(-1);
        // }

        // if(Vector3.Distance(this.transform.position, hit.point) >= distanciaAnterior + 1f)
        // {
        //     jogadorAnima.SetHorizontal(1);
        //     jogadorAnima.SetVertical(-1);
        // }
        // else
        // {
        //     jogadorAnima.SetHorizontal(-1);
        //     jogadorAnima.SetVertical(1);
        // }

        // distanciaAnterior = Vector3.Distance(this.transform.position, hit.point);
    }
}