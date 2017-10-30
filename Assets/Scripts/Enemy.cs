using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
    private Vector2 lastTarget;

    private GameObject Player1;
    private GameObject Player2;

    Player player1Script;
    Player player2Script;

    public int health = 2;
    Rigidbody2D rb;
    ParticleSystem particles;
    public Vector2 randomPosition;
    AudioSource audioSource;
    public AudioClip hitAudio;
    public AudioClip dieAudio;
    SpriteRenderer sprite;
    BoxCollider2D coll;
    float dieTimer = 1;

    // Use this for initialization
    void Start () {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Player1 = players[0];
        Player2 = players[1];
        player1Script = Player1.GetComponent<Player>();
        player2Script = Player2.GetComponent<Player>();
        lastTarget = Vector2.MoveTowards(transform.position, Player1.transform.position, speed * Time.deltaTime);
        rb = GetComponent<Rigidbody2D>();
        particles = transform.GetChild(0).GetComponent<ParticleSystem>();
        randomPosition = new Vector2(Random.Range(-999f, 999f), Random.Range(-999f, 999f));
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = hitAudio;
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

	
	// Update is called once per frame
	void Update () {
        float distancePlay1;
        float distancePlay2;

        if (player1Script.deadState && player2Script.deadState)
        {
            lastTarget = Vector2.MoveTowards(transform.position, randomPosition, speed * Time.deltaTime);
            transform.position = lastTarget;
            return;
        }

        if (player1Script.deadState)
        {
            distancePlay1 = 999;
        }
        else
        {
            distancePlay1 = Vector2.Distance(transform.position, Player1.transform.position);
        }
        if (player2Script.deadState)
        {
            distancePlay2 = 999;
        }
        else
        {
            distancePlay2 = Vector2.Distance(transform.position, Player2.transform.position);
        }
        
        if (distancePlay1 < distancePlay2)
        {
            lastTarget = Vector2.MoveTowards(transform.position, Player1.transform.position, speed * Time.deltaTime);
            transform.position = lastTarget;
        }
        if (distancePlay2 < distancePlay1)
        {
            lastTarget = Vector2.MoveTowards(transform.position, Player2.transform.position, speed * Time.deltaTime);
            transform.position = lastTarget;
        }
        if (distancePlay1 == distancePlay2)
        {
            transform.position = lastTarget;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            health--;
            particles.Play();
            if (health <= 0)
            {
                audioSource.clip = dieAudio;
                collision.transform.parent.parent.parent.GetComponent<Player>().AddPoint();
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
                coll.enabled = false;
                StartCoroutine("Die");
            }
            else
            {
                audioSource.clip = hitAudio;
            }
            audioSource.Play();
        }
    }

    IEnumerator Die()
    {
        dieTimer -= Time.deltaTime;
        if (dieTimer < 0)
        {
            dieTimer = 1;
            gameObject.SetActive(false);
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
            coll.enabled = true;
            yield break;
        }
    }
}
