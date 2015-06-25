using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour{

    public int damage;
    public float speed;
    public GameObject hit_enemy;
    public EnemyBehaviour enemy_script;

    void Start()
    {

    }

    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * speed);
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
            Destroy(this.gameObject);
        }
        //Debug.Log("hit"+othercollider);
    }
}
