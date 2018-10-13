using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//tá rodando aqui algumas coisas de calibração (mudar depois)

public class MusicPlayer : MonoBehaviour {

	public static MusicPlayer instance = null; // é um padrão de singleton que só permite que exista uma instancia disso.
	KinectManager kinect;
	//ocorre antes do start
	void Awake(){
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			//Há uma diferença entre o GameObject e o gameObject! o gameObject é o objeto que chamou esse script!
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}


	void Start () {
		//kinect = GameObject.FindObjectOfType<KinectManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		/*
		if(kinect.userFounded){
			if(kinect.Allcalibrated ()){
				GameObject.FindObjectOfType<Calibrar> ().disableMSG ();
			}
			else{
				GameObject.FindObjectOfType<Calibrar> ().warningMSG ();
			}
		}
		else{
			GameObject.FindObjectOfType<Calibrar> ().enableMSG ();
		}
		*/

	}
}
