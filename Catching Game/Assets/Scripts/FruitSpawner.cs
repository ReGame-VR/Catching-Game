using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

    // All the locations at which the fruit can spawn.
    public GameObject[] hardSpawnPositions;

    // The positions at which catching is medium difficulty
    public GameObject[] mediumSpawnPositions;

    // The positions at which catching is easy
    public GameObject[] easySpawnPositions;

    // The fruits that will be spawned
    public GameObject[] fruits;

    // Spawn a random fruit in a random location with correct size
    public void SpawnFruit()
    {
        Vector3 spawnPos;
        
        // SELECT SPAWN LOCATION
        if (GlobalControl.Instance.spawnDifficulty == GlobalControl.Difficulty.HARD)
        {
            spawnPos = hardSpawnPositions[Random.Range(0, hardSpawnPositions.Length)].transform.position;
        }
        else if (GlobalControl.Instance.spawnDifficulty == GlobalControl.Difficulty.MEDIUM)
        {
            spawnPos = mediumSpawnPositions[Random.Range(0, mediumSpawnPositions.Length)].transform.position;
        }
        else
        {
            spawnPos = easySpawnPositions[Random.Range(0, easySpawnPositions.Length)].transform.position;
        }

        GameObject newFruit = Instantiate(fruits[Random.Range(0, fruits.Length)], spawnPos, Quaternion.identity);
        
        // MAKE FRUIT CORRECT SIZE
        if (GlobalControl.Instance.fruitSize == GlobalControl.Difficulty.HARD)
        {
            newFruit.transform.localScale = new Vector3(newFruit.transform.localScale.x * 0.75f, newFruit.transform.localScale.x * 0.75f);
        }
        else if (GlobalControl.Instance.fruitSize == GlobalControl.Difficulty.MEDIUM)
        {
            // keep fruit medium sized
        }
        else
        {
            newFruit.transform.localScale = new Vector3(newFruit.transform.localScale.x * 1.25f, newFruit.transform.localScale.x * 1.25f);
        }
    }
}
