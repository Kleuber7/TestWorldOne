using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences, sentences2;
    public int index;
    public float typingSpeed, typingSpeedReal, typingSpeedAcelerado = -6;

    public Andar andar;
    public AtaqueBasico ataque;

    public GameObject imagemDialog;
    public GameObject imagemFundo;
    public GameObject continueButton;
    public ScriptablePlayer scriptable;
    public GameObject videoCanvas;
    public GameObject videoPlayer;

    public static bool dialogoB;

    public bool podePassar, sentenca;

    public float timeVideo;

    void Start()
    {
        typingSpeedReal = typingSpeed;
        andar = GameObject.FindGameObjectWithTag("Player").GetComponent<Andar>();
        ataque = GameObject.FindGameObjectWithTag("Player").GetComponent<AtaqueBasico>();

        if (Jogador_Status.mortes == 0 && !scriptable.FirstTime)
        {
            if (videoCanvas != null && videoPlayer != null)
            {
                videoCanvas.SetActive(false);
                videoPlayer.SetActive(false);
                StartCoroutine(Type1());
            }
            else
            {
                StartCoroutine(Type1());
            }
        }
        else if(scriptable.FirstTime)
        {
            StartCoroutine(VideoPlay());
        }
        else if (Jogador_Status.mortes >= 1)
        {
            StartCoroutine(Type2());
        }
    }

    void Update()
    {
        FirstDialog();
        DeathDialog();

        if(scriptable.FirstTime)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                videoCanvas.SetActive(false);
                videoPlayer.SetActive(false);
                scriptable.FirstTime = false;
                StartCoroutine(Type1());
            }
        }
    }


    void FirstDialog()
    {
        if (Jogador_Status.mortes == 0)
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

            if (dialogoB)
            {
                if (sentenca)
                {
                    if(index < sentences.Length)
                    {
                        if (textDisplay.text == sentences[index])
                        {
                            podePassar = true;
                            continueButton.SetActive(true);
                        }
                    }
                }
            }
            
        }
    }
    void DeathDialog()
    {
        if (Jogador_Status.mortes >= 1)
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

            if (dialogoB)
            {
                if(index < sentences2.Length)
                {
                    if (textDisplay.text == sentences2[index] && sentenca)
                    {
                        continueButton.SetActive(true);
                        podePassar = true;
                    }
                }
            }
            
        }
    }

    IEnumerator VideoPlay()
    {
        videoCanvas.SetActive(true);
        videoPlayer.SetActive(true);
        yield return new WaitForSeconds(timeVideo);
        StartCoroutine(Type1());
        scriptable.FirstTime = false;
        videoCanvas.SetActive(false);
        videoPlayer.SetActive(false);
    }
    IEnumerator Type1()
    {
        imagemFundo.SetActive(true);
        sentenca = true;
        podePassar = false;

        dialogoB = true;
        ataque.DesativarAtaque();


        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            imagemDialog.SetActive(true);
            yield return new WaitForSeconds(typingSpeed);
        }

        index++;
        typingSpeed = typingSpeedReal;
    }
    IEnumerator Type2()
    {
        imagemFundo.SetActive(true);
        sentenca = true;
        podePassar = false;

        dialogoB = true;
        ataque.DesativarAtaque();

        foreach (char letter in sentences2[index].ToCharArray())
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
        continueButton.SetActive(false);

        if (Jogador_Status.mortes == 0 && sentenca)
        {
            if (index < sentences.Length)
            {

                textDisplay.text = "";
                StartCoroutine(Type1());

            }
            else
            {
                textDisplay.text = "";
                sentenca = false;
                ataque.AtivarAtaque();
                dialogoB = false;
                imagemDialog.SetActive(false);
                imagemFundo.SetActive(false);
            }
        }
        if (Jogador_Status.mortes >= 1 && sentenca)
        {
            if (index < sentences2.Length)
            {
                textDisplay.text = "";
                StartCoroutine(Type2());
            }
            else
            {
                textDisplay.text = "";
                sentenca = false;
                ataque.AtivarAtaque();
                dialogoB = false;
                imagemDialog.SetActive(false);
                imagemFundo.SetActive(false);
            }
        }
    }

    #region TutorialInvoker
    //if (textDisplay.text == tutorialInvoker[index] && tutorialIn)
    //{

    //    podePassar = true;
    //    continueButton.SetActive(true);

    //    if (index == tutorialInvoker.Length - 1)
    //    {
    //        ataque.AtivarAtaque();
    //        dialogoB = false;
    //    }

    //}

    //public void TutorialInvoker()
    //{
    //    index = 0;
    //    StartCoroutine(TutorialInvok());
    //}
    //IEnumerator TutorialInvok()
    //{
    //    tutorialIn = true;
    //    sentenca = false;
    //    podePassar = false;

    //    dialogoB = true;
    //    ataque.DesativarAtaque();


    //    foreach (char letter in tutorialInvoker[index].ToCharArray())
    //    {
    //        textDisplay.text += letter;
    //        // imagemDialog.SetActive(true);
    //        yield return new WaitForSeconds(typingSpeed);
    //    }

    //    index++;
    //    typingSpeed = typingSpeedReal;
    //}

    //    if (tutorialIn && Jogador_Status.mortes == 0)
    //        {
    //            if (index<tutorialInvoker.Length)
    //            {
    //                textDisplay.text = "";
    //                StartCoroutine(TutorialInvok());
    //}
    //            else
    //{
    //    textDisplay.text = "";
    //}
    //        }

    #endregion
}
