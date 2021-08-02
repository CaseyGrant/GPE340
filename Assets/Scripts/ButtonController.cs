using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Level 1"); // loads the game scene
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu"); // loads the main menu scene
    }

    public void QuitButton()
    {
        Application.Quit(); // quits the game
    }
}
