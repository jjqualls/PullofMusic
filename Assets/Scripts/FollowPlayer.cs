/*****************************************************************************
// File Name : FollowPlayer.cs
// Author : Josephine Qualls
// Creation Date : March 6, 2025
//
// Brief Description : This program makes the camera follow the player from a distance.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;

    /// <summary>
    /// Camera follows the player from a distance.
    /// </summary>
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
