using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public AudioSource Scream;
    public GameObject ThePlayer;
    public GameObject JumpCam;
    public GameObject Crawler;
    public GameObject lastdoor;
    public GameObject Red;
    public GameObject Green;

    public int score;

    [Header("Visuals")]
    public Camera playerCamera;

    public int Score { get { return score; } }

    public Enemy enemy;

    public int endscore = 2;

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
    }




    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(sceneName: "endgame");
        }

        if (collision.gameObject.tag == "collectable")
        {
            

            Collectable collectable = collision.gameObject.GetComponent<Collectable>();

            score += collectable.score;

            Destroy(collectable.gameObject);

        }

        if (collision.gameObject.tag == "jumpscare")
        {

            Scream.Play();
            JumpCam.SetActive(true);
            //ThePlayer.SetActive(false);
            //FlashIng.SetActive(true);
            StartCoroutine(EndJump());
        }


        if (collision.gameObject.tag == "CrawlerTrigger")
        {

            
            Crawler.SetActive(true);
            //ThePlayer.SetActive(false);
            StartCoroutine(DeactivateEnemy());

        }

    }
    void Update()
    {
        if (score >= endscore)
        {
            Debug.Log("Finish");
            Red.SetActive(false);
            Green.SetActive(true);
            lastdoor.SetActive(false);
        }
    }


}




