using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    // The basket in the game
    private CatchingGame gameScript;

	// Use this for initialization
	void Start () {
        gameScript = FindObjectOfType<CatchingGame>();
        gameScript.AddObstacleToGame(gameObject);
		
	}
}
