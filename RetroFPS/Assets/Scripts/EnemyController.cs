using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public GameObject explosion;
    public float playerRange = 10f; // how close player needs to be for the eneime to start moving towards player
    public Rigidbody2D rb;
    
    protected int health { get; set; }
    protected float movespeed { get; set; }

    public bool shouldShoot;

    public float fireRate = .5f;
    private float shotCounter;
    public GameObject bullet;
    public Transform FirePoint;
    public AudioClip deadfx;

    void Update()
    {
        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position)< playerRange) //calling the factory method 
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;
            rb.velocity = playerDirection.normalized * movespeed;

            if(shouldShoot)
            {
                shotCounter -= Time.deltaTime;
                if(shotCounter <= 0)
                {
                    Instantiate(bullet, FirePoint.position, FirePoint.rotation);
                    shotCounter = fireRate;
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public virtual void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            AudioManager.Instance.PlaySFX(deadfx, 3.0f);
        }
    }
}
