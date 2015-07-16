using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    public GameObject[] shot_origins;
    public int hardpoints;
    public GameObject currentfuselage;
    public int originmax;

    public int energycost;
    public int basedamage;
    public float floatdamage;
    public int finaldamage;
    public float base_proj_speed;
    public float final_proj_speed;
    private float shot_delay;
    public float baserof;
    public float finalrof; //shots per second
    public Projectile projectile;
    public Projectile proj_instance;
    public GameObject player;
    public PlayerTraits playertraits;
    private float shot_countup = 0f;
    private bool ready_to_shoot;
    public float basedps;
    public float finaldps;
    public string shootbutton;

    void Awake()
    {
        proj_instance = projectile;
        proj_instance.CreatePool();
    }
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playertraits = player.GetComponent<PlayerTraits>();
        currentfuselage = player.transform.Find("fuselage").GetChild(0).gameObject;
        //Debug.Log("curret fuselage is" + currentfuselage);
        floatdamage = (float)basedamage * playertraits.damage_multiplier + (float)playertraits.damage_bonus;
        finaldamage = (int)floatdamage;
        final_proj_speed = base_proj_speed * 1;//playertrait not set up
        finalrof = baserof * playertraits.rof_multiplier;
        shot_delay = 1 / finalrof;
        basedps = baserof * (float)basedamage;
        finaldps = finalrof * (float)finaldamage;

        proj_instance.initialdamage = finaldamage;
        proj_instance.speed = final_proj_speed;

        

        if (this.transform == player.transform.FindChild("weapons").GetChild(0))
	    {
            shootbutton = "Fire1";
	    }

        if (this.transform == player.transform.FindChild("weapons").GetChild(1))
        {
            shootbutton = "Fire2";
        }
        //Debug.Log("hardpoints initial" + hardpoints);
        hardpoints = currentfuselage.transform.FindChild("hardpoints").childCount;
        //Debug.Log("hardpoints final" + hardpoints);
        if (hardpoints > shot_origins.Length)
        {
            originmax = shot_origins.Length;
        }
        else
        {
            originmax = hardpoints;
        }

        for (int i = 0; i < originmax; i++)
        {
            shot_origins[i].transform.parent = currentfuselage.transform.FindChild("hardpoints").GetChild(i);
            shot_origins[i].transform.localPosition = Vector3.zero;
        }
        
    }

    void Update()
    {
        shot_countup += (Time.deltaTime * Pause.timescale);
        //Debug.Log(shot_countup);
        
        if ((Input.GetButton(shootbutton)) && (shot_countup > shot_delay) &&(!Pause.isPaused) && (playertraits.currentenergy - energycost >= 0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        foreach (GameObject i in shot_origins)
        {
            proj_instance.Spawn(i.transform.position, i.transform.rotation);
        }
            shot_countup = 0;
            playertraits.currentenergy -= energycost;
    }

    //consider replacing with a nested for loop that makes each shot origin a child of the player's hardpoints in order
}