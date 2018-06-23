using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackCanvas : MonoBehaviour {

    // Text displaying game score
    [SerializeField]
    private Text scoreText;

    // Text displaying time remaining in game
    [SerializeField]
    private Text timeRemainingText;

    // Text displaying countdown
    [SerializeField]
    private Text countdownText;

    // Update score text with given score
    public void UpdateScoreText(float score)
    {
        scoreText.text = score.ToString();
    }

    // Update time text with given time
    public void UpdateTimeText(float time)
    {
        timeRemainingText.text = Mathf.Round(time).ToString();
    }

    // Update time text with given time
    public void UpdateCountdownText(float countdown)
    {
        if (countdown < 0)
        {
            countdownText.text = "";
        }
        else if (countdown < 1)
        {
            countdownText.text = "GO!";
        }
        else
        {
            countdownText.text = Mathf.Round(countdown).ToString();
        }
    }

    public void DisplayGameOverText()
    {
        countdownText.text = "Game Over!";
    }
}
