using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour {

    float speed;
    Vector2 direction;
    bool isReady;

	// Use this for initialization
	void Start () {
        speed = 5f;
        isReady = false;
	}

    public void SetDirection(Vector2 direction)
    {
        direction = direction.normalized;
        isReady = true;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 position = transform.position;
        position += direction * speed * Time.deltaTime;
        transform.position = position;
        //Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        //Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

       
    }
    
}
