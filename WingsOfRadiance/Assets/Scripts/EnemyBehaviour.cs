using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour, IDestructible, IDamageable {

	public int xp;
	public int bounty;

	public float speed;
    public float speed_multiplier = 1;
    private Vector3 movement;
    private Vector3 spawnpoint;
    public int health = 1;
    public GameObject weapon;
    public GameObject explosion;
    public GameObject item_to_drop;
    public static GameObject lootmanager;
    public GameObject player;
    public PlayerTraits playerTraits;
    public int dropchance = 30;
    public int drop_rng;
	public int matter_to_drop;
	public GameObject[] mattergos;
	public bool moves_with_background;
	public Vector3 backgroundvector;
	public GameObject popupgui;

    public string movement_pattern_string;
    public float sineamplitude;

    // Use this for initialization
	void Start () {
        lootmanager = GameObject.FindGameObjectWithTag("lootmanager");
        player = GameObject.FindGameObjectWithTag("Player");
        if (player!=null)
        {
            playerTraits = player.GetComponent<PlayerTraits>();
            //Debug.Log(lootmanager + "is your lootmanager!");
            drop_rng = UnityEngine.Random.Range(0, 100);
            speed = speed * speed_multiplier;
            if (moves_with_background)
            {
                backgroundvector = Vector3.up * -SharedVariables.startingtile.GetComponent<BackgroundBehaviour>().scrollspeed_y;
            }
            else { backgroundvector = -Vector3.up; }
            //Debug.Log ("backgroundvector: " + backgroundvector);
            AddMovePattern(movement_pattern_string);
        }
	}
	
	// Update is called once per frame
    void Update () {

        if (health < 1)
        {
            if (drop_rng < dropchance)
            {
            item_to_drop = lootmanager.GetComponent<LootManagerGO>().DropAnItem(this.transform);
            //Debug.Log("attempted to drop" + item_to_drop);
            Instantiate(item_to_drop, this.transform.position, Quaternion.identity);
            Destroy(lootmanager.GetComponent<LootManagerGO>().thing_to_spawn);
			
            }
			for (int i = 0; i < mattergos.Length; i++) {
				Instantiate(mattergos[i], this.transform.position, Quaternion.identity);
			}
			//Instantiate(popupgui, this.transform.position, Quaternion.identity);
			Instantiate(explosion, this.transform.position, Quaternion.identity);
            DestroyThis();
        }
        
        
        
	}

    public void DamageThis(int damage)
    {

    }

    public void DestroyThis()
    {
        playerTraits.xp += this.xp;
        Destroy(this.gameObject);
    }

    void AddMovePattern(string movement_pattern_string)
    {
        switch (movement_pattern_string)
        {
            case "forward":
                //Debug.Log("I am moving forward!");
                this.gameObject.AddComponent<EMForward>();
                this.GetComponent<EMForward>().speed = speed;
				this.GetComponent<EMForward>().backgroundvector = backgroundvector;
                break;
            case "sine_wave":
                this.gameObject.AddComponent<EMSine>();
                this.GetComponent<EMSine>().linear_speed = speed;
                this.GetComponent<EMSine>().amplitude = sineamplitude;
				this.GetComponent<EMSine>().backgroundvector = backgroundvector;
                //Debug.Log("I am moving in a sine wave!");
                break;
            case default(string):
                Debug.Log("No pattern selected! ERROR");
                break;
        }
    }

	void OnTriggerEnter2D(Collider2D othercollider)
	{
		GameObject hitplayer;
		PlayerTraits enemy_script;
		if (othercollider.tag == "Player")
		{
			hitplayer = othercollider.gameObject;
			enemy_script = hitplayer.GetComponent<PlayerTraits>();
            //issue with ramming not spawning matter/energy
            enemy_script.currentmatter -= health;
            for (int i = 0; i < mattergos.Length; i++)
            {
                Instantiate(mattergos[i], this.transform.position, Quaternion.identity);
            }
			Instantiate(explosion, this.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
		//Debug.Log("hit"+othercollider);
	}
}
