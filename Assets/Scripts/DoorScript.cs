/*****************************************************************************
// File Name : DoorScript.cs
// Author : Josephine Qualls
// Creation Date : March 19, 2025
//
// Brief Description : This program lets the player move onto the next level
                       when they go through the door.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    /// <summary>
    /// Brings player to the next level.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Touched");
        }
    }
}
