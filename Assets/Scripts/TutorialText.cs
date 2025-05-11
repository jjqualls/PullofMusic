/*****************************************************************************
// File Name : TutorialText.cs
// Author : Josephine Qualls
// Creation Date : May 07, 2025
//
// Brief Description : Enables the tutorial text when the player slides over it.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    //the text for that part of the tutorial
    [SerializeField] private TextMeshProUGUI movementText;

    /// <summary>
    /// Shows the text
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(movementText != null)
        {
            movementText.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Hides the text
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if(movementText != null)
        {
            movementText.gameObject.SetActive(false);
        }
    }

}
