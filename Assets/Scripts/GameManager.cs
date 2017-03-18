using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    int playerOneScore = 0;
    int playerTwoScore = 0;
    int timeLeft = 120;

    bool gameOver;

    string endGameString;

	// Use this for initialization
	void Start () {
        StartCounting();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartCounting() {
        InvokeRepeating("Count", 0, 1);
    }

    void Count() {
        if (timeLeft > 0) {
            timeLeft--;
            print(timeLeft);
        }
        else {
            EndGame();
        }
    }

//    void OnGUI() {
//        int minutes = Mathf.FloorToInt(timeLeft / 60F);
//        int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
//        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
//
//        GUI.Label(new Rect(10,10,250,100), niceTime);
//    }

    void EndGame() {
        gameOver = true;
        if (playerOneScore == playerTwoScore) {
            endGameString = "DRAW";
        }
        else if (playerOneScore > playerTwoScore) {
            endGameString = "PLAYER ONE WINS!";
        }
        else {
            endGameString = "PLAYER TWO WINS!";
        }
        print(endGameString);
    }
}
