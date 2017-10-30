using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public enum PlayerType
    {
        ONE,
        TWO
    }
    public PlayerType type;
    private int score;
    public bool deadState = false;
    public float deadTime = 2;
    float timer = 0;
    SpriteRenderer sprite;
    public Text scoreText;
    public AudioSource dieSfx;

    // Use this for initialization
    void Start () {
        this.score = 0;
        sprite = GetComponent<SpriteRenderer>();
	}

    public void Reset()
    {
        deadState = false;
        timer = 0;
        sprite.color = new Color(1, 1, 1, 1);
        score = 0;
        if (type == PlayerType.ONE)
        {
            scoreText.text = "P1: " + score;
        }
        else
        {
            scoreText.text = "P2: " + score;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (deadState)
        {
            timer += Time.deltaTime;
            if (timer >= deadTime)
            {
                deadState = false;
                timer = 0;
                sprite.color = new Color(1, 1, 1, 1);
            }
        }
	}

    public int GetScore () {
        return this.score;
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Enemy") {
            if (!deadState)
            {
                dieSfx.Play();
                deadState = true;
                sprite.color = new Color(1, 1, 1, 0.5f);
            }
        }
    }

    public void AddPoint()
    {
        score++;
        if (type == PlayerType.ONE)
        {
            scoreText.text = "P1: " + score;
        }
        else
        {
            scoreText.text = "P2: " + score;
        }
    }

}
