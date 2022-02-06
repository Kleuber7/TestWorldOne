using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashWall : MonoBehaviour
{
    public static bool dashWall = false;
    [SerializeField] private GameObject dashImage;
    [SerializeField] private GameObject firstDash, secondDash;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dashWall = true;

        }
        if (other.gameObject.tag == "Player" && dashWall == true && gameObject.name == "ParedeDash")
        {
            StartCoroutine(TimeImageDash());
            firstDash.SetActive(true);
            secondDash.SetActive(false);
        }
        else if (other.gameObject.tag == "Player" && dashWall == true && gameObject.name == "WallDashBack")
        {
            firstDash.SetActive(false);
            secondDash.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dashWall = false;

        }
    }

    IEnumerator TimeImageDash()
    {
        dashImage.SetActive(true);
        yield return new WaitForSeconds(2f);
        dashImage.SetActive(false);
    }

}
