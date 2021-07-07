using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public long Level1Highscore;
    public long Level2Highscore;
    public long Level3Highscore;
    internal long Level4Highscore;

    public PlayerData(LoadGame player)
    {
        Level1Highscore = Score.Level1Highscore;
        Level2Highscore = Score.Level2Highscore;
        Level3Highscore = Score.Level3Highscore;
    }

}