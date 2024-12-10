using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //Variables/References
    //Menus
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public GameObject victoryMenu;

    //Functions within menus:
    //Function to start game
    public void LoadGame()
    {
        SceneManager.LoadScene((int)Scenes.Lobby);
    }

    //Function to resume game
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        CloseMainMenu();
    }

    //function to exit game
    public void ExitGame()
    {
        Application.Quit();
    }

   //function to open settings menu
    public void OpenSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    //Functtion to open pauseMenu
    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);        
    }

    //Function to open victory menu
    public void OpenVictoryMenu()
    {
        victoryMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    //functions to open the menu (mostly for pausemenu)

    //function that opens the mainmenu and make it active in hierchy (use in pausemenu)
    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    //Function to close the menu (used in pausemenu)
    public void CloseMainMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    //Function that opens main menu scene (used in pausemenu)
    public void OpenMainMenuScene()
    {
        SceneManager.LoadScene((int)Scenes.MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            if (pauseMenu.activeInHierarchy)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
    
    //Collection of scenes
    public enum Scenes
    {
        MainMenu,
        Lobby,
        Fortress,
        Magical,
        Haunted,
        GameOver,
        Victory
    }
}


