/*
     * (Santiago Garcia II)
     * (RedSkull.cs)
     * (Assignment 5)
     * (The concrete porducts )
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RedSkull : EnemyController
{
    public GameObject youwin;
    void Start()
    {
        this.health = 15;
        this.movespeed = 1.5f;
    }

    public override void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            Debug.Log("You win");
            youwin.SetActive(true);
           

        }
    }

  
}
