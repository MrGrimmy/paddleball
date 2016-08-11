using UnityEngine;
using System.Collections;

public class Paddles : MonoBehaviour {

    private string playerVert;
    private string playerHor;
    private Transform paddle;
    private float top = 5.80f;
    private float bottom = -5.80f;
    private float leftSmash = -8f;
    private float rightSmash = 8f;
    private float paddleOrigin;
    private AudioSource sound;

    public GameObject paddleObj;
    public float speed = 1;

    // Use this for initialization
    void Start ()
    {
        if (gameObject.name == "LeftPaddle")
        {
            playerVert = "Player1Vert";
            playerHor = "Player1Hor";
        }
        else
        {
            playerVert = "Player2Vert";
            playerHor = "Player2Hor";
        }
        sound = paddleObj.GetComponent<AudioSource>();
        paddle = GetComponent<Transform>();
        paddleOrigin = paddle.position.x;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
            sound.Play();
    }

    void Smash()
    {
        float input = Input.GetAxisRaw(playerHor);
        if (input == 1 || input == -1)
        {
            paddle.Translate((input * (speed)), 0, 0);
            if (gameObject.name == "LeftPaddle" && paddle.position.x > leftSmash)
                paddle.position = new Vector3(leftSmash, paddle.position.y, 0);
            if (gameObject.name == "RightPaddle" && paddle.position.x < rightSmash)
                paddle.position = new Vector3(rightSmash, paddle.position.y, 0);
        }
        else
        paddle.position = new Vector3(paddleOrigin, paddle.position.y, 0);
    }

    void PaddleMove()
    {
        paddle.Translate(0, (Input.GetAxisRaw(playerVert) * speed), 0);
        if (paddle.position.y > top)
            paddle.position = new Vector3(paddle.position.x, top, 0);
        else if (paddle.position.y < bottom)
            paddle.position = new Vector3(paddle.position.x, bottom, 0);

    }
    // Update is called once per frame
    void Update()
    {
        PaddleMove();
        Smash();
    }
}
