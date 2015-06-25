using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class Inventory : MonoBehaviour {

    public List<GameObject> contents;
    public int maxstorage;
    public int storage;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool AddItem(GameObject item)
    {
        bool noroom;
        if (storage + item.GetComponent<ItemBehaviour>().size <= maxstorage)
        {
            contents.Add(item);
            noroom = false;
            RecountStorage();
        }
        else
        {
            noroom = true;
            Debug.Log("Inventory full!");
        }

        return noroom;
    }

    public void RecountStorage()
    {
        storage = 0;
        foreach (GameObject i in contents)
        {
            storage += i.GetComponent<ItemBehaviour>().size;
        }
    }
}
