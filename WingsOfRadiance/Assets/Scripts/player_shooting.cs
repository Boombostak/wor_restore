using UnityEngine;
using System.Collections;

public class player_shooting : MonoBehaviour
{



    
    
    //void Update()
    //{
      //  if (Input.GetButtonDown("Fire1"))
        //    Instantiate(shot, transform.position, transform.rotation);
    //}

    //Shooting
    public float fire_rate; // number of shots per second
    public float damage; //damage per shot
    private bool shooting;
    private float shot_countdown;
    private bool ready_to_shoot;
    public Transform shot;

    
    // Use this for initialization
	public void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
        //shooting plan:
        //shot allowed when timer is at zero
        //start timer at zero
        //if shooting is true and timer is zero, fire a shot, and increment shot countdown by 1/fire_rate
        //on update, decrement countdown by 1*deltatime

        //Debug.Log(BulletBehaviour.bullet_firerate);
        
        shooting = Input.GetButton("Fire1");
        
        shot_countdown -= Time.deltaTime;//decrease the countdown

        if (shot_countdown <= 0f)
            ready_to_shoot = true;
        else
            ready_to_shoot = false;


        if (shooting && ready_to_shoot)
        {
            Instantiate(shot, transform.position, transform.rotation);//fire a shot
            shot_countdown = BulletBehaviour.rof;//increase the countdown
        }
        //Debug.Log(shot_countdown);
        //Debug.Log(Time.time);

        if (Input.GetButton("InGameMenu"))
        {
            
        }
	}
}