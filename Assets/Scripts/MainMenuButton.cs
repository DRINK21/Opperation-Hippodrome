using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void GoToLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void GoToLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void GoToLevelThree()
    {
        SceneManager.LoadScene("Level 3");
    }public void GoToLevelFour()
    {
        SceneManager.LoadScene("Arena");
    }
    public void GoToCharacterSelect()
    {
        SceneManager.LoadScene("CharacterSelect");
    }
    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
    public void GoToExit()
    {
        Application.Quit();
    }

    public void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void GoToLevelComplete()
    {
        SceneManager.LoadScene("LevelComplete");
    }

    public void Restart()
    {
        if (Score.level == 1)
        {
            SceneManager.LoadScene("Level 1");
        }
        if (Score.level == 2)
        {
            SceneManager.LoadScene("Level 2");
        }
        if (Score.level == 3)
        {
            SceneManager.LoadScene("Level 3");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
