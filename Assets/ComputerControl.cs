using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerControl : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 0.1f;
    public float maxSpeed = 10.0f;
    public float boundY = 2.25f;
    private Rigidbody2D rb2d;
    public Transform ball;
    private int frames = 0;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        if (frames % 7 == 0)
        {
            var vel = rb2d.velocity;
            var pos = transform.position;
            var ballpos = ball.position;

            if (ballpos.y > pos.y)
            {
                vel.y += speed;
                if (vel.y > maxSpeed)
                {
                    vel.y = maxSpeed;
                }
            }
            else if (ballpos.y < pos.y)
            {
                vel.y -= speed;
                if (vel.y > -maxSpeed)
                {
                    vel.y = -maxSpeed;
                }
            }

            if (pos.y > boundY)
            {
                pos.y = boundY;
                vel.y = 0;
            }
            else if (pos.y < -boundY)
            {
                pos.y = -boundY;
                vel.y = 0;
            }
            rb2d.velocity = vel;
            transform.position = pos;
        }
    }
}
