using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class Andar : MonoBehaviour
{
    public CharacterController ControladorMov;
    public ScriptablePlayer Jogador;
    public Vector3 Direcao;
    public Vector3 direcaoRotacao;
    [SerializeField] private FSMJogador jogadorAnima;
    [SerializeField] public float velocidadeDesloca;
    private float distanciaAnterior;
    [SerializeField] private AtaqueADistancia scriptDeAtaqueADistancia;
    [SerializeField] private AtaqueBasico scriptAttack;

    public void Start()
    {
        ControladorMov = this.gameObject.GetComponent<CharacterController>();

    }


    public void FixedUpdate()
    {
        if (!GameManager.gameManager.teleportando && !GameManager.gameManager.atacando && !Dialog.dialogoB && !Teleporting.teleportando && !scriptDeAtaqueADistancia.ataqueADistancia && !Jogador_Status.morreu)
        {
            ControladorMov.enabled = true;
            Mover();
        }
        else if (GameManager.gameManager.atacando)
        {
            transform.Translate((direcaoRotacao - transform.position).normalized * velocidadeDesloca * Time.deltaTime, Space.World);
        }
        else if (!PLASkills.castingSkill && !Jogador_Status.morreu)
        {
            ControladorMov.enabled = false;
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

        ControladorMov.Move(new Vector3(Direcao.x, 0, Direcao.z) * Jogador.speed * Time.deltaTime);
        transform.localRotation *= Quaternion.FromToRotation(transform.forward, Direcao);
        transform.rotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);


        if (!scriptAttack.takingDamagePlayer)
        {
            if (Direcao.x == 0 && Direcao.z == 0 && !PLASkills.castingSkill)
            {
                jogadorAnima.ChangeAnimationState(jogadorAnima.Parado());
            }
            else if (!PLASkills.castingSkill)
            {
                jogadorAnima.ChangeAnimationState(jogadorAnima.Andar());
            }
        }
    }
}