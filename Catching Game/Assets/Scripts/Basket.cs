using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

    // The game script of this current catching game
    [SerializeField]
    private CatchingGame gameScript;

    // The particles that the basket spawns on catch
    [SerializeField]
    private GameObject heartParticles;
    [SerializeField]
    private GameObject catchParticles;
    // The sprites that switch upon catch. The sprite looks lowered on catch.
    [SerializeField]
    private Sprite basket;
    [SerializeField]
    private Sprite loweredBasket;

    // The maximum positions that the basket is allowed to move
    private float minXpos = -8;
    private float maxXpos = 8;
    private float minYpos = -4;
    private float maxYpos = 0;

    // The sensitivity of the basket movement
    private float sensitivity = 0.6f;
	
	// Update is called once per frame
	void Update () {

    }

    public void UpdatePosition(Vector2 pos)
    {
        pos = new Vector2(sensitivity * pos.x, sensitivity * 0.5f * pos.y);

        // Enforce max and min positions
        if (pos.x < minXpos)
        {
            pos.x = minXpos; 
        }
        if (pos.x > maxXpos)
        {
            pos.x = maxXpos;
        }
        if (pos.y < minYpos)
        {
            pos.y = minYpos;
        }
        if (pos.y > maxYpos)
        {
            pos.y = maxYpos;
        }


        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Fruit")
        {
            // You caught a fruit! Destroy it, spawn particles, tell game script
            Destroy(c.gameObject);
            Instantiate(heartParticles, transform.position, Quaternion.identity);
            Instantiate(catchParticles, transform.position, Quaternion.identity);
            gameScript.CaughtFruit();

            // Lower the basket to make it seem like it caught something
            GetComponent<SpriteRenderer>().sprite = loweredBasket;
            StartCoroutine(ResetBasketSprite());
        }
    }

    // Raise the basket again. (This is basically an animation)
    IEnumerator ResetBasketSprite()
    {
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = basket;
    }

    public void ResizeBasket(GlobalControl.Difficulty difficulty)
    {
        if (difficulty == GlobalControl.Difficulty.EXTREMELY_EASY)
        {
            transform.localScale = new Vector3(9, 6, 1);
        }
        else if (difficulty == GlobalControl.Difficulty.VERY_EASY)
        {
            transform.localScale = new Vector3(8, 6, 1);
        }
        else if (difficulty == GlobalControl.Difficulty.EASY)
        {
            transform.localScale = new Vector3(7, 6, 1);
        }
        else if (difficulty == GlobalControl.Difficulty.MEDIUM)
        {
            transform.localScale = new Vector3(6, 6, 1);
        }
        else if (difficulty == GlobalControl.Difficulty.HARD)
        {
            transform.localScale = new Vector3(5, 6, 1);
        }
        else if (difficulty == GlobalControl.Difficulty.VERY_HARD)
        {
            transform.localScale = new Vector3(4, 6, 1);
        }
        else // extremely_hard
        {
            transform.localScale = new Vector3(3, 6, 1);
        }
    }

    public void AdjustSensitivity(GlobalControl.Difficulty difficulty)
    {
        if (difficulty == GlobalControl.Difficulty.EXTREMELY_EASY)
        {
            sensitivity = 0.5f;
        }
        else if (difficulty == GlobalControl.Difficulty.VERY_EASY)
        {
            sensitivity = 0.55f;
        }
        else if (difficulty == GlobalControl.Difficulty.EASY)
        {
            sensitivity = 0.6f;
        }
        else if (difficulty == GlobalControl.Difficulty.MEDIUM)
        {
            sensitivity = 0.65f;
        }
        else if (difficulty == GlobalControl.Difficulty.HARD)
        {
            sensitivity = 0.7f;
        }
        else if (difficulty == GlobalControl.Difficulty.VERY_HARD)
        {
            sensitivity = 0.75f;
        }
        else // extremely_hard
        {
            sensitivity = 0.8f;
        }
    }
}
