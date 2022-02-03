using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AtaqueADistancia : MonoBehaviour
{
    [SerializeField] private Transform pontoDisparo;
    [SerializeField] private GameObject prefabProjetil;
    [SerializeField] private Vector3 direcaoDisparo;
    [SerializeField] private float cdShoot;
    private PLATiro tiro;
    public bool ataqueADistancia;
    [SerializeField] private bool cdBoolShoot = true;
    private void Update()
    {
        RangedAttack();
    }

    void RangedAttack()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            ataqueADistancia = true;
            //if (Input.GetMouseButtonDown(0))
            //{
            if (cdBoolShoot)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                {
                    tiro = Instantiate(prefabProjetil, pontoDisparo.position, Quaternion.identity).GetComponent<PLATiro>();
                    direcaoDisparo = hit.point - tiro.gameObject.transform.position;
                    tiro.direcao = direcaoDisparo;
                    tiro.atirou = true;
                    CDShoot();
                }
            }
            //}
        }
        else
        {
            ataqueADistancia = false;
        }
    }

    public async void CDShoot()
    {
        await CDShootAsync();
    }
    public async Task CDShootAsync()
    {
        cdBoolShoot = false;
        await Task.Delay(1000 * (int)cdShoot);
        cdBoolShoot = true;
    }
}
