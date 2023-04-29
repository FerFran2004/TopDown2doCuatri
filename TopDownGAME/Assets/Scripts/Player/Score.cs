using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Score Display
    public Text TotalScoreDisplay;
    private int TotalScoreCount;
    private int HighestCombo;

    //Combo System and Display
    public Text CurrentComboDisplay;
    public Text HighestComboDisplay;
    private int ComboMultiplier;
    private bool DeadCheck;

    private void Start()
    {
        DeadCheck = false;
    }
    void Update()
    {

        TotalScoreDisplay.text = TotalScoreCount.ToString();

        CurrentComboDisplay.text = ComboMultiplier.ToString() + " X";

        HighestComboDisplay.text = "HIGHEST: " + HighestCombo.ToString() + " X";

        if (DeadCheck == true)
        {
            ComboMultiplier += 1;
            DeadCheck = false;
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
        if (ComboMultiplier != 0)
        {
            if (ComboMultiplier > HighestCombo) 
            {
                HighestCombo = ComboMultiplier; 
            }
            ComboMultiplier = 0;
        }
        
    }
    public void FinalCombo()
    {
        ResetCombo();      
        int FinalScoreDisplay = TotalScoreCount * HighestCombo;
        TotalScoreDisplay.text = FinalScoreDisplay.ToString();
        HighestCombo = 0;
    }
}
