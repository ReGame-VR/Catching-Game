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
}
