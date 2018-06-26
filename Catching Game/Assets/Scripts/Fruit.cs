using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    // The star particles that appear on fruit spawn
    [SerializeField]
    private GameObject spawnParticles;

    // The main game script for the Catching Game
    [SerializeField]
    private CatchingGame gameScript;

    // The time in seconds that has passed since this fruit was spawned
    private float timeSinceSpawned = 0f;

	// Use this for initialization
	void Start () {
        Instantiate(spawnParticles, transform.position, Quaternion.identity);
        gameScript = FindObjectOfType<CatchingGame>();
    }
	
	// Update is called once per frame
	void Update () {

        // Tick up the time since this spawned
        timeSinceSpawned = timeSinceSpawned + Time.deltaTime;

        // If this fell off the screen, destroy it
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            gameScript.FruitFell(timeSinceSpawned);
        }		
	}

    // Gets the time that this fruit has been active
    public float GetTimeSinceSpawned()
    {
        return timeSinceSpawned;
    }
}
