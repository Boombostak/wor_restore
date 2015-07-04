using UnityEngine;
using System.Collections;

public class ItemBehaviour : MonoBehaviour {

    //Moves items, reflects them off camera bounds, deletes them after a time limit, allows player to pick up.
    //Should also handle inventory interactions.

    public Vector3 itemvector;
    public float speed = 0.05f;
    public Inventory inventory;
    public GameObject currentitem;
    public int size; //for inventory
    public float lifetime;
    //public float countup = 0;
    public Color itemcolor;
    public bool isblinking = false;
	public enum ItemType { fuselage, computer, engine, scoop, weapon, system, medal};
	public ItemType itemtype;
	public string itemtype_string;
	public AudioClip audioclip;
    
    void Start()
    {
        itemvector = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), 0f);
        inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<Inventory>();
        itemcolor = this.GetComponent<SpriteRenderer>().color;
        if (Application.loadedLevelName == "test")//this prevents timers from running in inventory scenes
        {
            StartCoroutine(ItemTimer());
        }

		switch (itemtype)
		{
		case ItemType.fuselage: itemtype_string = "fuselage"; 
			audioclip = Resources.Load ("fuselage") as AudioClip;
			break;
		case ItemType.computer: itemtype_string = "computer";
			audioclip = Resources.Load ("computer") as AudioClip;
			break;
		case ItemType.engine: itemtype_string = "engine";
			audioclip = Resources.Load ("engine") as AudioClip;
			break;
		case ItemType.scoop: itemtype_string = "scoop";
			audioclip = Resources.Load ("scoop") as AudioClip;
			break;
		case ItemType.weapon: itemtype_string = "weapon";
			audioclip = Resources.Load ("weapon") as AudioClip;
			break;
		case ItemType.system: itemtype_string = "system";
			audioclip = Resources.Load ("system") as AudioClip;
			break;
		case ItemType.medal: itemtype_string = "medal";
			audioclip = Resources.Load ("decoration") as AudioClip;
			break;
		default :Debug.Log("No movement pattern!!!");
			break;
		}
    }
    
    void ItemMove()
    {
        transform.Translate(itemvector.normalized * speed);
    }

    void ItemReflect()
    {
        
    }

    //FIGURE THIS OUT! COROUTINES!
    //Works now!
    IEnumerator ItemTimer()
    {
        float timer = lifetime;
        //Debug.Log("timer"+ timer);
        while (timer > 2f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        while (timer <= 2f && timer > 0)
        {
            if (isblinking == false)
            {
                StartCoroutine(ItemBlink());
            }
            timer -= Time.deltaTime;
            yield return null;
        }
        while (timer <= 0f)
        {
            Destroy(this.gameObject);
            yield return null;
        }
    }

    IEnumerator ItemBlink()
    {
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<Renderer>().enabled = !this.GetComponent<Renderer>().enabled;
        isblinking = true;
        //Debug.Log("called itemblink");
    }

    void OnTriggerEnter2D(Collider2D othercollider)
    {
        if (othercollider.tag == "Player")
        {
			bool full =  false;
            //Debug.Log("item touched player");
            full = inventory.AddItem(this.gameObject);
            if (!full)
			{
                this.gameObject.SetActive(false);
				AudioManager.instance.PlaySingle(audioclip);
            }
        }
    }

    void Update()
    {
        ItemMove();
    }
}
