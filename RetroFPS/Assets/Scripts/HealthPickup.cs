using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int HealthAmount = 25;

    public AudioClip pickupfx;



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("trigger");
            PlayerController.instance.AddHealth(HealthAmount);
           
            Destroy(gameObject);
            AudioManager.Instance.PlaySFX(pickupfx, 3.0f);
        }

    }
}
