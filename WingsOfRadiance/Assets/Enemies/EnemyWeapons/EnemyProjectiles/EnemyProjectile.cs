using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

    public int damage;
    public float speed;
    public GameObject hitplayer;
    public PlayerTraits enemy_script;
    public enum Projectile_Movement_Type { forward, sine_wave, homing};
    public Projectile_Movement_Type movement_switch;
    public Vector3 movementvector = Vector3.up;
    public float sine_amplitude =1f;
    public float homing_damping = 1.0f;//high values make for perfect homing.
    Quaternion rotation;
    public GameObject player;

    void Start()
    {
        this.gameObject.CreatePool();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        switch (movement_switch)
        {
            case Projectile_Movement_Type.forward: movementvector = Vector3.up;
                break;
            case Projectile_Movement_Type.sine_wave: movementvector = new Vector3(Mathf.Sin(transform.position.y), 0, 0) * sine_amplitude;
                break;
            case Projectile_Movement_Type.homing:
                rotation = Quaternion.LookRotation
                    (Vector3.forward, player.transform.position - this.transform.position);//I don't know how this works. Trial and error!
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * homing_damping);

                break;
            default: Debug.Log("No bullet pattern!!!");
                break;
        }

        this.transform.Translate(movementvector * Time.deltaTime * speed * Pause.timescale);
    }

    void OnTriggerEnter2D(Collider2D othercollider)
    {
        if (othercollider.tag == "Player")
        {
            hitplayer = othercollider.gameObject;
            enemy_script = hitplayer.GetComponent<PlayerTraits>();

            if (enemy_script.currentmatter >= 1)
            {
                enemy_script.currentmatter -= damage;
            }
            this.gameObject.Recycle();
        }
        //Debug.Log("hit"+othercollider);
    }
}
