using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonsIngame : MonoBehaviour
{
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
}
