using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;
	public GameObject smoke;

	private int timesHit;
	private LevelManager lvlmanager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		timesHit = 0;
		lvlmanager = GameObject.FindObjectOfType<LevelManager> ();
		if(isBreakable){
			breakableCount++;
		}
	}

	void OnCollisionEnter2D (Collision2D col){
		if(isBreakable){
			AudioSource.PlayClipAtPoint (crack, transform.position);
			HandleHits ();
		}	
	}

	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			breakableCount--;
			lvlmanager.BrickDestroyed ();
			ActiveSmoke ();
			Destroy (gameObject);
		}
		else{
			LoadSprites ();
		}
	}

	void ActiveSmoke(){
		// intancia algo, na posição tal , com rotação padrão.
		GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
		smokePuff.GetComponent<ParticleSystem> ().startColor = this.GetComponent<SpriteRenderer> ().color;
	}

	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites[spriteIndex];
		} else{
			Debug.LogError ("Sprite missing in "+ spriteIndex);//igual ao printf mas é visto como Erro!
		}

	}

	// TODO remover quando tiver implemetado o Win
	void SimulateWin(){
		lvlmanager.LoadNextLevel();
	}
}
