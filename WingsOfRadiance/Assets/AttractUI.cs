using UnityEngine;
using System.Collections;

public class AttractUI : MonoBehaviour {

    public Animation anim1;
    public Animation anim2;
    
    // Use this for initialization
	void Start () {
        anim1.playAutomatically = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (anim1.isPlaying==false)
        {
            anim2.Play();
        }
        if (anim2.isPlaying==false)
        {
            anim1.Play();
        }
	}
}
