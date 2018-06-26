using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;
using UnityEngine.SceneManagement;

/// <summary>
/// Holds functions for responding to and recording preferences on menu.
/// </summary>
public class MenuController : MonoBehaviour {

    void Start()
    {
        // Set up default values
        RecordTimeLimit(0);
        GlobalControl.Instance.spawnDifficulty = GlobalControl.Difficulty.EASY;
        GlobalControl.Instance.userSize = GlobalControl.Difficulty.EASY;
        GlobalControl.Instance.fallSpeed = GlobalControl.Difficulty.EASY;
        GlobalControl.Instance.userSensitivity = GlobalControl.Difficulty.EASY;
        GlobalControl.Instance.fruitSize = GlobalControl.Difficulty.EASY;
        GlobalControl.Instance.trialLength = GlobalControl.Difficulty.EASY;
    }

    /// <summary>
    /// Records an alphanumeric participant ID. Hit enter to record. May be entered multiple times
    /// but only last submission is used. Called using a dynamic function in the inspector
    /// of the textfield object.
    /// </summary>
    /// <param name="arg0"></param>
    public void RecordID(string arg0)
    {
        GlobalControl.Instance.participantID = arg0;
    }

    public void RecordTimeLimit(int arg0)
    {
        // Add 1 index and then multiply by 60 to find seconds time limit
        GlobalControl.Instance.timeLimit = Mathf.Round((arg0 + 1) * 60);
    }

    public void RecordDifficulty(int arg0)
    {
        if (arg0 == 0)
        {
            GlobalControl.Instance.spawnDifficulty = GlobalControl.Difficulty.VERY_EASY;
            GlobalControl.Instance.userSize = GlobalControl.Difficulty.VERY_EASY;
            GlobalControl.Instance.fallSpeed = GlobalControl.Difficulty.VERY_EASY;
            GlobalControl.Instance.userSensitivity = GlobalControl.Difficulty.VERY_EASY;
            GlobalControl.Instance.fruitSize = GlobalControl.Difficulty.VERY_EASY;
            GlobalControl.Instance.trialLength = GlobalControl.Difficulty.VERY_EASY;
        }
        else if (arg0 == 1)
        {
            GlobalControl.Instance.spawnDifficulty = GlobalControl.Difficulty.MEDIUM;
            GlobalControl.Instance.userSize = GlobalControl.Difficulty.MEDIUM;
            GlobalControl.Instance.fallSpeed = GlobalControl.Difficulty.MEDIUM;
            GlobalControl.Instance.userSensitivity = GlobalControl.Difficulty.MEDIUM;
            GlobalControl.Instance.fruitSize = GlobalControl.Difficulty.MEDIUM;
            GlobalControl.Instance.trialLength = GlobalControl.Difficulty.MEDIUM;
        }
        else if (arg0 == 2)
        {
            GlobalControl.Instance.spawnDifficulty = GlobalControl.Difficulty.VERY_HARD;
            GlobalControl.Instance.userSize = GlobalControl.Difficulty.VERY_HARD;
            GlobalControl.Instance.fallSpeed = GlobalControl.Difficulty.VERY_HARD;
            GlobalControl.Instance.userSensitivity = GlobalControl.Difficulty.VERY_HARD;
            GlobalControl.Instance.fruitSize = GlobalControl.Difficulty.VERY_HARD;
            GlobalControl.Instance.trialLength = GlobalControl.Difficulty.VERY_HARD;
        }
        else
        {
            // custom difficulty
        }
    }

    public void RecordTryNumber(string arg0)
    {
        GlobalControl.Instance.tryNumber = arg0;
    }


    /// <summary>
    /// Loads next scene if wii is connected and participant ID was entered.
    /// </summary>
    public void NextScene()
    {
        SceneManager.LoadScene("Catch");
    }
}
