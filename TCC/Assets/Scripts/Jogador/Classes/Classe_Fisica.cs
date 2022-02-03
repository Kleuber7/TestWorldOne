using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classe_Fisica : MonoBehaviour
{
    public Jogador_Status Jogador_Atributos;
    public enum Classe{Metamorfo,Lunari}
    public enum Arma{Manopla,Khopesh}

    [System.Serializable]
    public struct StructAtibutos
    {
        public Classe classe_atual;
        public Arma arma_atual;
        [System.Serializable]
        public struct StructAtributosDeMecanica
        {
            [Tooltip("Permite o jogado trocar sua classe essa varial so e habilitade perto da entidade !!! 0 não troca 1 pode trocar !!!")]
            public int pode_trocar_classe;

            [Tooltip("O valor dessa variavel altera a força da skil do jogador e determina o level da mesma")]
            public int Poder1; 
        }    
        public StructAtributosDeMecanica mecanica;
    }
    public StructAtibutos atributos;
    public void Start()
    {
        atributos.mecanica.Poder1 = 1;
    }
    public void Update()
    {   
        
    }
#region (Verificação de troca de classes)
    public void Trocar_Arma()
    {
        if(atributos.classe_atual==Classe.Metamorfo)
        {
            atributos.arma_atual = Arma.Manopla;
        }else
        {
            atributos.arma_atual = Arma.Khopesh;
        }
    }
    public void Trocar_Classe()
    {
        if(atributos.mecanica.pode_trocar_classe==1)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                if(atributos.classe_atual==Classe.Metamorfo)
                {
                    atributos.classe_atual=Classe.Lunari;
                    Trocar_Arma();
                }else
                {
                    atributos.classe_atual=Classe.Metamorfo;
                    Trocar_Arma();
                }
            }
        }
    }
#endregion

    //Sera utilizado no botão de comprar Iskill para aumentar o nivel do Poder 1
    public void Subir_Nivel_Poder1()
    {
        atributos.mecanica.Poder1++;
    }
}