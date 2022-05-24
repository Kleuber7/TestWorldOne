using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoAnimation : MonoBehaviour
{
    public bool walk;
    public bool pulo;
    public Image arteWalk;
    public Image artePulo;
    public SpriteRenderer spriteAnimator;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        walk = true;
        animator.SetBool("Walk", true);
        pulo = false;
        animator.SetBool("Pulo", false);
    }

    // Update is called once per frame
    void Update()
    {
         if(walk)
        {
            Walk();
        }
        if(pulo)
        {
            Pula();
        }
    }
    public void Walk()
    {
        animator.SetBool("Walk", true);
        animator.SetBool("Pulo", false);        
        artePulo.gameObject.SetActive(false);
        arteWalk.gameObject.SetActive(true);
        arteWalk.sprite = spriteAnimator.sprite;
    }
    public void Pula()
    {
        animator.SetBool("Walk", false);
        animator.SetBool("Pulo", true);
        arteWalk.gameObject.SetActive(false);
        artePulo.gameObject.SetActive(true);
        artePulo.sprite = spriteAnimator.sprite;
    }
}
