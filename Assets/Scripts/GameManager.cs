using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    int playerOneScore = 0;
    int playerTwoScore = 0;
    int timeLeft = 120;
    string formattedTime = "2:00";

    bool gameOver;

    string endGameString;

    public Text timer;

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
            FormatTime();
            timer.text = formattedTime;
        }
        else {
            EndGame();
        }
    }

    void FormatTime() {
        int minutes = Mathf.FloorToInt(timeLeft / 60F);
        int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
        formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

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
