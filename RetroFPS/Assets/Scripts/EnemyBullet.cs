using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public int DamageAmount;
    public float bulletSpeed;

    public Rigidbody2D rb;
    private Vector3 direction;
    
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        direction = direction * bulletSpeed;
    }

    void Update()
    {
        rb.velocity = direction * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.TakeDamage(DamageAmount);

            Destroy(gameObject);
        }

    }
}
