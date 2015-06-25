using UnityEngine;
using System.Collections;

public class AffixScript : MonoBehaviour {

    
    private GameObject player;
    private PlayerTraits traits;
    private int rng;
    public string teststring;
    
    
    
    //This script holds the affixes for magic items.
    //Available affixes is dependent on ilvl.

    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        traits = player.GetComponent<PlayerTraits>();
        name = gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
