using UnityEngine;
using System.Collections;

public class MatterEnergy : MonoBehaviour {

	public GameObject player;
	public PlayerTraits playertraits;
	public int matter;
	public int energy;
	public float lifetime;
	public bool isblinking;

	void Start()
	{
		this.gameObject.CreatePool();
		player = GameObject.FindGameObjectWithTag("Player");
		if (Application.loadedLevelName == "test")//this prevents timers from running in inventory scenes
		{
			StartCoroutine(DebrisTimer());
		}
	}

	void OnTriggerEnter2D(Collider2D othercollider)
	{
		if (othercollider.tag == "Player")
		{
			playertraits = othercollider.gameObject.GetComponent<PlayerTraits>();
			
			if (playertraits.currentmatter < playertraits.matter_max || playertraits.currentenergy < playertraits.energy_max)
			{
				playertraits.currentmatter += matter;
				playertraits.currentenergy += energy;
				this.gameObject.Recycle();
			}
		}
		//Debug.Log("hit"+othercollider);
	}

	IEnumerator DebrisTimer()
	{
		float timer = lifetime;
		Debug.Log("timer"+ timer);
		while (timer > 2f)
		{
			timer -= Time.deltaTime;
			yield return null;
		}
		while (timer <= 2f && timer > 0)
		{
			if (isblinking == false)
			{
				StartCoroutine(DebrisBlink());
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
	
	IEnumerator DebrisBlink()
	{
		yield return new WaitForSeconds(0.2f);
		this.renderer.enabled = !this.renderer.enabled;
		isblinking = true;
		Debug.Log("called itemblink");
	}
}
