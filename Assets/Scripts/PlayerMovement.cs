using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public Animator playerAnim;
    public Rigidbody2D playerRB;
    public Transform opponent;
    public ParticleSystem particles;
    ParticleSystem oppParticles;

    public int direction = 3; // 1 = up, 2 = right, 3 = down, 4 = left 
    int prevDirection;

    Transform swordPivotParent;
    Animator swordAnim;
    Player playerScript;

    void Awake()
    {
        particles = transform.Find("Particles").GetComponent<ParticleSystem>();
    }

    void Start()
    {
        playerScript = GetComponent<Player>();
        swordPivotParent = transform.GetChild(0);
        swordAnim = swordPivotParent.GetChild(0).GetComponent<Animator>();
        oppParticles = opponent.GetComponent<PlayerMovement>().particles;
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerScript.type)
        {
            case Player.PlayerType.ONE:
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(Vector2.left * speed);
                    direction = 4;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(Vector2.right * speed);
                    direction = 2;
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(Vector2.up * speed);
                    direction = 1;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(Vector2.down * speed);
                    direction = 3;
                }
                if (Input.GetKeyDown(KeyCode.T))
                {
                    Swap();
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Attack();
                }
                break;

            case Player.PlayerType.TWO:
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(Vector2.left * speed);
                    direction = 4;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Translate(Vector2.right * speed);
                    direction = 2;
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Translate(Vector2.up * speed);
                    direction = 1;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(Vector2.down * speed);
                    direction = 3;
                }
                if (Input.GetKeyDown(KeyCode.Backslash))
                {
                    Swap();
                }
                if (Input.GetKeyDown(KeyCode.RightBracket))
                {
                    Attack();
                }
                break;
        }
        if (direction != prevDirection)
        {
            playerAnim.SetInteger("direction", direction);
        }

        prevDirection = direction;
    }

    void Swap() {
        if (GameManager.instance.canSwap)
        {
            Vector2 opponentPosition = opponent.position;
            opponent.position = transform.position;
            transform.position = opponentPosition;
            GameManager.instance.swapSlider.value = 0;
            GameManager.instance.swapSliderText.text = "CAN'T SWAP";
            GameManager.instance.canSwap = false;
            particles.Play();
            oppParticles.Play();
        }
    }

    void Attack()
    {
        if (playerScript.deadState) { return; }

        float angle = 0;
        if (direction == 1)
        {
            angle = 180;
        }
        else if (direction == 2)
        {
            angle = 90;
        }
        else if (direction == 4)
        {
            angle = -90;
        }
        swordPivotParent.localEulerAngles = new Vector3(0, 0, angle);

        swordAnim.SetTrigger("Swing");

    }
}
