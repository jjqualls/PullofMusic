/*****************************************************************************
// File Name : StickyPlatform.cs
// Author : Josephine Qualls
// Creation Date : March 21, 2025
//
// Brief Description : This program sticks the player to the platform they're on.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private float rotateSpeed = 3.0f;

    /// <summary>
    /// The player rotates depending on what kind of platform they're on
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.rotation = transform.rotation;
            
            //conditional to set rotation of x and y and z
            //makes sure that x and y are always zeroed
            if (collision.gameObject.transform.rotation.y > 0 || collision.gameObject.transform.rotation.y < 0)
            {
                //in case y rotation is 90 when x and z are 0
                if (collision.gameObject.transform.rotation.x == 0
                    && collision.gameObject.transform.rotation.z == 0)
                {
                    if (controller.GetAngle() > 0)
                    {
                        collision.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (controller.GetAngle() < 0)
                    {
                        collision.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                    }
                }
                else
                {
                    collision.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90 * controller.GetAngle());
                }
            }
            else if (collision.gameObject.transform.rotation.x == 0
                    && collision.gameObject.transform.rotation.z == 0) //in case x and z are 0 when y is also 0
            {
                if (controller.GetAngle() > 0)
                {
                    collision.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (controller.GetAngle() < 0)
                {
                    collision.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
            else
            {
                collision.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90 * controller.GetAngle());
            }

        }
        
    }

    /// <summary>
    /// Routine to turn player
    /// </summary>
    /// <param name="startRotation"></param>
    /// <param name="endRotation"></param>
    /// <returns></returns>
    /*IEnumerator RotateTweening(Quaternion startRotation, Quaternion endRotation)
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

    StartCoroutine(RotateTweening(collision.gameObject.transform.rotation,
                            Quaternion.Euler(0, 0, 0)));*/

}
