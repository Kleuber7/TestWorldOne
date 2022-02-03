using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classe_Magica : MonoBehaviour
{
    public Jogador_Status Jogador_Atributos;
    public enum Classe{Necromante,Invoker}
    public enum Arma{Cajado,Grimorio}

    public bool ProximaClasse;
    

    [System.Serializable]
    public struct StructAtibutos
    {
        public Classe   classeAtual;
        public Arma     armaAtual;

        [System.Serializable]
        public struct StructAtributosDeMecanica
        {
            public Mesh NecromanteMesh;
            public Mesh InvokerMesh;
            public Material NecromanteMaterial;
            public Material InvokerMaterial;
            

            [Tooltip("Permite o jogado trocar sua classe essa varial so e habilitade perto da entidade !!! 0 não troca 1 pode trocar !!!")]
            public int pode_trocar_classe;
        }    
        public StructAtributosDeMecanica mecanica;
    }
    public StructAtibutos Atributos_Da_Classe;

    public void Start()
    {
        ProximaClasse = true;
    }
    public void Update()
    {  

    }
#region (Verificação de troca de classes)
    public void Trocar_Classe()
    {
        if(Atributos_Da_Classe.classeAtual == Classe.Necromante && ProximaClasse == true)
        {
            StartCoroutine(Trocar_Para_Invoker());
        }else if(Atributos_Da_Classe.classeAtual == Classe.Invoker && ProximaClasse == true)
        {
            StartCoroutine(Trocar_Para_Necromante());            
        }   
    }
    IEnumerator Trocar_Para_Invoker() 
    {
        ProximaClasse = false;
        Atributos_Da_Classe.classeAtual=Classe.Invoker;
        Atributos_Da_Classe.armaAtual = Arma.Grimorio;
        Jogador_Atributos.GetComponent<Renderer>().material = Atributos_Da_Classe.mecanica.InvokerMaterial;
        Jogador_Atributos.GetComponent<MeshFilter>().mesh= Atributos_Da_Classe.mecanica.InvokerMesh; 
        yield return new WaitForSeconds(2f);
        ProximaClasse = true;
    }
    IEnumerator Trocar_Para_Necromante()
    {
        ProximaClasse = false;
        Atributos_Da_Classe.classeAtual=Classe.Necromante;
        Atributos_Da_Classe.armaAtual = Arma.Cajado;
        Jogador_Atributos.GetComponent<Renderer>().material = Atributos_Da_Classe.mecanica.NecromanteMaterial;
        Jogador_Atributos.GetComponent<MeshFilter>().mesh= Atributos_Da_Classe.mecanica.NecromanteMesh; 
        yield return new WaitForSeconds(2f);
        ProximaClasse = true;
    }
#endregion
}