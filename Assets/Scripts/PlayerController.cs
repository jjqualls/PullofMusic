/*****************************************************************************
// File Name : PlayerController.cs
// Author : Josephine Qualls
// Creation Date : March 6, 2025
//
// Brief Description : This program moves the player and allows 
                       for the player to restart, quit, and pause the game.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float moveSpeed;
    private InputAction quit;
    private InputAction restart;
    private InputAction pause;
    private InputAction move;

    private Rigidbody rb;
    private Vector3 playerMovement;

    private int angle;

    /// <summary>
    /// Enable the action map and get the player's rigidbody
    /// </summary>
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput.currentActionMap.Enable();

        quit = playerInput.currentActionMap.FindAction("Quit");
        restart = playerInput.currentActionMap.FindAction("Restart");
        move = playerInput.currentActionMap.FindAction("Move");
        //pause = playerInput.currentActionMap.FindAction("Pause");

        quit.performed += Quit_performed;
        restart.performed += Restart_performed;
        move.performed += Move_performed;
        //pause.performed += Pause_performed; //until I have a pause menu setup

    }

    /// <summary>
    /// Gets the keyboard (WASD) value and updates the movement variable
    /// </summary>
    /// <param name="obj"></param>
    private void Move_performed(InputAction.CallbackContext obj)
    {
        Vector2 inputMovement = obj.ReadValue<Vector2>();
        playerMovement.x = inputMovement.x;
        playerMovement.z = inputMovement.y;
    }

    /// <summary>
    /// Calls the pause menu
    /// </summary>
    /// <param name="obj"></param>
    /// <exception cref="System.NotImplementedException"></exception>
    /*private void Pause_performed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }*/

    /// <summary>
    /// Restarts the level
    /// </summary>
    /// <param name="obj"></param>
    private void Restart_performed(InputAction.CallbackContext obj)
    {
        RestartGame();
    }

    /// <summary>
    /// Loads the scene from the beginning
    /// </summary>
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Quits the game
    /// </summary>
    /// <param name="obj"></param>
    private void Quit_performed(InputAction.CallbackContext obj)
    {
        //UnityEditor.EditorApplication.isPlaying = false;

        if (Application.isPlaying)
        {
            Application.Quit();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.CompareTag("Positive"))
        {
            angle = 1;
        }
        else if (other.gameObject.CompareTag("Negative"))
        {
            angle = -1;
        }
    }

    /// <summary>
    /// Getter method for the player's rotation direction.
    /// </summary>
    /// <returns></returns>
    public int GetAngle()
    {
        return angle;
    }

    /// <summary>
    /// Lets the player move
    /// </summary>
    void Update()
    {
        /*Vector3 moveVector = (playerMovement.x * transform.right) + (playerMovement.z * transform.forward);
        rb.velocity = new Vector3(moveVector.x, rb.velocity.y, moveVector.z);
        Debug.Log(playerMovement.x);*/
        rb.AddForce(transform.forward * playerMovement.z, ForceMode.Acceleration);
        rb.AddForce(transform.right * playerMovement.x, ForceMode.Acceleration);
    }

    private void OnDestroy()
    {
        quit.performed -= Quit_performed;
        restart.performed -= Restart_performed;
        //pause.performed -= Pause_performed;
    }
}
