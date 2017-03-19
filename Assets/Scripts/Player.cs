using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int score;

	// Use this for initialization
	void Start () {
        this.score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetScore() {
        return this.score;
    }
}
