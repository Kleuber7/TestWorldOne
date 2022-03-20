using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogEntity : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] dialogNpc;

    public bool npcDialog, canTalk;

    public int index;
    public float typingSpeed, typingSpeedReal, typingSpeedAcelerado = -6;

    public Andar andar;
    public AtaqueBasico ataque;

    public GameObject continueButton;
    public bool podePassar;



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
        if (Jogador_Status.mortes == 0)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                typingSpeed = typingSpeedAcelerado;

            }

            if (podePassar)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    NextSentence();
                    typingSpeed = typingSpeedReal;
                }
            }

            if (Dialog.dialogoB)
            {
                if (npcDialog)
                {
                    if (textDisplay.text == dialogNpc[index])
                    {
                        podePassar = true;
                        continueButton.SetActive(true);
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
        canTalk = false;
        npcDialog = true;

        podePassar = false;

        Dialog.dialogoB = true;
        ataque.DesativarAtaque();


        foreach (char letter in dialogNpc[index].ToCharArray())
        {
            textDisplay.text += letter;
            // imagemDialog.SetActive(true);
            yield return new WaitForSeconds(typingSpeed);
        }

       
        index++;
        typingSpeed = typingSpeedReal;
    }

    void NextSentence()
    {

        continueButton.SetActive(false);

        if (npcDialog && Jogador_Status.mortes == 0)
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
            }
        }
    }


}
