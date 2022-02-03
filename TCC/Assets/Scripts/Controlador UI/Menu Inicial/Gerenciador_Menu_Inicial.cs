using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gerenciador_Menu_Inicial : MonoBehaviour
{
    public GameObject   Painel_Configuração;
    void Start()
    {
        Painel_Configuração.SetActive(false);
    }
    public void Ativar_Configuração()
    {
        Painel_Configuração.SetActive(true);
    }
    public void Ativar_Seleção_De_Classe()
    {
        Painel_Configuração.SetActive(false);
    }

    public void Voltar_Menu_Inicial()
    {
        Painel_Configuração.SetActive(false);
    }
}
