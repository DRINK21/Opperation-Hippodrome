using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelComplete : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public static long score;
    // Start is called before the first frame update
    void Start()
    {
        score = Score.totalScore;
        scoreText.text = score.ToString();
        switch (Score.level)
        {
            case 1:
                highscoreText.text = Score.Level1Highscore.ToString();

                break;
            case 2:
                highscoreText.text = Score.Level2Highscore.ToString();

                break;
            case 3:
                highscoreText.text = Score.Level3Highscore.ToString();

                break;
        }


    }
}
