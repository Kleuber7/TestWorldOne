using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogRun : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences, sentences2, sentences3, sentences4, sentences5, sentences6, sentences7, sentences8, sentences9, sentences10;
    public int index;
    public float typingSpeed, typingSpeedReal, typingSpeedAcelerado = -6;

    public Andar andar;
    public AtaqueBasico ataque;

    public GameObject imagemDialog;
    public GameObject imagemFundo;


    public bool podePassar, sentenca;

    public float timeVideo;

    void Start()
    {
        typingSpeedReal = typingSpeed;
        andar = GameObject.FindGameObjectWithTag("Player").GetComponent<Andar>();
        ataque = GameObject.FindGameObjectWithTag("Player").GetComponent<AtaqueBasico>();
        AudioManager.canChange = true;

        if (Jogador_Status.mortes == 0)
        {
            StartCoroutine(Type1());
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
        else if (Jogador_Status.mortes == 7)
        {
            StartCoroutine(Type8());
        }
        else if (Jogador_Status.mortes == 8)
        {
            StartCoroutine(Type9());
        }
        else if (Jogador_Status.mortes >= 9)
        {
            StartCoroutine(Type10());
        }
    }

    void Update()
    {
        FirstDialog();        
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

        if (Dialog.dialogoB)
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
                    if (Dialog.dialogoB)
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
                    if (Dialog.dialogoB)
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
                    if (Dialog.dialogoB)
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
                    if (Dialog.dialogoB)
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
                    if (Dialog.dialogoB)
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
                    if (Dialog.dialogoB)
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
                else if (Jogador_Status.mortes == 7)
                {
                    if (Dialog.dialogoB)
                    {
                        if (index < sentences8.Length)
                        {
                            if (textDisplay.text == sentences8[index] && sentenca)
                            {
                                podePassar = true;
                            }
                        }
                    }
                }
                else if (Jogador_Status.mortes == 8)
                {
                    if (Dialog.dialogoB)
                    {
                        if (index < sentences9.Length)
                        {
                            if (textDisplay.text == sentences9[index] && sentenca)
                            {
                                podePassar = true;
                            }
                        }
                    }
                }
                else if (Jogador_Status.mortes >= 9)
                {
                    if (Dialog.dialogoB)
                    {
                        if (index < sentences10.Length)
                        {
                            if (textDisplay.text == sentences10[index] && sentenca)
                            {
                                podePassar = true;
                            }
                        }
                    }
                }

            }
        }
    }

    IEnumerator Type1()
    {
        imagemFundo.SetActive(true);
        sentenca = true;
        podePassar = false;

        Dialog.dialogoB = true;
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

        Dialog.dialogoB = true;
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

        Dialog.dialogoB = true;
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

        Dialog.dialogoB = true;
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

        Dialog.dialogoB = true;
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

        Dialog.dialogoB = true;
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

        Dialog.dialogoB = true;
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
    IEnumerator Type8()
    {
        imagemFundo.SetActive(true);
        sentenca = true;
        podePassar = false;

        Dialog.dialogoB = true;
        ataque.DesativarAtaque();

        foreach (char letter in sentences8[index].ToCharArray())
        {
            textDisplay.text += letter;
            imagemDialog.SetActive(true);
            yield return new WaitForSeconds(typingSpeed);
        }

        index++;

        typingSpeed = typingSpeedReal;
    }
    IEnumerator Type9()
    {
        imagemFundo.SetActive(true);
        sentenca = true;
        podePassar = false;

        Dialog.dialogoB = true;
        ataque.DesativarAtaque();

        foreach (char letter in sentences9[index].ToCharArray())
        {
            textDisplay.text += letter;
            imagemDialog.SetActive(true);
            yield return new WaitForSeconds(typingSpeed);
        }

        index++;

        typingSpeed = typingSpeedReal;
    }
    IEnumerator Type10()
    {
        imagemFundo.SetActive(true);
        sentenca = true;
        podePassar = false;

        Dialog.dialogoB = true;
        ataque.DesativarAtaque();

        foreach (char letter in sentences10[index].ToCharArray())
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
                Dialog.dialogoB = false;
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
                Dialog.dialogoB = false;
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
                Dialog.dialogoB = false;
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
                Dialog.dialogoB = false;
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
                Dialog.dialogoB = false;
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
                Dialog.dialogoB = false;
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
                Dialog.dialogoB = false;
                imagemDialog.SetActive(false);
                imagemFundo.SetActive(false);
            }
        }
        else if (Jogador_Status.mortes == 7 && sentenca)
        {
            if (index < sentences8.Length)
            {
                textDisplay.text = "";
                StartCoroutine(Type8());
            }
            else
            {
                textDisplay.text = "";
                sentenca = false;
                ataque.AtivarAtaque();
                Dialog.dialogoB = false;
                imagemDialog.SetActive(false);
                imagemFundo.SetActive(false);
            }
        }
        else if (Jogador_Status.mortes == 8 && sentenca)
        {
            if (index < sentences9.Length)
            {
                textDisplay.text = "";
                StartCoroutine(Type9());
            }
            else
            {
                textDisplay.text = "";
                sentenca = false;
                ataque.AtivarAtaque();
                Dialog.dialogoB = false;
                imagemDialog.SetActive(false);
                imagemFundo.SetActive(false);
            }
        }
        else if (Jogador_Status.mortes >= 9 && sentenca)
        {
            if (index < sentences10.Length)
            {
                textDisplay.text = "";
                StartCoroutine(Type10());
            }
            else
            {
                textDisplay.text = "";
                sentenca = false;
                ataque.AtivarAtaque();
                Dialog.dialogoB = false;
                imagemDialog.SetActive(false);
                imagemFundo.SetActive(false);
            }
        }
    }


}

