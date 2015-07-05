using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour
{

    public GameObject[] shot_origins;
    public int hardpoints;
    public int originmax;
    public int damage;
    public float proj_speed;
    private float shot_delay;
    public float rof;
    public GameObject projectile;
    public EnemyProjectile proj_instance;
    public GameObject player;
    public GameObject thisenemy;
    public float shot_countup = 0f;
    public bool ready_to_shoot;
    public float dps;

    void Awake()
    {

        proj_instance = projectile.GetComponent<EnemyProjectile>(); ;
        //proj_instance = Instantiate(projectile) as Projectile;
    }

    void Start()
    {
        thisenemy = this.transform.parent.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        shot_delay = 1 / rof;
        dps = rof * (float)damage;

        proj_instance.damage = damage;
        proj_instance.speed = proj_speed;

        hardpoints = thisenemy.transform.Find("hardpoints").childCount;
        //Debug.Log("enemy hardpoints" + hardpoints);

        if (hardpoints > shot_origins.Length)
        {
            originmax = shot_origins.Length;
        }
        else
        {
            originmax = hardpoints;
        }
        //Debug.Log("originmax" + originmax);
        for (int i = 0; i < originmax; i++)
        {
            shot_origins[i].transform.parent = thisenemy.transform.Find("hardpoints").GetChild(i);
            shot_origins[i].transform.localPosition = Vector3.zero;
            shot_origins[i].transform.localScale = Vector3.one;
        }
    }

    void Update()
    {
        shot_countup += (Time.deltaTime*Pause.timescale);

        if (shot_countup > shot_delay && thisenemy.GetComponent<Renderer>().isVisible)
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
    }
}
