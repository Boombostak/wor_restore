using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float initialdamage;
	public float animdamagemodifier;
	public int finaldamage;
    public float speed;
    public float lifeSpan = Mathf.Infinity;
    public float countUp;
    public GameObject hit_enemy;
    public EnemyBehaviour enemy_script;
    public GameObject hitSpark;

    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * speed * Pause.timescale);
        if (lifeSpan!=Mathf.Infinity)
        {
            countUp += Time.deltaTime;
            if (countUp>lifeSpan)
            {
                AnimSpawnSpark();
                AnimDestroy();
            }
        }
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
            if (hitSpark!=null)
            {
                AnimSpawnSpark();
            }
            this.gameObject.Recycle();
        }
        //Debug.Log("hit"+othercollider);
    }

	public void AnimDestroy(){
				Destroy (this.gameObject);
		}

    public void AnimSpawnSpark()
    {
        Instantiate(hitSpark, this.transform.position, this.transform.rotation);
    }

}
