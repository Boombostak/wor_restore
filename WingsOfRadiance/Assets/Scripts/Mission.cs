using UnityEngine;
using System.Collections;

public class Mission : MonoBehaviour {

	public GameObject player;
	public PlayerTraits playertraits;
	public int missionlevel;
	public GameObject[] startingtiles;
	public GameObject startingtile;

	void Awake(){
		player = GameObject.FindGameObjectWithTag("Player");
		SharedVariables.player = player;
		playertraits = player.GetComponent<PlayerTraits>();
		missionlevel = Mathf.Clamp(playertraits.playerlvl + (Random.Range (-4,4)), 0, 19);
		//Debug.Log ("mission level is" + missionlevel);
		startingtile = startingtiles[Random.Range (0, startingtiles.Length)];
		//Debug.Log ("number of starting tiles" + startingtiles.Length);
	}
}
