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
    public int initialAmmo = 24;
   

    public float knockbackForce = 10;

    private int health;
    public int Health { get { return health; } }
    private int ammo;
    public int Ammo { get { return ammo; } }

    public AmmoCrate ammoCrate;

    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        ammo = 24;
        health = 100;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            ObjectPoolingManager.Instance.GetBullet();
            if (ammo > 0)
            {
                ammo--;
                GameObject bulletObject = ObjectPoolingManager.Instantiate(bulletPrefab);
                bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
                bulletObject.transform.forward = playerCamera.transform.forward;
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Ammo")
        {
            Debug.Log("ammo"); 
            ammo += ammoCrate.ammo;

            Destroy(ammoCrate.gameObject);

        }
        if (collision.gameObject.tag == "Enemy")
        {

            SceneManager.LoadScene("menu");

        }

    }
}
 

