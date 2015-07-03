using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour
{

    public int damage;
    public float bullet_speed;
    public static float rof;
    public float firerate;
    public float self_destruct_timer;
    public GameObject hit_enemy;
    public EnemyBehaviour enemy_script;
    private int enemy_health;
    public GameObject destroyed_enemy;
    public GameObject item_to_drop;
    
    public static GameObject lootmanager;
    

    // Use this for initialization
    
    void Start()
    {
        rof = 1 / firerate;
        Destroy(gameObject, self_destruct_timer);
        
        lootmanager = GameObject.FindGameObjectWithTag("lootmanager");
        //Debug.Log(lootmanager + "is your lootmanager!");
        
    }

    
    
    // Update is called once per frame    
    
    void Update()
    {
        gameObject.transform.Translate(0, bullet_speed * Time.deltaTime * Pause.timescale, 0);
    }

    
    void OnTriggerEnter2D(Collider2D othercollider)
    {
        if (othercollider.tag == "enemy")
        {
            hit_enemy = othercollider.gameObject;
            enemy_script = hit_enemy.GetComponent<EnemyBehaviour>();
            
            if (enemy_script.health >= 1)
            {
                enemy_script.health -= damage;
            }
            
            
            Destroy(gameObject); 
        }
            //Debug.Log("hit"+othercollider);
    }

}