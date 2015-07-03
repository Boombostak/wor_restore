using UnityEngine;
using System.Collections;

public class EMForward : MonoBehaviour {

	public float speed = 0.1f;
	public Vector3 backgroundvector;
	public Vector3 movementvector;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        movementvector = ((Vector3.up) * speed);//UP is y axis
		this.gameObject.transform.Translate (movementvector * Time.deltaTime *Pause.timescale);
		transform.Translate (backgroundvector * (Time.deltaTime * Pause.timescale), Space.World);
	}
}
