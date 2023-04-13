using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text TotalScoreDisplay;
    private int TotalScoreCount;

    void Update()
    {
        TotalScoreDisplay.text = TotalScoreCount.ToString();
    }

    public void ScoreCount(int points)
    {
        TotalScoreCount += points;
    }
}
