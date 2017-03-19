using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    string formattedTime = "2:05";

    public int timeLeft = 125;
    public int spawnInterval = 10;

    string endGameString;

    public Text timer;
    public Board board;
    public Player playerOne;
    public Player playerTwo;

    public static GameManager instance = null;

    void Awake() {
        if (instance == null) {
            instance = this;
        }    
        else if (instance != this) {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        StartCounting();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerOne.GetHealth() <= 0 && playerTwo.GetHealth() <= 0)
        {
            EndGame();
        }
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
            return;
        }

        if (timeLeft % spawnInterval == 0)
        {
            EnemySpawner.instance.SpawnEnemyWave();
        }
            
    }

    void FormatTime() {
        int minutes = Mathf.FloorToInt(timeLeft / 60F);
        int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
        formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    void EndGame() {
        if (playerOne.GetScore() == playerTwo.GetScore()) {
            endGameString = "DRAW";
        }
        else if (playerOne.GetScore() > playerTwo.GetScore())
        {
            endGameString = "PLAYER ONE WINS!";
        }
        else {
            endGameString = "PLAYER TWO WINS!";
        }
        print(endGameString);
    }
}
