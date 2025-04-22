/*****************************************************************************
// File Name : HowToPlayMenu.cs
// Author : Josephine Qualls
// Creation Date : April 19, 2025
//
// Brief Description : Controls the How to Play menu in mazes.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HowToPlayMenu : MonoBehaviour
{

    [SerializeField] private GameObject howToPlayMenu;
    [SerializeField] private GameObject titleScreen;

    /// <summary>
    /// Opens how to play menu by pressing the relevant button
    /// </summary>
    public void OpenMenu()
    {
        howToPlayMenu.SetActive(true);
        titleScreen.SetActive(false);
    }

    /// <summary>
    /// Closes how to play menu with close button
    /// </summary>
    public void CloseMenu() 
    { 
        howToPlayMenu.SetActive(false);
        titleScreen.SetActive(true);
    }
}
