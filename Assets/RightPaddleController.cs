using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class RightPaddleController : MonoBehaviour {

	Controller controller;
	private float inital = 250;

	public float speed = 0.1f;
	public float maxSpeed = 10.0f;
	private float zero_window = 50;
	public float boundY = 2.25f;
	private Rigidbody2D rb2d;
	private int frames = 0;

	public Transform ball;

	void Start()
	{
		controller = new Controller ();
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		Frame frame = controller.Frame ();
		var pos = transform.position;


		if (frame.Hands.Count > 1) {
			Hand hand = frame.Hands [1];

			List<Finger> finger = hand.Fingers;
			Finger indexFinger = finger [1];
			if (indexFinger.IsExtended) {
				Debug.Log (" Here are your current frames!" + finger [1].TipPosition.y);
				var vel = rb2d.velocity;

				if (indexFinger.TipPosition.y > inital + zero_window) {
					vel.y = maxSpeed;
				} else if (indexFinger.TipPosition.y < inital - zero_window) {
					vel.y = -maxSpeed;
				} else {
					vel.y = 0;
				}

				rb2d.velocity = vel;


			}



			//Finger finger = hand.finger (1);

		} else {
			/*
			frames++;
			if (frames % 7 == 0)
			{
				var vel = rb2d.velocity;
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
					
				rb2d.velocity = vel;
			}
		*/
		}
		if (pos.y > boundY) {
			pos.y = boundY;
		} else if (pos.y < -boundY) {
			pos.y = -boundY;
		}
		transform.position = pos;
	}


}
