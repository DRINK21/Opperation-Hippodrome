using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound : MonoBehaviour
{
    private static Sound instance;
    private int menuCheck;
    public string sceneName;
    public string previoussceneName;

    private void Start()
    {
        Score.level = 0;
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (sceneName == "MainMenu" )
        {
            menuCheck = 0;
        }
    }
    public static Sound Instance 
    

    {
        get { return instance; }
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if(sceneName == "LevelSelect" || sceneName == "SettingsMenu")
        {
            previoussceneName = "MainMenu";
        }
        if(sceneName == "MainMenu" && previoussceneName == "MainMenu")
        {
            Destroy(gameObject);
        }
        for (int i = 1; i <= 3; i++)
        {
            if (Score.level == i)
            {
                Destroy(gameObject);
            }
        }
        if (menuCheck == 1)
        {
             Destroy(gameObject);
        }

    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
 
    }
}

    
