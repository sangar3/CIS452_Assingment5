/*
     * (Santiago Garcia II)
     * (Door2.cs)
     * (Assignment 5)
     * (This is the factory where the eneimes are created to shoot at the player )
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    public Transform doorModel;
    public GameObject colObject;
    private bool shouldOpen;
    public float openSpeed;
    public GameObject quest2;
    public GameObject quest3;
    public GameObject bossroom;
    public AudioClip quest2completefx;
    void Update()
    {
        if (shouldOpen && doorModel.position.z != 1f)
        {
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 1f), openSpeed * Time.deltaTime); // changing Z position of door

            if (doorModel.position.z == 1f)
            {
                colObject.SetActive(false);
                Debug.Log("Player can walk through door1");
                quest2.SetActive(false);
                quest3.SetActive(true);
                bossroom.SetActive(true);
                AudioManager.Instance.PlaySFX(quest2completefx, 3.0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldOpen = false;
        }
    }
}
