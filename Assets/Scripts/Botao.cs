using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botao : MonoBehaviour {
	private float timer = 0.0f;
	private float seconds = 0.0f;
	private Mouse meucursor;
	private Bounds botaoInUnityPixels;
	private float mouseClick = 2.0f;
	private CapturarMovimentos Kouvinte;
	public bool selected = false;
	private static List<Botao> botoes = new List<Botao>();
	private static int count = 1;

	private static Botao instancia;

	public static Botao Instance {
		get
		{
			return instancia;
		}
	}

	// Use this for initialization
	void Start () {
		instancia = this;
		Kouvinte = CapturarMovimentos.Instance;
		botoes.Add (this);
	}
	
	// Update is called once per frame
	void Update () {
		print ("max: "+ botoes.Count);
		print ("sum: "+ count);
		if(selected){
			GetComponent<Text> ().color = new Color(GetComponent<Text> ().color.r, GetComponent<Text> ().color.g, GetComponent<Text> ().color.b, Mathf.PingPong(Time.time, 1));
		}else{
			GetComponent<Text> ().color = Color.white;
		}

		timer += Time.deltaTime;
		seconds = Mathf.Floor(timer % 60);
		//fakeColission();

		if(Kouvinte && selected){
			if(Kouvinte.IsSwipeDown ()){
				print("entrou no clicque");
				fakeClick ();
			}else if(Kouvinte.IsSwipeLeft ()){
				nextButton ();
			}else if(Kouvinte.IsSwipeRight ()){
				previusButton ();
			}
		}
	}


	void fakeColission(){
		meucursor = GameObject.FindObjectOfType<Mouse> ();
		botaoInUnityPixels = new Bounds();
		botaoInUnityPixels.center = GetComponent<Collider2D>().bounds.center / Screen.width * 16;
		botaoInUnityPixels.extents = GetComponent<Collider2D>().bounds.extents / Screen.width * 16;

		if (botaoInUnityPixels.Intersects(meucursor.GetComponent<PolygonCollider2D>().bounds))
		{
			//GetComponent<Text>().color = Color.green;

			if(seconds > mouseClick)
			{
				timer = 0.0f;
				fakeClick(); 

			}
		}
		else
		{
			//GetComponent<Text>().color = Color.white;
			timer = 0.0f;
		}
		
	}

	public void fakeClick(){
		//GetComponent<Text>().color = Color.magenta;
		GetComponent<Button>().onClick.Invoke();
	}

	public static void nextButton(){
		if(count < botoes.Count ){
			botoes [count-1].selected = false;
			count++;
			botoes [count-1].selected = true;
		}
	}

	public static void previusButton(){
		if(count > 1){
			botoes[count-1].selected = false;
			count--;
			botoes [count-1].selected = true;
		}
	}

	public void clearVector(){
		botoes.Clear ();
		count = 1;
	}
}
