using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager lvlManager;

	void Start(){
		lvlManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D (Collider2D trigger){
		lvlManager.LoadLevel ("Lose Screen");
	}

	void OnCollisionEnter2d (Collision2D collision){
		print("Collision");
	}
}
