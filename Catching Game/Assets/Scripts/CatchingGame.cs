using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingGame : MonoBehaviour {

    // The state of the game
    public enum GameState { PRE_GAME, GAME, GAME_OVER };
    private GameState curGameState = GameState.PRE_GAME;

    // The player basket 
    [SerializeField]
    private GameObject basket;

    // The player basket 
    [SerializeField]
    private FruitSpawner fruitSpawner;

    // The current time in the trial. When this reaches the trial length, reset the trial.
    private float trialTime;

    // The score of the current game
    private float score = 0f;

    // Length of a trial in seconds.
    private float trialLength;

    // time remaining in the game
    private float timeRemaining;

    // time remaining in the countdown at the beginning of the game
    private float countdown = 3f;

    // The canvas that displays things like score to the user
    [SerializeField]
    private FeedbackCanvas feedbackCanvas;

	// Use this for initialization
	void Start () {
        SetTrialLength();
        timeRemaining = GlobalControl.Instance.timeLimit;
	}
	
	// Update is called once per frame
	void Update () {
        if (curGameState == GameState.PRE_GAME)
        {
            countdown = countdown - Time.deltaTime;
            feedbackCanvas.UpdateCountdownText(countdown);

            // Start game when countdown hits zero
            if (countdown < 0)
            {
                curGameState = GameState.GAME;
                fruitSpawner.SpawnFruit();
                trialTime = 0;
            }
        }
        else if (curGameState == GameState.GAME)
        {
            // Update canvas for the user to see score and time remaining
            timeRemaining = timeRemaining - Time.deltaTime;
            feedbackCanvas.UpdateTimeText(timeRemaining);
            feedbackCanvas.UpdateScoreText(score);

            // Update COP and move basket
            Vector2 currentCoP = CoPtoCM(Wii.GetCenterOfBalance(0));
            basket.GetComponent<Basket>().UpdatePosition(currentCoP);

            // tick up trial time and check if a new fruit should be spawned
            trialTime = trialTime + Time.deltaTime;
            if (trialTime > trialLength)
            {
                // play spawn sound
                fruitSpawner.SpawnFruit();
                trialTime = 0f;
            }

            if (timeRemaining < 0f)
            {
                curGameState = GameState.GAME_OVER;
                feedbackCanvas.DisplayGameOverText();
            }

            //TODO Record data continuously
        }
    }

    /// <summary>
    /// Called when a fruit is caught
    /// </summary>
    /// <param name="timeSinceSpawned"></param>The time that the fruit spent active
    public void CaughtFruit(float timeSinceSpawned)
    {
        // TODO play sound
        score = score + 10;

        ResetTrial(true, timeSinceSpawned);
    }

    /// <summary>
    /// Called when a fruit fell off the screen
    /// </summary>
    /// <param name="timeSinceSpawned"></param>The time that the fruit spent active
    public void FruitFell(float timeSinceSpawned)
    {
        ResetTrial(false, timeSinceSpawned);
    }

    /// <summary>
    /// Records the data from a trial
    /// </summary>
    /// <param name="caught"></param>Whether or not the fruit was caught
    /// <param name="timeSinceSpawned"></param>The time that the fruit spent active
    private void ResetTrial(bool caught, float timeSinceSpawned)
    {
        //TODO record data

        GlobalControl gc = GlobalControl.Instance;
        
        // Adjust the game parameters slightly for variation
        gc.userSize = gc.PickAppropriateDifficulty(gc.userSize);
        gc.fallSpeed = gc.PickAppropriateDifficulty(gc.fallSpeed);
        gc.userSensitivity = gc.PickAppropriateDifficulty(gc.userSensitivity);
        gc.fruitSize = gc.PickAppropriateDifficulty(gc.fruitSize);
        gc.trialLength = gc.PickAppropriateDifficulty(gc.trialLength);
        // Tell the basket that the game parameters changed
        basket.GetComponent<Basket>().ResizeBasket();
        basket.GetComponent<Basket>().AdjustSensitivity();
        SetTrialLength();
    }

    private void SetTrialLength()
    {
        if (GlobalControl.Instance.trialLength == GlobalControl.Difficulty.EXTREMELY_EASY)
        {
            trialLength = 3f;
        }
        else if (GlobalControl.Instance.trialLength == GlobalControl.Difficulty.VERY_EASY)
        {
            trialLength = 2.5f;
        }
        else if (GlobalControl.Instance.trialLength == GlobalControl.Difficulty.EASY)
        {
            trialLength = 1.75f;
        }
        else if (GlobalControl.Instance.trialLength == GlobalControl.Difficulty.MEDIUM)
        {
            trialLength = 1.5f;
        }
        else if (GlobalControl.Instance.trialLength == GlobalControl.Difficulty.HARD)
        {
            trialLength = 1.25f;
        }
        else if (GlobalControl.Instance.trialLength == GlobalControl.Difficulty.VERY_HARD)
        {
            trialLength = 1f;
        }
        else // extremely_hard
        {
            trialLength = 0.75f;
        }
    }

    /// <summary>
    /// Converts COP ratio to be in terms of cm.
    /// </summary>
    /// <param name="posn"> The current COB posn, not in terms of cm </param>
    /// <returns> The posn, in terms of cm </returns>
    public static Vector2 CoPtoCM(Vector2 posn)
    {
        return new Vector2(posn.x * 43.3f / 2f, posn.y * 23.6f / 2f);
    }
}
