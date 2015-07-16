using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VarToText : MonoBehaviour {

    public Text mattergui;
    public Text energygui;
    public Text storagegui;
    public PlayerTraits playertraits;
    public Inventory inventory;
    public static GameObject currentplayer;
    private int currentmattervar;
    private int maxmattervar;
    private int currentenergyvar;
    private int maxenergyvar;
    private int currentstoragevar;
    private int maxstoragevar;
    
    // Use this for initialization
	void Start () {
        currentplayer = GameObject.FindGameObjectWithTag("Player");
        playertraits = currentplayer.GetComponent<PlayerTraits>();
        inventory = currentplayer.GetComponentInChildren<Inventory>();
	
	}
	
	// Update is called once per frame
	void Update () {

        currentmattervar = playertraits.currentmatter;
        maxmattervar = playertraits.matter_max;
        currentenergyvar = playertraits.currentenergy;
        maxenergyvar = playertraits.energy_max;
        currentstoragevar = inventory.storage;
        maxstoragevar = inventory.maxstorage;

        mattergui.text = ("Matter" + currentmattervar.ToString() + "/" + maxmattervar.ToString());
        energygui.text = ("Energy" + currentenergyvar.ToString() + "/" + maxenergyvar.ToString());
        storagegui.text = ("Storage" + currentstoragevar.ToString() + "/" + maxstoragevar.ToString());
        //Debug.Log(mattergui.text);
	}
}
