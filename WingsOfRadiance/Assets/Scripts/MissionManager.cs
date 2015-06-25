using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour {

	public GameObject[] missionarray = new GameObject[5];
	public GameObject selectedmission;

	void Awake(){
		MissionManager[] managers = GameObject.FindObjectsOfType<MissionManager>();
		for (int i = 0; i < managers.Length; i++) {
			if (i>=1) {
				Debug.Log ("Too many MissionManagers! Had to cull!");
				DestroyImmediate(managers[i].gameObject);
			}
				}
		
	}

	public void SelectMission(int missionlevel, Mission selectedmission, GameObject startingtile){
		SharedVariables.startingtile = startingtile;
		SharedVariables.selectedmission = selectedmission;
		SharedVariables.selectedmission.missionlevel = missionlevel;
		SharedVariables.missionlevel = missionlevel;
		//this.gameObject.GetComponent<MissionManager> (). = SharedVariables.selectedmission;
		//Debug.Log ("level" + missionlevel + "and tile" + startingtile);
		
		
		//Debug.Log("SharedVars: PlayerLevel:" +SharedVariables.playerlevel +"MissionLevel:" +SharedVariables.missionlevel+"StartingTile:"+SharedVariables.startingtile+"Selectedmission:"+SharedVariables. selectedmission);

		DontDestroyOnLoad (this);
		Application.LoadLevel ("test");
		}

	void OnLevelWasLoaded(){
		if (Application.loadedLevelName=="test") {
			GameObject.Instantiate(SharedVariables.startingtile);
			AudioManager.instance.PlayMusic(Resources.Load ("music1") as AudioClip);
			}
		if (Application.loadedLevelName=="homebase") {
			AudioManager.instance.musicSource.Stop();
				}
		}

	public void PlayerDied(){
		StartCoroutine (DeathWait ());
		}

	IEnumerator DeathWait()
	{
		yield return new WaitForSeconds(3f);
		Application.LoadLevel ("homebase");
	}
}