using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Score Display
    public Text TotalScoreDisplay;
    private int TotalScoreCount;

    //Combo System and Display
    public Text ComboDisplay;
    private int ComboMultiplier;
    private bool DeadCheck;

    private void Start()
    {
        DeadCheck = false;
    }
    void Update()
    {

        TotalScoreDisplay.text = TotalScoreCount.ToString();

        ComboDisplay.text = ComboMultiplier.ToString() + " X";

        if (DeadCheck == true)
        {
            ComboMultiplier += 1;
            DeadCheck = false;
        }
        else
        {

        }
    }

    public void ScoreCount(int points)
    {
        TotalScoreCount += points;
    }
    public void Dead()
    {
        DeadCheck = true;
    }
    public void ResetCombo()
    {
        Debug.Log("RESETING");
        if (ComboMultiplier != 0)
        {
            TotalScoreCount = ComboMultiplier * TotalScoreCount;
            ComboMultiplier = 0;
        }
        else
        {

        }
        
    }
}
