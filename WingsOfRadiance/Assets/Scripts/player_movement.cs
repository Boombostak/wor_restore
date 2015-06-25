using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {

    //Movement
    public float speed; //speed, modified by various game rules
    private float x_dir;
    private float y_dir;
    private Vector3 movement;
    public Vector3 movement_return;
    public bool analogue_controls; //whether the controls are analogue or, if false, digital
    
    //clamping
    public float positionmin;
    public float positionmax;
    public Camera camera;
    public Vector3 bottomleftworldcoordinates;
    public Vector3 toprightworldcoordinates;
    public Vector3 movementrangemin;
    public Vector3 movementrangemax;
    public GameObject player;


    

// Use this for initialization

	void Start () {
		camera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		SharedVariables.camera = camera;
		//positionmin = CameraBehaviour.background_snapshot.min.x;
        //positionmax = CameraBehaviour.background_snapshot.max.x;
        
	}
	
// Update is called once per frame
	void Update () {
        //Move the player based on analogue input
        if (analogue_controls)
        {
            x_dir = Input.GetAxis("Horizontal");
            y_dir = Input.GetAxis("Vertical");
        }
        //Move the player based on digital, boolean input
        else
        {
            x_dir = Input.GetAxisRaw("Horizontal");
            y_dir = Input.GetAxisRaw("Vertical");
        }
        movement = new Vector3(x_dir, y_dir, 0);
        if (movement.magnitude > 1) 
        { 
            movement.Normalize(); 
        }


        bottomleftworldcoordinates = camera.ViewportToWorldPoint(Vector3.zero);
        toprightworldcoordinates = camera.ViewportToWorldPoint(new Vector3(1, 1, 0));
        movementrangemin = bottomleftworldcoordinates + this.renderer.bounds.extents;
        movementrangemax = toprightworldcoordinates - this.renderer.bounds.extents;
        movement = movement * speed * Time.deltaTime;
        transform.Translate(movement);
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, movementrangemin.x, movementrangemax.x), 
            Mathf.Clamp(this.transform.position.y, movementrangemin.y, movementrangemax.y), 
            this.transform.position.z);
        movement.y = Mathf.Clamp(this.transform.position.y, movementrangemin.y, movementrangemax.y);
        movement_return = movement;
        
        //Debug.Log(movement.magnitude);

        
        }
    }