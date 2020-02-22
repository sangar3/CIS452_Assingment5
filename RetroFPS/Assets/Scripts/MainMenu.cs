﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Game loaded");

    }
    public void backmainmenu()
    {
        SceneManager.LoadScene("mainmenu");
        Debug.Log("mainmenu loaded");
    }
}
