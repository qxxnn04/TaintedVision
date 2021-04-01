using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Visuals")]
    public Camera playerCamera;
    public GameObject bulletPrefab;

    [Header("Gameplay")]
    public int initialHealth = 100;
    public int initialScore = 24;
   

    public float knockbackForce = 10;

    private int health;
    public int Health { get { return health; } }
    private int score;
    public int Score { get { return score; } }

    public Enemy enemy;

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
            Collectable collectable = collision.gameObject.GetComponent<Collectable>();
           
            score += collectable.score;

            Destroy(collectable.gameObject);

        }
        if (collision.gameObject.tag == "Enemy")
        {

            SceneManager.LoadScene("menu");

        }

    }
}
 

