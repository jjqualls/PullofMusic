/*****************************************************************************
// File Name : MusicPlayer.cs
// Author : Josephine Qualls
// Creation Date : May 09, 2025
//
// Brief Description : Plays the background music for each maze.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioSource> music;
    private int count;
    private string musicScene;

    /// <summary>
    /// Lets the music carry over till the next maze
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Plays the background music for that maze.
    /// Stops the music from the maze before.
    /// </summary>
    private void Start()
    {
        //sets name of old music to stop
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                musicScene = "";
                count = 0;
                break;
            case 4:
                musicScene = "TitleBackgroundMusic";
                count = 1;
                break;
            case 6:
                musicScene = "1stBackgroundMusic";
                count = 2;
                break;
            case 8:
                musicScene = "2ndBackgroundMusic";
                count = 3;
                break;
            case 10:
                musicScene = "3rdBackgroundMusic";
                count = 4;
                break;
        }

        GameObject backgroundMusic = GameObject.Find(musicScene);

        //initially sets all music to mute
        for(int i = 0; i < music.Count; i++)
        {
            music[i].mute = true;
        }

        //plays new music and gets rid of old music
        if (SceneManager.GetActiveScene().name.Contains("Maze") || SceneManager.GetActiveScene().name.Contains("End"))
        {
            if(backgroundMusic != null)
            {
                Destroy(backgroundMusic);
            }

            music[count-1].mute = true;
            music[count].mute = false;
            music[count].Play();
        }
        else
        {
            music[count].mute = false;
            music[count].Play();
        }
        
    }

    
}
