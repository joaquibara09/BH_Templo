using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    private int score = 0;

    public void UpdateScore(int nuevoScore)
    {
        score = nuevoScore;
        scoreText.text = "Score: " + score;
        Debug.Log("Score: " + score);
    }

    public void UpdateTimer(float timer)
    {
        timerText.text = "00:" + Mathf.CeilToInt(timer).ToString("00");
    }
}