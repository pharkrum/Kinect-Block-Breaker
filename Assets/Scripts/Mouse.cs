using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour {
	KinectManager kinect;
    private GameObject[] botoes;
    private Bounds botaoInUnityPixels;

    // Use this for initialization
    void Start () {
        //Cursor.visible = false;
        //cursor padrão do pc
        GameObject.DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		kinect = GameObject.FindObjectOfType<KinectManager>();
		//transform.position = Vector3.Lerp(transform.position, kinect.HandCursor1.transform.position, 0.4f);
		this.transform.position = kinect.HandCursor1.transform.position;
    }
}
