using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogStylist : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] dialogNpc, dialogNpc2, dialogNpc3, dialogNpc4, dialogNpc5, dialogNpc6, dialogNpc7;

    public bool npcDialog, canTalk;

    public int index;
    public float typingSpeed, typingSpeedReal, typingSpeedAcelerado = -6;

    public Andar andar;
    public AtaqueBasico ataque;

    public GameObject imagemFundo;
    public GameObject imagemDialog;
    //public GameObject continueButton;
    public bool podePassar;
    public Estilista stylist;


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
            if (Jogador_Status.mortes == 0)
            {
                index = 0;
                StartCoroutine(NpcDialogs());
            }
            else if (Jogador_Status.mortes == 1)
            {
                index = 0;
                StartCoroutine(NpcDialogs2());
            }
            else if (Jogador_Status.mortes == 2)
            {
                index = 0;
                StartCoroutine(NpcDialogs3());
            }
            else if (Jogador_Status.mortes == 3)
            {
                index = 0;
                StartCoroutine(NpcDialogs4());
            }
            else if (Jogador_Status.mortes == 4)
            {
                index = 0;
                StartCoroutine(NpcDialogs5());
            }
            else if (Jogador_Status.mortes == 5)
            {
                index = 0;
                StartCoroutine(NpcDialogs6());
            }
            else if (Jogador_Status.mortes >= 6)
            {
                index = 0;
                StartCoroutine(NpcDialogs7());
            }
        }

        StylistDialog();

    }
    public void StylistDialog()
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
                if (Jogador_Status.mortes == 0)
                {
                    if (index < dialogNpc.Length)
                    {
                        if (textDisplay.text == dialogNpc[index])
                        {
                            podePassar = true;
                        }
                    }
                }
                else if (Jogador_Status.mortes == 1)
                {
                    if (index < dialogNpc2.Length)
                    {
                        if (textDisplay.text == dialogNpc2[index])
                        {
                            podePassar = true;
                        }
                    }
                }
                else if (Jogador_Status.mortes == 2)
                {
                    if (index < dialogNpc3.Length)
                    {
                        if (textDisplay.text == dialogNpc3[index])
                        {
                            podePassar = true;
                        }
                    }
                }
                else if (Jogador_Status.mortes == 3)
                {
                    if (index < dialogNpc4.Length)
                    {
                        if (textDisplay.text == dialogNpc4[index])
                        {
                            podePassar = true;
                        }
                    }
                }
                else if (Jogador_Status.mortes == 4)
                {
                    if (index < dialogNpc5.Length)
                    {
                        if (textDisplay.text == dialogNpc5[index])
                        {
                            podePassar = true;
                        }
                    }
                }
                else if (Jogador_Status.mortes == 5)
                {
                    if (index < dialogNpc6.Length)
                    {
                        if (textDisplay.text == dialogNpc6[index])
                        {
                            podePassar = true;
                        }
                    }
                }
                else if (Jogador_Status.mortes == 6)
                {
                    if (index < dialogNpc7.Length)
                    {
                        if (textDisplay.text == dialogNpc7[index])
                        {
                            podePassar = true;
                        }
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
                canTalk = true;
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
    IEnumerator NpcDialogs2()
    {
        imagemFundo.SetActive(true);
        canTalk = false;
        npcDialog = true;

        podePassar = false;

        Dialog.dialogoB = true;
        ataque.DesativarAtaque();


        foreach (char letter in dialogNpc2[index].ToCharArray())
        {
            textDisplay.text += letter;
            imagemDialog.SetActive(true);
            yield return new WaitForSeconds(typingSpeed);
        }


        index++;
        typingSpeed = typingSpeedReal;
    }
    IEnumerator NpcDialogs3()
    {
        imagemFundo.SetActive(true);
        canTalk = false;
        npcDialog = true;

        podePassar = false;

        Dialog.dialogoB = true;
        ataque.DesativarAtaque();


        foreach (char letter in dialogNpc3[index].ToCharArray())
        {
            textDisplay.text += letter;
            imagemDialog.SetActive(true);
            yield return new WaitForSeconds(typingSpeed);
        }


        index++;
        typingSpeed = typingSpeedReal;
    }
    IEnumerator NpcDialogs4()
    {
        imagemFundo.SetActive(true);
        canTalk = false;
        npcDialog = true;

        podePassar = false;

        Dialog.dialogoB = true;
        ataque.DesativarAtaque();


        foreach (char letter in dialogNpc4[index].ToCharArray())
        {
            textDisplay.text += letter;
            imagemDialog.SetActive(true);
            yield return new WaitForSeconds(typingSpeed);
        }


        index++;
        typingSpeed = typingSpeedReal;
    }
    IEnumerator NpcDialogs5()
    {
        imagemFundo.SetActive(true);
        canTalk = false;
        npcDialog = true;

        podePassar = false;

        Dialog.dialogoB = true;
        ataque.DesativarAtaque();


        foreach (char letter in dialogNpc5[index].ToCharArray())
        {
            textDisplay.text += letter;
            imagemDialog.SetActive(true);
            yield return new WaitForSeconds(typingSpeed);
        }


        index++;
        typingSpeed = typingSpeedReal;
    }
    IEnumerator NpcDialogs6()
    {
        imagemFundo.SetActive(true);
        canTalk = false;
        npcDialog = true;

        podePassar = false;

        Dialog.dialogoB = true;
        ataque.DesativarAtaque();


        foreach (char letter in dialogNpc6[index].ToCharArray())
        {
            textDisplay.text += letter;
            imagemDialog.SetActive(true);
            yield return new WaitForSeconds(typingSpeed);
        }


        index++;
        typingSpeed = typingSpeedReal;
    }
    IEnumerator NpcDialogs7()
    {
        imagemFundo.SetActive(true);
        canTalk = false;
        npcDialog = true;

        podePassar = false;

        Dialog.dialogoB = true;
        ataque.DesativarAtaque();


        foreach (char letter in dialogNpc7[index].ToCharArray())
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

        if (Jogador_Status.mortes == 0)
        {
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
                    stylist.stylistCanvas.SetActive(true);
                    imagemDialog.SetActive(false);
                    imagemFundo.SetActive(false);
                }
            }
        }
        else if (Jogador_Status.mortes == 1)
        {
            if (npcDialog)
            {
                if (index < dialogNpc2.Length)
                {
                    textDisplay.text = "";
                    StartCoroutine(NpcDialogs2());
                }
                else
                {
                    textDisplay.text = "";
                    ataque.AtivarAtaque();
                    Dialog.dialogoB = false;
                    npcDialog = false;
                    stylist.stylistCanvas.SetActive(true);
                    imagemDialog.SetActive(false);
                    imagemFundo.SetActive(false);
                }
            }
        }
        else if (Jogador_Status.mortes == 2)
        {
            if (npcDialog)
            {
                if (index < dialogNpc3.Length)
                {
                    textDisplay.text = "";
                    StartCoroutine(NpcDialogs3());
                }
                else
                {
                    textDisplay.text = "";
                    ataque.AtivarAtaque();
                    Dialog.dialogoB = false;
                    npcDialog = false;
                    stylist.stylistCanvas.SetActive(true);
                    imagemDialog.SetActive(false);
                    imagemFundo.SetActive(false);
                }
            }
        }
        else if (Jogador_Status.mortes == 3)
        {
            if (npcDialog)
            {
                if (index < dialogNpc4.Length)
                {
                    textDisplay.text = "";
                    StartCoroutine(NpcDialogs4());
                }
                else
                {
                    textDisplay.text = "";
                    ataque.AtivarAtaque();
                    Dialog.dialogoB = false;
                    npcDialog = false;
                    stylist.stylistCanvas.SetActive(true);
                    imagemDialog.SetActive(false);
                    imagemFundo.SetActive(false);
                }
            }
        }
        else if (Jogador_Status.mortes == 4)
        {
            if (npcDialog)
            {
                if (index < dialogNpc5.Length)
                {
                    textDisplay.text = "";
                    StartCoroutine(NpcDialogs5());
                }
                else
                {
                    textDisplay.text = "";
                    ataque.AtivarAtaque();
                    Dialog.dialogoB = false;
                    npcDialog = false;
                    stylist.stylistCanvas.SetActive(true);
                    imagemDialog.SetActive(false);
                    imagemFundo.SetActive(false);
                }
            }
        }
        else if (Jogador_Status.mortes == 5)
        {
            if (npcDialog)
            {
                if (index < dialogNpc6.Length)
                {
                    textDisplay.text = "";
                    StartCoroutine(NpcDialogs6());
                }
                else
                {
                    textDisplay.text = "";
                    ataque.AtivarAtaque();
                    Dialog.dialogoB = false;
                    npcDialog = false;
                    stylist.stylistCanvas.SetActive(true);
                    imagemDialog.SetActive(false);
                    imagemFundo.SetActive(false);
                }
            }
        }
        else if (Jogador_Status.mortes == 6)
        {
            if (npcDialog)
            {
                if (index < dialogNpc7.Length)
                {
                    textDisplay.text = "";
                    StartCoroutine(NpcDialogs7());
                }
                else
                {
                    textDisplay.text = "";
                    ataque.AtivarAtaque();
                    Dialog.dialogoB = false;
                    npcDialog = false;
                    stylist.stylistCanvas.SetActive(true);
                    imagemDialog.SetActive(false);
                    imagemFundo.SetActive(false);
                }
            }
        }
    }
}
