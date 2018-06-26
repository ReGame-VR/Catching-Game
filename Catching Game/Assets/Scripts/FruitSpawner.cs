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

    // Spawn a random fruit in a random location with correct size and correct fall speed
    public void SpawnFruit()
    {
        Vector3 spawnPos;
        
        // ----------------------------------------
        // SELECT SPAWN LOCATION
        if (GlobalControl.Instance.spawnDifficulty > GlobalControl.Difficulty.MEDIUM) // If it is harder than medium
        {
            spawnPos = hardSpawnPositions[Random.Range(0, hardSpawnPositions.Length)].transform.position;
        }
        else if (GlobalControl.Instance.spawnDifficulty == GlobalControl.Difficulty.MEDIUM)
        {
            spawnPos = mediumSpawnPositions[Random.Range(0, mediumSpawnPositions.Length)].transform.position;
        }
        else // It is easier than medium
        {
            spawnPos = easySpawnPositions[Random.Range(0, easySpawnPositions.Length)].transform.position;
        }

        GameObject newFruit = Instantiate(fruits[Random.Range(0, fruits.Length)], spawnPos, Quaternion.identity);
        
        // -----------------------------------------
        // MAKE FRUIT CORRECT SIZE
        if (GlobalControl.Instance.fruitSize == GlobalControl.Difficulty.EXTREMELY_EASY)
        {
            newFruit.transform.localScale = new Vector3(newFruit.transform.localScale.x * 1.5f, newFruit.transform.localScale.x * 1.5f);
        }
        else if (GlobalControl.Instance.fruitSize == GlobalControl.Difficulty.VERY_EASY)
        {
            newFruit.transform.localScale = new Vector3(newFruit.transform.localScale.x * 1.3f, newFruit.transform.localScale.x * 1.3f);
        }
        else if (GlobalControl.Instance.fruitSize == GlobalControl.Difficulty.EASY)
        {
            newFruit.transform.localScale = new Vector3(newFruit.transform.localScale.x * 1.1f, newFruit.transform.localScale.x * 1.1f);
        }
        else if (GlobalControl.Instance.fruitSize == GlobalControl.Difficulty.MEDIUM)
        {
            // keep fruit medium sized
        }
        else if (GlobalControl.Instance.fruitSize == GlobalControl.Difficulty.HARD)
        {
            newFruit.transform.localScale = new Vector3(newFruit.transform.localScale.x * 0.9f, newFruit.transform.localScale.x * 0.9f);
        }
        else if (GlobalControl.Instance.fruitSize == GlobalControl.Difficulty.VERY_HARD)
        {
            newFruit.transform.localScale = new Vector3(newFruit.transform.localScale.x * 0.8f, newFruit.transform.localScale.x * 0.8f);
        }
        else // extremely_hard
        {
            newFruit.transform.localScale = new Vector3(newFruit.transform.localScale.x * 0.5f, newFruit.transform.localScale.x * 0.5f);
        }

        // -------------------------------------
        // ADJUST FRUIT FALL SPEED
        if (GlobalControl.Instance.fallSpeed == GlobalControl.Difficulty.EXTREMELY_EASY)
        {
            newFruit.GetComponent<Rigidbody2D>().AddForce(transform.up * 0.5f);
        }
        else if (GlobalControl.Instance.fallSpeed == GlobalControl.Difficulty.VERY_EASY)
        {
            newFruit.GetComponent<Rigidbody2D>().AddForce(transform.up * 0.3f);
        }
        else if (GlobalControl.Instance.fallSpeed == GlobalControl.Difficulty.EASY)
        {
            newFruit.GetComponent<Rigidbody2D>().AddForce(transform.up * 0.2f);
        }
        else if (GlobalControl.Instance.fallSpeed == GlobalControl.Difficulty.MEDIUM)
        {
            // keep fruit falling at normal speed
        }
        else if (GlobalControl.Instance.fallSpeed == GlobalControl.Difficulty.HARD)
        {
            newFruit.GetComponent<Rigidbody2D>().AddForce(transform.up * -0.2f);
        }
        else if (GlobalControl.Instance.fallSpeed == GlobalControl.Difficulty.VERY_HARD)
        {
            newFruit.GetComponent<Rigidbody2D>().AddForce(transform.up * -0.3f);
        }
        else // extremely_hard
        {
            newFruit.GetComponent<Rigidbody2D>().AddForce(transform.up * -0.5f);
        }
    }
}
