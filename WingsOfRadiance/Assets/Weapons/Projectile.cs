using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float initialdamage;
	public float animdamagemodifier;
	public int finaldamage;
    public float speed;
    public GameObject hit_enemy;
    public EnemyBehaviour enemy_script;

    void Start()
    {

    }

    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * speed * Pause.timescale);
    }

    void OnTriggerEnter2D(Collider2D othercollider)
    {
        if (othercollider.tag == "enemy")
        {
            hit_enemy = othercollider.gameObject;
            enemy_script = hit_enemy.GetComponent<EnemyBehaviour>();
			finaldamage = (int)Mathf.Clamp (initialdamage + animdamagemodifier, 0, Mathf.Infinity);

            if (enemy_script.health >= 1)
            {
                enemy_script.health -= finaldamage;
            }
            this.gameObject.Recycle();
        }
        //Debug.Log("hit"+othercollider);
    }

	public void AnimDestroy(){
				Destroy (this.gameObject);
		}

}
