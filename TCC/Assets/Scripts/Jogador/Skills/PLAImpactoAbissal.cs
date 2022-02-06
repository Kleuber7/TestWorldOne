using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAImpactoAbissal : MonoBehaviour
{
    [SerializeField] private Transform centroDoImpacto;
    [SerializeField] private float areaDoImpacto;
    [SerializeField] private LayerMask layerImpacto;
    [SerializeField] private bool atingido;
    [SerializeField] public Collider[] inimigos;
    [SerializeField] private float danoDoImpacto;
    [SerializeField] private float tempoDeStun;

    private void Update() 
    {
        inimigos = Physics.OverlapSphere(centroDoImpacto.position, areaDoImpacto, layerImpacto);
    }

    public void ImpactoAbissal(Collider[] inimigosAtingidos)
    {
        foreach(Collider inimigo in inimigosAtingidos)
        {
            if(inimigo.gameObject.tag == "Inimigo")
            {
                inimigo.gameObject.GetComponent<INIStatus>().TomarDano(danoDoImpacto);
                StartCoroutine(TempoStun(inimigo));
            }
            if(inimigo.gameObject.tag == "Boboneco")
            {
                inimigo.gameObject.GetComponent<StatusBoboneco>().TomarDano(danoDoImpacto);
            }
        }
    }

    public IEnumerator TempoStun(Collider inimigo)
    {
        inimigo.gameObject.GetComponent<INIStatus>().SetStunado(true);
        yield return new WaitForSeconds(tempoDeStun);
        inimigo.gameObject.GetComponent<INIStatus>().SetStunado(false);
        inimigos = null;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(centroDoImpacto.position, areaDoImpacto);
    }
}
