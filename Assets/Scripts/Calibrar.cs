using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Calibrar : MonoBehaviour {
	CanvasGroup group;
	public Sprite[] MessageSprite;
	KinectManager kinect;

	// Use this for initialization
	void Start () {
		group = GetComponent<CanvasGroup> ();
		enableMSG ();
		kinect = GameObject.FindObjectOfType<KinectManager> ();
        
    } 

	// Update is called once per frame
	void Update () {
		
	}

	public void enableMSG(){
		if (!(GetComponent<CanvasRenderer> ().GetColor () == Color.red)){
			print("red enter");
			this.GetComponent<CanvasRenderer> ().SetColor (Color.red);
			this.GetComponentInChildren<Text> ().text = "Usuário não encontrado, mova-se diante do sensor!";
			group.alpha = 1f;
			group.blocksRaycasts = true;
			group.interactable = true;	
		}
	}

	IEnumerator pausa()
	{
		yield return new WaitForSeconds(1.5f);
		group.alpha = 0f;
		group.blocksRaycasts = false;
		group.interactable = false;
	}

	public void disableMSG(){
		if(!(GetComponent<CanvasRenderer> ().GetColor () == Color.green)){
			print("green enter");
			this.GetComponent<CanvasRenderer> ().SetColor (Color.green);
			this.GetComponentInChildren<Text> ().text = "Calibração concluída!";

			Image[] images = GetComponentsInChildren<Image>();
			foreach(Image image in images){
				if(image.CompareTag ("ImgCalibrar")){
					image.sprite = MessageSprite [1];
				}
			}
			//StartCoroutine(pausa ());
			group.alpha = 0f;
			group.blocksRaycasts = false;
			group.interactable = false;
			// provisório
		}
	}

	public void warningMSG(){
		if(!(GetComponent<CanvasRenderer> ().GetColor () == Color.yellow)){
			print("yellow enter");
			this.GetComponent<CanvasRenderer> ().SetColor (Color.yellow);
			this.GetComponentInChildren<Text> ().text = "Aguarde enquanto a calibração está sendo executada!";
			group.alpha = 1f;
		}	
	}
}
