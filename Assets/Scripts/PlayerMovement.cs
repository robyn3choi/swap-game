using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public enum PlayerType
    {
        ONE,
        TWO
    }

    public float speed;
    public PlayerType type;
    public Animator playerAnim;
    public Rigidbody2D playerRB;
    public Transform opponent;

//    Vector3 previous;
//    float velocity;

    int direction = 0; // 0 = not moving, 1 = up, 2 = right, 3 = down, 4 = left 

    // Update is called once per frame
    void Update()
    {
        direction = 0;
        switch (type)
        {
            case PlayerType.ONE:
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(Vector2.left * speed);
                    direction = 4;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(Vector2.right * speed);
                    direction = 2;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(Vector2.up * speed);
                    direction = 1;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(Vector2.down * speed);
                    direction = 3;
                }
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    Swap();    
                }
                break;

            case PlayerType.TWO:
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(Vector2.left * speed);
                    direction = 4;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Translate(Vector2.right * speed);
                    direction = 2;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Translate(Vector2.up * speed);
                    direction = 1;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(Vector2.down * speed);
                    direction = 3;
                }
                if (Input.GetKeyDown(KeyCode.Quote)) 
                {
                    Swap();    
                }
                break;
        }
        playerAnim.SetInteger("direction", direction);
    }

    void Swap() {
        Vector2 opponentPosition = opponent.position;
        opponent.position = transform.position;
        transform.position = opponentPosition;
    }
}
