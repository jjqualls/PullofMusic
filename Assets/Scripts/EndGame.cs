/*****************************************************************************
// File Name : EndGame.cs
// Author : Josephine Qualls
// Creation Date : March 19, 2025
//
// Brief Description : This program lets the player quit the game
                       after pressing the leave button.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;

        if (Application.isPlaying)
        {
            Application.Quit();
        }
    }
}
