using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashWall : MonoBehaviour
{
    public static bool dashWall = false;
    [SerializeField] GameObject dashImage;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dashWall = true;

        }

        if (other.gameObject.tag == "Player" && dashWall == true)
        {
            StartCoroutine(TimeImageDash());
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
