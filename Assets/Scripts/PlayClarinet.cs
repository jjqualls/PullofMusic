/*****************************************************************************
// File Name : PlayClarinet.cs
// Author : Josephine Qualls
// Creation Date : March 27, 2025
//
// Brief Description : This program decides the player's gravity based on the keys pressed.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayClarinet : MonoBehaviour
{
    [SerializeField] private PlayerInput play;
    [SerializeField] private Rigidbody rb;

    private InputAction axisV;
    private InputAction axisH;

    [SerializeField] private Vector3 force = Vector3.down;
    [SerializeField] private float launchValue = 5;
    [SerializeField] private Vector3 launchVector;

    /// <summary>
    /// Enables the gravity manipulation
    /// </summary>
    void Awake()
    {
        play.currentActionMap.Enable();

        axisV = play.currentActionMap.FindAction("AxisVertical");
        axisH = play.currentActionMap.FindAction("AxisHorizontal");

        axisV.performed += AxisV_performed;
        axisH.performed += AxisH_performed;

        rb.useGravity = false;
    }

    /// <summary>
    /// Sets the gravity of the player based on the Up/Down arrows
    /// </summary>
    /// <param name="obj"></param>
    private void AxisV_performed(InputAction.CallbackContext obj)
    {
        float VAxisFound = axisV.ReadValue<float>();

        //launches player
        rb.velocity = launchVector;

        //gravity decided by the axes
        if (VAxisFound > 0)
        {
            force = Vector3.up;
        }
        else if (VAxisFound < 0)
        {
            force = Vector3.down;
        }
        
    }

    /// <summary>
    /// Sets the gravity of the player based on the Left/Right arrows
    /// </summary>
    /// <param name="obj"></param>
    private void AxisH_performed(InputAction.CallbackContext obj)
    {
        float HAxisFound = axisH.ReadValue<float>();

        //launches player
        rb.velocity = launchVector;

        //gravity decided by the axes
        if (HAxisFound > 0)
        {
            force = Vector3.right;
        }
        else if (HAxisFound < 0)
        {
            force = Vector3.left;
        }
    }

    /// <summary>
    /// Disables the gravity performance function.
    /// </summary>
    private void OnDestroy() 
    {
        axisV.performed -= AxisV_performed;
        axisH.performed -= AxisH_performed;
    }

    /// <summary>
    /// Consistent gravity presses down on the player, 
    /// and determines the launch direction for the player.
    /// </summary>
    void FixedUpdate()
    {
        launchVector = transform.parent.up * launchValue;

        rb.AddForce(force * rb.mass);
    }
}
