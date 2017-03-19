using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Attack : MonoBehaviour {

    GameObject Player;
    GameObject Sword;
    private int direction; // 0 = not moving, 1 = up, 2 = right, 3 = down, 4 = left 
                           // Use this for initialization
    void Start () {
        direction = GetComponent<PlayerMovement>().direction;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MeleeAttack();
        }
	}
    
    void MeleeAttack()
    {
        if(direction == 1) //Up attack
        {
           
        }
        if (direction == 2) //Right attack
        {

        }
        if (direction == 3) //Down attack
        {

        }
        if (direction == 4) //Left attack
        {

        }

    }
}
