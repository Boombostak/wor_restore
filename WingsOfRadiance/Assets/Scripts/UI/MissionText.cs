using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissionText : MonoBehaviour {

	//elements of UI object
	public GameObject missionselectionsUI;
	public Text _text;
	//elements of MissionManager
	public GameObject missionmanager;

	// Use this for initialization
	void Start () {
		missionselectionsUI = GameObject.Find ("MissionSelections");
		//Debug.Log ("MissionSelections is" + missionselectionsUI);
		missionmanager = GameObject.Find ("MissionManager");
		//Debug.Log ("MissionManager is" + missionmanager);

		for (int i = 0; i < missionmanager.transform.childCount; i++) {
			_text = missionselectionsUI.transform.GetChild(i).GetChild(0).GetComponent<Text>();
			_text.text = 	
				missionmanager.transform.GetChild(i).name + 
				"Level:" + missionmanager.transform.GetChild(i).GetComponent<Mission>().missionlevel +
				"Environment:" + missionmanager.transform.GetChild(i).GetComponent<Mission>().startingtile;
				missionselectionsUI.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = _text.text;


				}
	}
}