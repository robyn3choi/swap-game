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

    // Update is called once per frame
    void Update()
    {

        switch (type)
        {

            case PlayerType.ONE:
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(Vector2.left * speed);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(Vector2.right * speed);
                }
                if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(Vector2.up * speed);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(Vector2.down * speed);
                }
                break;

            case PlayerType.TWO:
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(Vector2.left * speed);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Translate(Vector2.right * speed);
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Translate(Vector2.up * speed);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(Vector2.down * speed);
                }
                break;
        }
        playerAnim.SetFloat("xVelocity", playerRB.velocity.x);
        playerAnim.SetFloat("yVelocity", playerRB.velocity.y);
    }
}
