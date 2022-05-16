using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tela_De_Load : MonoBehaviour
{
    public GameObject Painel_De_Load;
    public Slider Barra_Carregamento;
    public Text Texto_Do_Carregamento;
    public Sprite[] animatedImages;
    public Image animateImageObj;
    public float velocityImages = 40;
    public void Carregar_Scena(int IndexScena)
    {
        StopAllCoroutines();
        StartCoroutine(Carregamento_Da_Scnea(IndexScena));
    }
    public void Carregar_CenaInicio(int IndexScena)
    {
        StopAllCoroutines();
        StartCoroutine(Carregamento_Da_CenaInicio(IndexScena));
    }

    public void Carregar_Menu(int IndexScena)
    {
        StopAllCoroutines();
        StartCoroutine(Carregamento_Do_Menu(IndexScena));
    }


    IEnumerator Carregamento_Da_Scnea (int IndexScena)
    {
        AsyncOperation Carregamento = SceneManager.LoadSceneAsync(IndexScena);
        


        Painel_De_Load.SetActive(true);
        
        while (!Carregamento.isDone)
        {
            //float Atual_Progresao = Mathf.Clamp01(Carregamento.progress/0.9f);
            animateImageObj.sprite = animatedImages[(int)(Time.time * velocityImages) % animatedImages.Length];


            //Barra_Carregamento.value = Atual_Progresao;
            //Texto_Do_Carregamento.text = Atual_Progresao*100f+"%";
            DontDestroyOnLoad(GameManager.gameManager.gameObject);
            DontDestroyOnLoad(GameManager.gameManager.GetPlayer());
            DontDestroyOnLoad(GameManager.gameManager.info.gameObject);
            yield return null;
        }

        //DesligarLoadQuando acaba carregamento
        if(Carregamento.isDone)
        {
            Painel_De_Load.SetActive(false);
        }
    }


    IEnumerator Carregamento_Da_CenaInicio(int IndexScena)
    {
        AsyncOperation Carregamento = SceneManager.LoadSceneAsync(IndexScena);

        Painel_De_Load.SetActive(true);

        while (!Carregamento.isDone)
        {
            //float Atual_Progresao = Mathf.Clamp01(Carregamento.progress / 0.9f);
            animateImageObj.sprite = animatedImages[(int)(Time.time * velocityImages) % animatedImages.Length];
            //Barra_Carregamento.value = Atual_Progresao;
            //Texto_Do_Carregamento.text = Atual_Progresao * 100f + "%";
            DontDestroyOnLoad(GameManager.gameManager.gameObject);
            yield return null;
        }

        //DesligarLoadQuando acaba carregamento
        if (Carregamento.isDone)
        {
            Painel_De_Load.SetActive(false);
        }
    }

    IEnumerator Carregamento_Do_Menu(int IndexScena)
    {
        AsyncOperation Carregamento = SceneManager.LoadSceneAsync(IndexScena);

        Painel_De_Load.SetActive(true);

        while (!Carregamento.isDone)
        {
            //float Atual_Progresao = Mathf.Clamp01(Carregamento.progress / 0.9f);
            animateImageObj.sprite = animatedImages[(int)(Time.time * velocityImages) % animatedImages.Length];
            //Barra_Carregamento.value = Atual_Progresao;
            //Texto_Do_Carregamento.text = Atual_Progresao * 100f + "%";
            
            yield return null;
        }

        //DesligarLoadQuando acaba carregamento
        if (Carregamento.isDone)
        {
            Painel_De_Load.SetActive(false);
        }
    }

}
