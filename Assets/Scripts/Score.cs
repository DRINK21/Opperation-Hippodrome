using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{

    public static long totalScore;
    public long maxtime = 360;
    public long BossScore;
    public long endScore;
    public static int lightDrop;
    public long timeleft;
    public long startTime;
    public static long level;

    public long level1score = 0;
    public long level2score = 0;
    public long level3score = 0;
    public long level4score = 0;

    public static long Level1Highscore = 0;
    public static long Level2Highscore = 0;
    public static long Level3Highscore = 0;
    public static long Level4Highscore = 0;

    public static long BossKill;

    public bool countdown = false;
    public static bool LevelDone = false;

    public Transform player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighscoreText;
    public TextMeshProUGUI TimeLeftText;


    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        level1score = 0;
        level2score = 0;
        level3score = 0;
        totalScore = 0;
        lightDrop = 0;
        startTime = maxtime;
        BossKill = 0;
        LevelDone = false;
        Level1Highscore = LoadGame.Level1Highscore;
        Level2Highscore = LoadGame.Level2Highscore;
        Level3Highscore = LoadGame.Level3Highscore;
        Level4Highscore = LoadGame.Level4Highscore;
        switch (sceneName)
        {
            case "Level 1":
                level = 1;
                HighscoreText.text = "Highscore: " + Level1Highscore.ToString();
                break;
            case "Level 2":
                level = 2;
                HighscoreText.text = "Highscore: " + Level2Highscore.ToString();
                break;
            case "Level 3":
                level = 3;
                HighscoreText.text = "Highscore: " + Level3Highscore.ToString();
                break;
            case "Arena":
                level = 4;
                HighscoreText.text = "Highscore: " + Level3Highscore.ToString();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown == false)
        {
            countdown = true;
            StartCoroutine(TimeCountdown());
            if (LevelDone)
            {
                GetTotalScore();
                StopAllCoroutines();
                countdown = true;
            }
        }
        if (level1score > Level1Highscore)
        {
            Level1Highscore = level1score;
            HighscoreText.text = "Highscore: " + Level1Highscore.ToString();
        }
        if (level2score > Level2Highscore)
        {
            Level2Highscore = level2score;
            HighscoreText.text = "Highscore: " + Level2Highscore.ToString();
        }
        if (level3score > Level3Highscore)
        {
            Level3Highscore = level3score;
            HighscoreText.text = "Highscore: " + Level3Highscore.ToString();
        }   
    }


    IEnumerator TimeCountdown()
    {
        startTime--;
        timeleft = startTime;
        totalScore = BossKill + lightDrop;
        LoadPreviusScore.score = totalScore;
        GetLevel();
        scoreText.text = "Score: " + totalScore.ToString();
        TimeLeftText.text = "Time Bonus: " + timeleft.ToString();
        yield return new WaitForSeconds(1);
        countdown = false;
    }

    void GetTotalScore()
    {
    
        totalScore += timeleft;
        LevelComplete.score = totalScore;
        GetLevel();
        scoreText.text = "Score: " + totalScore.ToString();
        TimeLeftText.text = "Time Bonus: " + timeleft.ToString();
        
    }

    long GetLevel()
    {
        return level switch
        {
            1 => level1score = totalScore,
            2 => level2score = totalScore,
            3 => level3score = totalScore,
            4 => level4score = totalScore,
            _ => 0
        };
    }
}
