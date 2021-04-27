﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public AudioSource Scream;
    public GameObject ThePlayer;
    public GameObject JumpCam;
    public GameObject Crawler;

    [Header("Visuals")]
    public Camera playerCamera;
    public GameObject bulletPrefab;

    [Header("Gameplay")]
    public int initialHealth = 100;
    public int initialScore = 24;




    private int health;
    public int Health { get { return health; } }
    private int score;
    public int Score { get { return score; } }

    public Enemy enemy;

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(2.03f);
        //ThePlayer.SetActive(true);
        JumpCam.SetActive(false);
        // FlashIng.SetActive(false);

    }

    IEnumerator DeactivateEnemy()
    {
        yield return new WaitForSeconds(3.03f);
        //ThePlayer.SetActive(true);
        Crawler.SetActive(false);
        // FlashIng.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        health = 100;
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "collectable")
        {
            Debug.Log("hit");

            Collectable collectable = collision.gameObject.GetComponent<Collectable>();

            score += collectable.score;

            Destroy(collectable.gameObject);

        }
        if (collision.gameObject.tag == "Enemy")
        {

            SceneManager.LoadScene("menu");

        }


        if (collision.gameObject.tag == "jumpscare")
        {

            //Scream.Play();
            JumpCam.SetActive(true);
            //ThePlayer.SetActive(false);
            //FlashIng.SetActive(true);
            StartCoroutine(EndJump());
        }


        if (collision.gameObject.tag == "CrawlerTrigger")
        {

            Debug.Log("hit");
            Crawler.SetActive(true);
            //ThePlayer.SetActive(false);
            StartCoroutine(DeactivateEnemy());

        }


    }
}




