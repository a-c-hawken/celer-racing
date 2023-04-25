using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttons : MonoBehaviour
{   
    public GameObject controlsMenu; 
    public GameObject menu;
    public GameObject settingsMenu;
    public GameObject startMenu;
    public GameObject trackStart;

    public float currentResolution = 0f;
    public float currentlySelectedTrack = 1f;

    public bool fullscreenBool = false;

    public Text resolutionText;
    public Text bestTime;
    public Text currentTrackText;

    void Start()
    {
        controlsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        startMenu.SetActive(false);
        trackStart.SetActive(false);
        menu.SetActive(true);
        if (PlayerPrefs.GetInt("firstLaunch") == 0)
        {
            Screen.SetResolution(1280, 720, false);
            currentResolution = 0f;
            resolutionText.text = "1280x720";
            PlayerPrefs.SetInt("firstLaunch", 1);
        }
    }
    void Update()
    {   
        bestTime.text = Mathf.Round(PlayerPrefs.GetFloat("bestTime" + currentlySelectedTrack.ToString())).ToString() + "s";
        currentTrackText.text = "Track " + currentlySelectedTrack;
    }
    public void track1()
    {
        trackStart.SetActive(true);
        startMenu.SetActive(false);
        currentlySelectedTrack = 1f;
    }
    public void track2()
    {   
        trackStart.SetActive(true);
        startMenu.SetActive(false);
        currentlySelectedTrack = 2f;
    }
    public void track3()
    {   
        trackStart.SetActive(true);
        startMenu.SetActive(false);
        currentlySelectedTrack = 3f;
    }
    public void track4()
    {   
        trackStart.SetActive(true);
        startMenu.SetActive(false);
        currentlySelectedTrack = 4f;
    }
    public void track5()
    {   
        trackStart.SetActive(true);
        startMenu.SetActive(false);
        currentlySelectedTrack = 5f;
    }
    public void track6()
    {   
        trackStart.SetActive(true);
        startMenu.SetActive(false);
        currentlySelectedTrack = 6f;
    }
    public void startTrack()
    {
        if(currentlySelectedTrack == 1)
        {
            Application.LoadLevel("SampleScene");
        }else 
        {
            Application.LoadLevel("track" + currentlySelectedTrack);
        }
        PlayerPrefs.SetFloat("currentlyLoadedTrack", currentlySelectedTrack);
    }
    public void startMenuOpen()
    {
        startMenu.SetActive(true);
        menu.SetActive(false);
        trackStart.SetActive(false);
    }
    public void startMenuClose()
    {
        startMenu.SetActive(false);
        menu.SetActive(true);
    }
    public void mainMenu()
    {
        Application.LoadLevel("mainMenu");
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void controls()
    {
        controlsMenu.SetActive(true);
        menu.SetActive(false);
    }
    public void closeControls()
    {
        controlsMenu.SetActive(false);
        menu.SetActive(true);
    }
    public void settings()
    {
        settingsMenu.SetActive(true);
        menu.SetActive(false);
    }
    public void changeResolution()
    {   
        if (currentResolution == 0f)
        {
            Screen.SetResolution(3840, 2160, false);
            currentResolution = 1f;
            resolutionText.text = "3840x2160";
        }else if (currentResolution == 1f)
        {
            Screen.SetResolution(2560, 1440, false);
            currentResolution = 2f;
            resolutionText.text = "2560x1440";
        }else if (currentResolution == 2f)
        {
            Screen.SetResolution(1920, 1080, false);
            currentResolution = 3f;
            resolutionText.text = "1920x1080";
        }else if (currentResolution == 3f)
        {
            Screen.SetResolution(1280, 720, false);
            currentResolution = 4f;
            resolutionText.text = "1280x720";
        }else if (currentResolution == 4f)
        {
            Screen.SetResolution(3440, 1440, false);
            currentResolution = 0f;
            resolutionText.text = "3440x1440";
        }
    }
    public void fullscreen()
    {
        if (fullscreenBool == false)
        {
            Screen.fullScreen = true;
            fullscreenBool = true;
        }
        else if (fullscreenBool == true)
        {
            Screen.fullScreen = false;
            fullscreenBool = false;
        }
    }
    public void closeSettings()
    {
        settingsMenu.SetActive(false);
        menu.SetActive(true);
    }
    public void shop()
    {
        Application.LoadLevel("shop");
    }
}

