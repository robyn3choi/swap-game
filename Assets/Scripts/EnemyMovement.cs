using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;
    public Transform Target;


    // Use this for initialization
    void Start () {

    }

	
	// Update is called once per frame
	void Update () {

        transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
           
    }
}
