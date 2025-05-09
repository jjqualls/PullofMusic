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
    [SerializeField] private Vector3 rightOffset;
    [SerializeField] private Vector3 leftOffset;
    [SerializeField] private Vector3 upsideDownOffset;

    /// <summary>
    /// Camera follows the player from a distance.
    /// </summary>
    void LateUpdate()
    {
        //different offsets dependent on player rotation
        if(player.transform.rotation == Quaternion.Euler(0,0,0))
        {
            transform.position = player.transform.position + offset;
        }
        else if(player.transform.rotation == Quaternion.Euler(0, 0, 180))
        {
            transform.position = player.transform.position + upsideDownOffset;
        }
        else if(player.transform.rotation == Quaternion.Euler(0, 0, -90))
        {
            transform.position = player.transform.position + leftOffset;
        }
        else if(player.transform.rotation == Quaternion.Euler(0, 0, 90))
        {
            transform.position = player.transform.position + rightOffset;
        }
        
    }
}
