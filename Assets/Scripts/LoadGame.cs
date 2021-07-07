using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadGame : MonoBehaviour
{

    public static long Level1Highscore;
    public static long Level2Highscore;
    public static long Level3Highscore;
    public static long Level4Highscore;


    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Score.Level1Highscore = data.Level1Highscore;
        Score.Level2Highscore = data.Level2Highscore;
        Score.Level3Highscore = data.Level3Highscore;
        Score.Level4Highscore = data.Level4Highscore;

    }
    void Update()
    {
        Level1Highscore = Score.Level1Highscore;
        Level2Highscore = Score.Level2Highscore;
        Level3Highscore = Score.Level3Highscore;
        Level4Highscore = Score.Level4Highscore;
    }
}
