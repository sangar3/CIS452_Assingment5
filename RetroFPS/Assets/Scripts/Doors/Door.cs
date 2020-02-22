using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorModel;
    public GameObject colObject;
    private bool shouldOpen;
    public float openSpeed;
    public GameObject quest1;
    public GameObject quest2;
    public GameObject room;
    public AudioClip questcompletefx;
    void Update()
    {
        if (shouldOpen && doorModel.position.z != 1f)
        {
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 1f), openSpeed * Time.deltaTime); // changing Z position of door

            if (doorModel.position.z == 1f)
            {
                colObject.SetActive(false);
                Debug.Log("Player can walk through door1");
                quest1.SetActive(false);
                quest2.SetActive(true);
                room.SetActive(true);
                AudioManager.Instance.PlaySFX(questcompletefx, 3.0f);
            }
        }

        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
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
