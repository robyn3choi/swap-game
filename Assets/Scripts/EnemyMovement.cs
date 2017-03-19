using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;
    public Transform Player1;
    public Transform Player2;
    private float distancePlay1;
    private float distancePlay2;
    private Vector2 lastTarget;

    // Use this for initialization
    void Start () {
        lastTarget = Vector2.MoveTowards(transform.position, Player1.transform.position, speed * Time.deltaTime);
    }

	
	// Update is called once per frame
	void Update () {
        distancePlay1 = Vector2.Distance(transform.position, Player1.transform.position);
        distancePlay2 = Vector2.Distance(transform.position, Player2.transform.position);

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
