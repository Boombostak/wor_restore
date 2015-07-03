using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour{

	public static float timescale = 1f;
	public static bool isPaused = false;
	public GameObject InGameMenu;
	private GameObject _ingamemenu;

	void Start(){
		_ingamemenu = GameObject.Instantiate (InGameMenu) as GameObject;
		_ingamemenu.SetActive (false);
	}

	public void PauseGame(){
		timescale = 0f;
		_ingamemenu.SetActive (true);
		isPaused = true;

	}

	public void UnpauseGame(){
		timescale = 1f;
		_ingamemenu.SetActive (false);
		isPaused = false;
	}

	void Update(){
		if (Input.GetButtonDown ("InGameMenu")) {
			if (!isPaused) {
				PauseGame ();
			}
			else {
				UnpauseGame();
			}
		}
		//Debug.Log ("TIMESCALE"+timescale);
		//Debug.Log ("InGameMenu"+Input.GetButtonDown("InGameMenu"));
		//Debug.Log ("isPaused" + isPaused);
	}
}
