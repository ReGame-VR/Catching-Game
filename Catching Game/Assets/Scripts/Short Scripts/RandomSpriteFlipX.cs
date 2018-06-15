using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class that randomly flips the X of the attached sprite renderer when spawned
[RequireComponent(typeof(SpriteRenderer))]
public class RandomSpriteFlipX : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // Randomly flips x
        GetComponent<SpriteRenderer>().flipX = Random.value > 0.5f;
	}
	
}
