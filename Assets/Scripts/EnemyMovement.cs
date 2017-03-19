using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;
    private Vector2 lastTarget;

    private GameObject Player1;
    private GameObject Player2;

    // Use this for initialization
    void Start () {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Player1 = players[0];
        Player2 = players[1];
        lastTarget = Vector2.MoveTowards(transform.position, Player1.transform.position, speed * Time.deltaTime);
    }

	
	// Update is called once per frame
	void Update () {
        float distancePlay1 = Vector2.Distance(transform.position, Player1.transform.position);
        float distancePlay2 = Vector2.Distance(transform.position, Player2.transform.position);

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
}
