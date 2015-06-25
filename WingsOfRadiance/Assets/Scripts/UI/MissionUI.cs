using UnityEngine;
using System.Collections;

public class MissionUI : MonoBehaviour {

	public int childindex;
	public int level;
	public GameObject startingtile;
	public GameObject missionmanager;
	public GameObject missionselectionsUI;
	public Mission selectedmission;

	void Start () {
				missionselectionsUI = GameObject.Find ("MissionSelections");
				//Debug.Log ("MissionSelections is" + missionselectionsUI);
				missionmanager = GameObject.Find ("MissionManager");
				//Debug.Log ("MissionManager is" + missionmanager);
				for (int i = 0; i < missionmanager.transform.childCount; i++) {
						if (missionselectionsUI.transform.GetChild (i).name == this.transform.name) {
								childindex = i;
						}
				}
		}

	public void ClickedOnMission(){
		//Debug.Log ("level should be" + missionmanager.transform.GetChild (childindex).GetComponent<Mission> ().missionlevel);
		//Debug.Log ("startingtile should be" + missionmanager.transform.GetChild (childindex).GetComponent<Mission> ().startingtile);
		level = missionmanager.transform.GetChild(childindex).GetComponent<Mission>().missionlevel;
		startingtile = missionmanager.transform.GetChild(childindex).GetComponent<Mission> ().startingtile;
		selectedmission = missionmanager.transform.GetChild (childindex).gameObject.GetComponent<Mission>();
		//Debug.Log("SharedVars: Playerlevel:" +SharedVariables.playerlevel +"StartingTile:"+SharedVariables.startingtile+"Selectedmission:"+SharedVariables. selectedmission);

		missionmanager.GetComponent<MissionManager>().SelectMission (level, selectedmission, startingtile);
	}

	public void QuitGameUI(){
		Application.Quit();
		}
}