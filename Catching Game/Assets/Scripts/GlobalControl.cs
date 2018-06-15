using UnityEngine;

/// <summary>
/// Stores calibration data for trial use in a single place.
/// </summary>
public class GlobalControl : MonoBehaviour {

    public enum Difficulty { EASY, MEDIUM, HARD };

    // participant ID to differentiate data files
    public string participantID = "";

    // The single instance of this class
    public static GlobalControl Instance;

    // The time limit of the game in seconds
    public float timeLimit = 300f;

    // trial number of the current user
    public string tryNumber = "";

    // The difficulty of the spawn locations in the game. Hard = more spawn locations
    public Difficulty spawnDifficulty = Difficulty.EASY;
    // Difficulty of user size. Hard = smaller basket
    public Difficulty userSize = Difficulty.EASY;
    // Difficulty of fall speed. Hard = faster falls
    public Difficulty fallSpeed = Difficulty.EASY;
    // Difficulty of user sensitivity. Hard = user is more sensitive
    public Difficulty userSensitivity = Difficulty.EASY;
    // Difficulty of fruit size. Hard = fruits are smaller
    public Difficulty fruitSize = Difficulty.EASY;
    // Length of the trial in seconds. Hard = trials are shorter in time
    public Difficulty trialLength = Difficulty.EASY;

    /// <summary>
    /// Assign instance to this, or destroy it if Instance already exits and is not this instance.
    /// </summary>
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
