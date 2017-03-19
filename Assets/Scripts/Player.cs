using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int score;
	private int healthPoints = 1;


	// Use this for initialization
	void Start () {
        this.score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoseHealth (int lossHealth) {
		// Set animation of player being hit
		healthPoints -= lossHealth;
		if (healthPoints <= 0) {
			// kill the player
		}
	}

    public int GetScore() {
        return this.score;
    }
}
