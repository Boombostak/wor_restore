using UnityEngine;
using System.Collections;

public class HPPlayerTracker : MonoBehaviour {

	public GameObject player;
	public Quaternion rotation;
	public float tracking_damping;

	void Start(){player = GameObject.FindGameObjectWithTag("Player");
		//Debug.Log("player is" + player);
	}
	
	// Update is called once per frame
	void Update () {
		rotation = Quaternion.LookRotation
			(Vector3.forward, player.transform.position - this.transform.position);//I don't know how this works. Trial and error!
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * tracking_damping);
	}
}
