using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerAttack : MonoBehaviour
{
    [SerializeField] private AudioSource attackOne;

    public void PlayAttackOne()
    {
        attackOne.Play();
    }
}
