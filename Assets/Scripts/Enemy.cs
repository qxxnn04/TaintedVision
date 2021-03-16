using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    private Player player;

    public int damage = 20;




    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnCollisionEnter(Collision col)
    {
      
        //If the object that triggered this collision is tagged "bullet"
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

}




