using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadPreviusScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static long score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }
}
