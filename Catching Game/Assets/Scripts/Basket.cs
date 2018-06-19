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
    private float sensitivity = 0.5f;
	
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
            Destroy(c.gameObject);
            Instantiate(heartParticles, transform.position, Quaternion.identity);
            Instantiate(catchParticles, transform.position, Quaternion.identity);

            gameScript.CaughtFruit();
        }
    }
}
