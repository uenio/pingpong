using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class LeftPaddleController : MonoBehaviour {

	Controller controller;
	private float inital = 250;
	private float zero_window = 50;
	public float speed = 10.0f;
	public float boundY = 2.25f;
	private Rigidbody2D rb2d;

	void Start()
	{
		controller = new Controller ();
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		Frame frame = controller.Frame ();

		if (frame.Hands.Count > 0) 
		{
			Hand hand = frame.Hands [0];

			List<Finger> finger = hand.Fingers;
			Finger indexFinger = finger [1];
			if(indexFinger.IsExtended)
			{
				Debug.Log (" Here are your current frames!" + finger[1].TipPosition.y);
				var vel = rb2d.velocity;

				if (indexFinger.TipPosition.y > inital+zero_window) {
					vel.y = speed;
				} else if (indexFinger.TipPosition.y < inital-zero_window) {
					vel.y = -speed;
				} else {
					vel.y = 0;
				}

				rb2d.velocity = vel;

					
			}
				


			//Finger finger = hand.finger (1);

		}

		var pos = transform.position;
		if (pos.y > boundY) {
			pos.y = boundY;
		} else if (pos.y < -boundY) {
			pos.y = -boundY;
		}
		transform.position = pos;
	}


}
