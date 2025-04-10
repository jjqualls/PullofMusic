using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HowToPlayMenu : MonoBehaviour
{

    [SerializeField] private GameObject howToPlayMenu;
    [SerializeField] private GameObject titleScreen;

    public void OpenMenu()
    {
        howToPlayMenu.SetActive(true);
        titleScreen.SetActive(false);
    }

    public void CloseMenu() 
    { 
        howToPlayMenu.SetActive(false);
        titleScreen.SetActive(true);
    }
}
