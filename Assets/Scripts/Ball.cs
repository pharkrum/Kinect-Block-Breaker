using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	private KinectManager kinect;

	// Use this for initialization
	void Start () {

		paddle = GameObject.FindObjectOfType<Paddle> ();
		// vetor entre a bola e a plataforma que significa a distancia entre os centros.
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!hasStarted) {
			// lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			kinect = FindObjectOfType<KinectManager> ();
            if(kinect != null)
			    if(kinect.HandCursor1.transform.position.y >= 11.0){
				    hasStarted = true;
				    this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 8f);
			    }
			if (Input.GetMouseButtonDown (0)) {
				//mouse clicked
				hasStarted = true;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
			}
			
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		AudioSource audio = this.GetComponent<AudioSource> ();
		if(hasStarted){
			audio.Play ();
			Vector2 VelocityVariation = new Vector2 (Random.Range (-0.4f, 0.4f), Random.Range (-0.4f, 0.4f));
			this.GetComponent<Rigidbody2D> ().velocity += VelocityVariation;
		}

			
	}
}
