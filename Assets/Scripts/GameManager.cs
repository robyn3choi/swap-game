using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    string formattedTime = "1:00";

    public int timeLeft = 60;
    public int spawnInterval = 10;

    string endGameString;

    public Text timer;
    public Board board;
    public Player playerOne;
    public Player playerTwo;
    float swapTimer = 0;
    public bool canSwap = true;
    public Slider swapSlider;
    public Text swapSliderText;

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
        swapSliderText = swapSlider.transform.Find("Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!canSwap)
        {
            swapTimer += Time.deltaTime;
            swapSlider.value = swapTimer;
            if (swapTimer >= 2)
            {
                swapSlider.value = 2;
                canSwap = true;
                swapTimer = 0;
                swapSliderText.text = "CAN SWAP";
            }
        }
	}

    void StartCounting() {
        InvokeRepeating("Count", 0, 1);
    }

    void Count() {
        if (timeLeft > 0) {
            if (timeLeft % spawnInterval == 0)
            {
                EnemySpawner.instance.SpawnEnemyWave();
            }
            timeLeft--;
            FormatTime();
            timer.text = formattedTime;
        }
        else {
            EndGame();
            CancelInvoke();
        }   
    }

    void FormatTime() {
        int minutes = Mathf.FloorToInt(timeLeft / 60F);
        int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
        formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    void EndGame() {
        EnemySpawner.instance.EndGame();
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

    public void Play()
    {
        StartCounting();
    }

    public void Reset()
    {
        CancelInvoke();
        swapTimer = 0;
        swapSlider.value = 2;
        swapSliderText.text = "CAN SWAP";
        canSwap = true;
        timeLeft = 60;
        formattedTime = "1:00";
        timer.text = formattedTime;
        playerOne.Reset();
        playerTwo.Reset();
        EnemySpawner.instance.ResetEnemies();
    }
}
