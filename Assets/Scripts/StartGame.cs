/*****************************************************************************
// File Name : StartGame.cs
// Author : Josephine Qualls
// Creation Date : March 14, 2025
//
// Brief Description : This program lets the player go to the first level
                       after pressing the start button.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    /// <summary>
    /// Begins the game
    /// </summary>
    public void StartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
