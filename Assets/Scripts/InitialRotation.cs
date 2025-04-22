/*****************************************************************************
// File Name : InitialRotation.cs
// Author : Josephine Qualls
// Creation Date : April 21, 2025
//
// Brief Description : Turns the player 180 within the first level. Currently doesn't work.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialRotation : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 3.0f;
    private Vector3 targetAngles;
    private Quaternion initialRotation;

    /// <summary>
    /// Holds initial values and the target value of rotation
    /// </summary>
    private void Start()
    {
        targetAngles = transform.eulerAngles + 180f * Vector3.up;
        initialRotation = transform.rotation;
    }

    /// <summary>
    /// Routine to turn player
    /// </summary>
    /// <param name="startRotation"></param>
    /// <param name="endRotation"></param>
    /// <returns></returns>
    IEnumerator RotateTweening(Quaternion startRotation, Quaternion endRotation)
    {
            float elapsedTime = 0f;
            while (elapsedTime < 1f)
            {
                transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime);
                elapsedTime += Time.deltaTime / rotateSpeed;
                yield return null;
            }
            transform.rotation = endRotation; // Ensure we reach the target exactly
    }

    /// <summary>
    /// Runs rotation routine
    /// </summary>
    private void Update()
    {
        if(targetAngles != Vector3.zero)
        {
            StartCoroutine(RotateTweening(initialRotation, Quaternion.Euler(targetAngles)));
        }
        
    }
}
