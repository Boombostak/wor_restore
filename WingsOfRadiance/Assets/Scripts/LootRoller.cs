using UnityEngine;
using System.Collections;

public class LootRoller : MonoBehaviour {

    public GameObject lootmanager;
    public GameObject whattodrop;
    private LootItemType[] loottypearray;
    private LootItemRarity[] lootrarityarray;
    private LootTable[] loottablearray;
    private GameObject[] lootitemsarray;

    //randomization

    private int type_length;
    private int type_rng;
    private int rarity_length;
    private int rarity_rng; 
    private int table_length;
    private int table_rng; 
    private int items_length;
    private int items_rng;

    public GameObject RollLoot()
    {
        
        type_rng = Random.Range(0, type_length);
        
        rarity_rng = Random.Range(0, rarity_length);
        
        table_rng = Random.Range(0, table_length);
        
        items_rng = Random.Range(0, items_length);
        
        //lootmanager = GameObject.FindGameObjectWithTag("lootmanager");
        //Debug.Log(lootmanager + "is your lootmanager!");

        lootrarityarray = loottypearray[type_rng].itemtype;
        loottablearray = lootrarityarray[rarity_rng].itemrarity;
        lootitemsarray = loottablearray[table_rng].items;
        whattodrop = lootitemsarray[items_rng];

        if (whattodrop != null)
        {
            Debug.Log("dropped(?)" + whattodrop);
            Instantiate(whattodrop, this.transform.position, this.transform.rotation);
        }

        Debug.Log("attempted to drop" + whattodrop);
        return whattodrop;
    }
    
    // Use this for initialization
	void Start () {
        lootmanager = GameObject.FindGameObjectWithTag("lootmanager");
        Debug.Log(lootmanager + "is your lootmanager!");
        type_length = lootmanager.transform.GetChild(0).GetComponent<LootLevel>().lootlevel.Length; //loottypearray.Length;
        rarity_length = lootmanager.transform.GetChild(0).GetChild(0).GetComponent<LootItemType>().itemtype.Length;  // lootrarityarray.Length;
        table_length = lootmanager.GetComponent<LootItemRarity>().itemrarity.Length;  //loottablearray.Length;
        items_length = lootmanager.GetComponent<LootTable>().items.Length;//lootitemsarray.Length;
        loottypearray = lootmanager.GetComponent<LootLevel>().lootlevel;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
