/*****************************************************************************
// File Name : Credits.cs
// Author : Josephine Qualls
// Creation Date : May 11, 2025
//
// Brief Description : Controls the Credits screen in the main menu.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject creditsScreen;
    [SerializeField] private GameObject titleScreen;

    /// <summary>
    /// Opens credits screen
    /// </summary>
    public void OpenMenu()
    {
        creditsScreen.SetActive(true);
        titleScreen.SetActive(false);
    }

    /// <summary>
    /// Closes credits screen with close button
    /// </summary>
    public void CloseMenu()
    {
        creditsScreen.SetActive(false);
        titleScreen.SetActive(true);
    }
}
