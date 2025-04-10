/*****************************************************************************
// File Name : PlayerDeath.cs
// Author : Josephine Qualls
// Creation Date : March 19, 2025
//
// Brief Description : This program kills the player if they fall off the platform.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private float reloadTime = 1.5f;
    [SerializeField] private int dyingNegativeYValue = -10;
    [SerializeField] private int dyingPositiveYValue = 40;
    [SerializeField] private int dyingNegativeXValue = -20;
    [SerializeField] private int dyingPositiveXValue = 30;

    private bool isDead = false;

    /// <summary>
    /// Reloads the scene when player dies
    /// </summary>
    private void Death()
    {
        isDead = true;

        Invoke("ReloadScene", reloadTime);
    }

    /// <summary>
    /// Reloads the current scene
    /// </summary>
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Kills the player when they fall of the platform
    /// </summary>
    void Update()
    {
        if(transform.position.y < dyingNegativeYValue || 
            transform.position.y > dyingPositiveYValue ||
            transform.position.x < dyingNegativeXValue ||
            transform.position.x > dyingPositiveXValue && !isDead)
        {
            //Debug.Log("Y: " + transform.position.y);
            //Debug.Log("X: " + transform.position.x);
            Death();
        }
    }
}
