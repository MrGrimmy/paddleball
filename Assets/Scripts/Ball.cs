using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private Transform ball;
    public float speedx;
    public float speedy;
    private AudioSource sound;

    void DetermineDirection()
    {
    }

    public void Start()
    {
        ball = GetComponent<Transform>();
        sound = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Paddles")
            speedx = -speedx;
        if (other.gameObject.tag == "Bounds")
        {
            speedy = -speedy;
            sound.Play();
        }
        if (other.gameObject.tag == "Goals")
        {

            if (ball.position.x < 0)
                GameManager.instance.Score(1);
            else
                GameManager.instance.Score(0);
            ball.position = new Vector2(0, 0);
        }
    }
    void Update()
    {
        ball.transform.Translate((speedx * Time.deltaTime), (speedy * Time.deltaTime),0);
    }
}
