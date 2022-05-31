using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogEntity : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] dialogNpc, dialogNpc2;

    public bool npcDialog, canTalk;

    public int index;
    public float typingSpeed, typingSpeedReal, typingSpeedAcelerado = -6;

    public Andar andar;
    public AtaqueBasico ataque;

    public GameObject imagemFundo;
    public GameObject imagemDialog;
    public bool podePassar;
    public bool cenaBoss;
    public GameObject canvasVidaBoss;
    public ScriptablePlayer scriptablePlayer;

    void Start()
    {
        typingSpeedReal = typingSpeed;
        andar = GameObject.FindGameObjectWithTag("Player").GetComponent<Andar>();
        ataque = GameObject.FindGameObjectWithTag("Player").GetComponent<AtaqueBasico>();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R) && canTalk)
        {
            index = 0;
            StartCoroutine(NpcDialogs());
        }

        EntityDialog();

    }
    public void EntityDialog()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.R))
        {
            typingSpeed = typingSpeedAcelerado;

        }

        if (podePassar)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.R))
            {
                NextSentence();
            }
        }


        if (Dialog.dialogoB)
        {
            if (npcDialog)
            {
                if (index < dialogNpc.Length)
                {
                    if (textDisplay.text == dialogNpc[index])
                    {
                        podePassar = true;
                    }
                }
            }
        }

    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!npcDialog)
            {
                canTalk = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canTalk = false;
        }
    }

    IEnumerator NpcDialogs()
    {
        if (cenaBoss)
        {
            canvasVidaBoss.SetActive(false);
        }
        imagemFundo.SetActive(true);
        canTalk = false;
        npcDialog = true;

        podePassar = false;

        Dialog.dialogoB = true;
        ataque.DesativarAtaque();


        foreach (char letter in dialogNpc[index].ToCharArray())
        {
            textDisplay.text += letter;
            imagemDialog.SetActive(true);
            yield return new WaitForSeconds(typingSpeed);
        }


        index++;
        typingSpeed = typingSpeedReal;
    }



    public void NextSentence()
    {
        typingSpeed = typingSpeedReal;

        if (npcDialog)
        {
            if (index < dialogNpc.Length)
            {
                textDisplay.text = "";
                StartCoroutine(NpcDialogs());
            }
            else
            {
                textDisplay.text = "";
                ataque.AtivarAtaque();
                Dialog.dialogoB = false;
                npcDialog = false;
                imagemDialog.SetActive(false);
                imagemFundo.SetActive(false);
                if (cenaBoss)
                {
                    scriptablePlayer.FirstTime = false;
                    GameObject.Find("Controlador").GetComponent<GameManager>().load.Carregar_CenaInicio(1);
                }
            }
        }

    }


}
