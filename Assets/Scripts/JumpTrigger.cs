using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject Player;
    public GameObject JumpCam;
    public GameObject FlashIng;

    void OnTriggerEnter ()
    {
        Scream.Play();
        JumpCam.SetActive(true);
        Player.SetActive(false);
        FlashIng.SetActive(true);
        StartCoroutine(EndJump ());
    }

    IEnumerator EndJump ()
    {
        yield return new WaitForSeconds(2.03f);
        Player.SetActive(true);
        JumpCam.SetActive(false);
        FlashIng.SetActive(false);

    }

}
