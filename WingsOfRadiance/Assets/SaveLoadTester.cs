using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveLoadTester : MonoBehaviour {

    public List<GameState> games;
    
    // Use this for initialization
	void Start () {
        games = SaveLoad.savedgames;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
