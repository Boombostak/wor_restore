using UnityEngine;
using System.Collections;

public class LootManager : MonoBehaviour {

    private GameObject player;
    private int level_int;
    private GameObject level_selectionGO;
    private GameObject itemtype_selectionGO;
    private GameObject itemrarity_selectionGO;
    public GameObject droppeditem_selectionGO;
    public GameObject itemtodrop;

    private GameObject[] playerlevelarray;
    private GameObject[] itemtypearray;
    private GameObject[] itemrarityarray;
    private GameObject[] itemGOarray;

    private int typerng;
    private int typelength;
    private int rarityrng;
    private int raritylength;
    private int droppeditemrng;
    private int droppeditemlength;
    
    // Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        level_int = player.GetComponent<PlayerLvl>().playerlvl; //Defines the player's level.
        
        playerlevelarray = new GameObject[this.gameObject.transform.childCount];
        level_selectionGO = playerlevelarray[level_int]; //Selects the GO associated with the player's level.
        //Note that player level is 0-indexed. First element is 0.

        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject DropAnItem()
    {
        itemtypearray = new GameObject[level_selectionGO.transform.childCount];
        typelength = itemtypearray.Length;
        typerng = Random.Range(0, typelength);
        itemtype_selectionGO = itemtypearray[typerng]; //Selects the GO representing item type.
        
        itemrarityarray = new GameObject[itemtype_selectionGO.transform.childCount];
        raritylength = itemrarityarray.Length;
        rarityrng = Random.Range(0, raritylength);
        itemrarity_selectionGO = itemrarityarray[rarityrng];

        itemGOarray = new GameObject[itemrarity_selectionGO.transform.childCount];
        droppeditemlength = itemGOarray.Length;
        droppeditemrng = Random.Range(0, droppeditemlength);
        droppeditem_selectionGO = itemGOarray[droppeditemrng];

        /*itemtodrop = droppeditem_selectionGO;
        
        typerng = Random.Range(0, typelength);
        rarityrng = Random.Range(0, raritylength);
        droppeditemrng = Random.Range(0, droppeditemlength);*/

        return droppeditem_selectionGO;
        
    }
}
