using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class MenuJoystickInput : MonoBehaviour {

	public GameObject[] buttons;
	public GameObject selected_button;
	public GameObject held_selection;
	public Color held_highlight;
	private int current_int;
	public Color highlight;
	public Color revert;
	public bool isRunningDown;
	public bool isRunningUp;
	public bool isClickable;


	void Start () 
	{
		buttons = new GameObject[GetComponentsInChildren<Button>().Length];
		for (int i = 0; i < buttons.Length; i++) 
			{
			buttons[i] = GetComponentsInChildren<Button> ()[i].gameObject;
			}
		selected_button = buttons [0];
		current_int = 0;
		revert = buttons [0].GetComponent<Image> ().color;
		buttons [0].GetComponent<Image> ().color = highlight;
	}

	//Cleanup to catch interrupted coroutines
	void OnEnable(){StartCoroutine ("MenuClickDelay");}
	void OnDisable(){isRunningUp = false; isRunningDown = false; isClickable = true;}

	public IEnumerator MenuSelectDown()
	{
		isRunningDown = true;
		if (current_int - 1 >= 0) {
						current_int --;
						selected_button.GetComponent<Image> ().color = revert;
						selected_button = buttons [current_int];
						selected_button.GetComponent<Image> ().color = highlight;
						yield return new WaitForSeconds (0.15f);
				}
		isRunningDown = false;
	}

	public IEnumerator MenuSelectUp()
	{
		isRunningUp = true;
		if (current_int + 1 < this.GetComponentsInChildren<Button> ().Length) {
						current_int ++;
						selected_button.GetComponent<Image> ().color = revert;
						selected_button = buttons [current_int];
						selected_button.GetComponent<Image> ().color = highlight;
						yield return new WaitForSeconds(0.15f);
				}
		isRunningUp = false;
	}

	public IEnumerator MenuClick()
	{
		isClickable = false;
		selected_button.GetComponent<Button>().onClick.Invoke();
		yield return new WaitForSeconds (0.15f);
		isClickable = true;
	}

	public IEnumerator MenuClickDelay()
	{
		isClickable = false;
		yield return new WaitForSeconds (0.15f);
			isClickable = true;
	}

	void Update () 
	{
	
		if (Input.GetAxisRaw("Vertical") < 0 && !isRunningUp) 
		{
			StartCoroutine("MenuSelectUp");
		}
		if (Input.GetAxisRaw("Vertical") > 0 && !isRunningDown) 
		{
			StartCoroutine("MenuSelectDown");
		}
		if (Input.GetButton("Fire1") && isClickable) 
		{
			StartCoroutine("MenuClick");
		}
	}
}
