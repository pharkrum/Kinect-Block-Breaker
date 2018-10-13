using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public bool kinectPlay = false;

	private Ball ball;
    private KinectManager kinect;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	// Update is called once per frame
	void Update () {
		if(autoPlay){
			AutoPlay ();
		}else if(kinectPlay){
			MoveWithKinect();
		}else{
			MoveWithMouse ();
		}
	}

	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3(8f,this.transform.position.y,this.transform.position.z);
		// Faz isso para manter na mesma proporção caso o tamanho da tela mude, o valor relativo do mouse será o mesmo, entre 0 e 1 * 16 game unitys
		float mousePosBlocks = Input.mousePosition.x / Screen.width *22;
		//clamp define o intervalo em que esse numero pode possuir.
		paddlePos.x = Mathf.Clamp (mousePosBlocks, -1.35f, 17.35f);
		this.transform.position = paddlePos;
	}

    void MoveWithKinect()
    {
        Vector3 paddlePos = new Vector3(8f, this.transform.position.y, this.transform.position.z);
        kinect = GameObject.FindObjectOfType<KinectManager>();
        float KinectPosBlocks = kinect.HandCursor1.transform.position.x;
        //clamp define o intervalo em que esse numero pode possuir.
		paddlePos.x = Mathf.Clamp (KinectPosBlocks, -1.35f, 17.35f);
        this.transform.position = paddlePos;
    }

	void AutoPlay(){
		Vector3 paddlePos = new Vector3(8f,this.transform.position.y,this.transform.position.z);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, -1.35f, 17.35f);
		this.transform.position = paddlePos;
	}
}
