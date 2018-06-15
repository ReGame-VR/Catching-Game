using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    [SerializeField]
    private GameObject spawnParticles;

	// Use this for initialization
	void Start () {
        Instantiate(spawnParticles, transform.position, Quaternion.identity);

    }
	
	// Update is called once per frame
	void Update () {

        // If this fell off the screen, destroy it
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
		
	}
}
