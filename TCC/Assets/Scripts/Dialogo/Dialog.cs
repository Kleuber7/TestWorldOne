using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences, sentences2, sentences3, sentences4, sentences5, sentences6, sentences7;
    public int index;
    public float typingSpeed, typingSpeedReal, typingSpeedAcelerado = -6;

    public Andar andar;
    public AtaqueBasico ataque;

    public GameObject imagemDialog;
    public GameObject imagemFundo;
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
        AudioManager.canChange = true;

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
        else if (scriptable.FirstTime)
        {
            StartCoroutine(VideoPlay());
        }
        else if (Jogador_Status.mortes == 1)
        {
            StartCoroutine(Type2());
        }
        else if (Jogador_Status.mortes == 2)
        {
            StartCoroutine(Type3());
        }
        else if (Jogador_Status.mortes == 3)
        {
            StartCoroutine(Type4());
        }
        else if (Jogador_Status.mortes == 4)
        {
            StartCoroutine(Type5());
        }
        else if (Jogador_Status.mortes == 5)
        {
            StartCoroutine(Type6());
        }
        else if (Jogador_Status.mortes == 6)
        {
            StartCoroutine(Type7());
        }
    }

    void Update()
    {
        FirstDialog();
        

        if (scriptable.FirstTime)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.R))
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
                if (Jogador_Status.mortes == 0)
                {
                    if (index < sentences.Length)
                    {
                        if (textDisplay.text == sentences[index])
                        {
                            podePassar = true;
                        }
                    }
                }
                else if (Jogador_Status.mortes == 1)
                {
                    if (dialogoB)
                    {
                        if (index < sentences2.Length)
                        {
                            if (textDisplay.text == sentences2[index] && sentenca)
                            {
                                podePassar = true;
                            }
                        }
                    }
                }
                else if (Jogador_Status.mortes == 2)
                {
                    if (dialogoB)
                    {
                        if (index < sentences3.Length)
                        {
                            if (textDisplay.text == sentences3[index] && sentenca)
                            {
                                podePassar = true;
                            }
                        }
                    }
                }
                else if (Jogador_Status.mortes == 3)
                {
                    if (dialogoB)
                    {
                        if (index < sentences4.Length)
                        {
                            if (textDisplay.text == sentences4[index] && sentenca)
                            {
                                podePassar = true;
                            }
                        }
                    }
                }
                else if (Jogador_Status.mortes == 4)
                {
                    if (dialogoB)
                    {
                        if (index < sentences5.Length)
                        {
                            if (textDisplay.text == sentences5[index] && sentenca)
                            {
                                podePassar = true;
                            }
                        }
                    }
                }
                else if (Jogador_Status.mortes == 5)
                {
                    if (dialogoB)
                    {
                        if (index < sentences6.Length)
                        {
                            if (textDisplay.text == sentences6[index] && sentenca)
                            {
                                podePassar = true;
                            }
                        }
                    }
                }
                else if (Jogador_Status.mortes == 6)
                {
                    if (dialogoB)
                    {
                        if (index < sentences7.Length)
                        {
                            if (textDisplay.text == sentences7[index] && sentenca)
                            {
                                podePassar = true;
                            }
                        }
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
    IEnumerator Type3()
    {
        imagemFundo.SetActive(true);
        sentenca = true;
        podePassar = false;

        dialogoB = true;
        ataque.DesativarAtaque();

        foreach (char letter in sentences3[index].ToCharArray())
        {
            textDisplay.text += letter;
            imagemDialog.SetActive(true);
            yield return new WaitForSeconds(typingSpeed);
        }

        index++;

        typingSpeed = typingSpeedReal;
    }
    IEnumerator Type4()
    {
        imagemFundo.SetActive(true);
        sentenca = true;
        podePassar = false;

        dialogoB = true;
        ataque.DesativarAtaque();

        foreach (char letter in sentences4[index].ToCharArray())
        {
            textDisplay.text += letter;
            imagemDialog.SetActive(true);
            yield return new WaitForSeconds(typingSpeed);
        }

        index++;

        typingSpeed = typingSpeedReal;
    }
    IEnumerator Type5()
    {
        imagemFundo.SetActive(true);
        sentenca = true;
        podePassar = false;

        dialogoB = true;
        ataque.DesativarAtaque();

        foreach (char letter in sentences5[index].ToCharArray())
        {
            textDisplay.text += letter;
            imagemDialog.SetActive(true);
            yield return new WaitForSeconds(typingSpeed);
        }

        index++;

        typingSpeed = typingSpeedReal;
    }
    IEnumerator Type6()
    {
        imagemFundo.SetActive(true);
        sentenca = true;
        podePassar = false;

        dialogoB = true;
        ataque.DesativarAtaque();

        foreach (char letter in sentences6[index].ToCharArray())
        {
            textDisplay.text += letter;
            imagemDialog.SetActive(true);
            yield return new WaitForSeconds(typingSpeed);
        }

        index++;

        typingSpeed = typingSpeedReal;
    }
    IEnumerator Type7()
    {
        imagemFundo.SetActive(true);
        sentenca = true;
        podePassar = false;

        dialogoB = true;
        ataque.DesativarAtaque();

        foreach (char letter in sentences7[index].ToCharArray())
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
        else if (Jogador_Status.mortes == 1 && sentenca)
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
        else if (Jogador_Status.mortes == 2 && sentenca)
        {
            if (index < sentences3.Length)
            {
                textDisplay.text = "";
                StartCoroutine(Type3());
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
        else if (Jogador_Status.mortes == 3 && sentenca)
        {
            if (index < sentences4.Length)
            {
                textDisplay.text = "";
                StartCoroutine(Type4());
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
        else if (Jogador_Status.mortes == 4 && sentenca)
        {
            if (index < sentences5.Length)
            {
                textDisplay.text = "";
                StartCoroutine(Type5());
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
        else if (Jogador_Status.mortes == 5 && sentenca)
        {
            if (index < sentences6.Length)
            {
                textDisplay.text = "";
                StartCoroutine(Type6());
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
        else if (Jogador_Status.mortes == 6 && sentenca)
        {
            if (index < sentences7.Length)
            {
                textDisplay.text = "";
                StartCoroutine(Type7());
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

    
  
}
