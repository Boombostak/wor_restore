using UnityEngine;
using System.Collections;
using System;

public class enemyspawner : MonoBehaviour {

    public GameObject enemymanager;
    public GameObject thing_to_spawn;

    public float time_between_spawns;
    public int number_to_spawn = 3;
	public int numberspawned =0;
    public float countdown;

    public enum Movement_Pattern {forward, sine_wave, chase_player};
    public Movement_Pattern movement_switch;

	public enum EnemyType {space, ground, water};
	public EnemyType enemy_type_switch;

    public string movement_pattern;
    public float sineamplitude;

	public string enemy_type;
    
    // Use this for initialization
	void Start () {
        countdown = 0.01f;
        enemymanager = GameObject.FindGameObjectWithTag("enemymanager");
        //Debug.Log("Your enemymanager is" + enemymanager);

        
        switch (movement_switch)
        {
            case Movement_Pattern.forward: movement_pattern = "forward";
                break;
            case Movement_Pattern.sine_wave: movement_pattern = "sine_wave";
                break;
            case Movement_Pattern.chase_player : movement_pattern = "chase_player";
                break;
            default :Debug.Log("No movement pattern!!!");
                break;
        }

		switch (enemy_type_switch)
		{
		case EnemyType.space: enemy_type = "space";
			break;
		case EnemyType.ground: enemy_type = "ground";
			break;
		case EnemyType.water : enemy_type = "water";
			break;
		default :Debug.Log("No enemy type!!!");
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
        countdown = countdown - Time.deltaTime;
        if (countdown <= 0 && numberspawned<number_to_spawn)
        {
            thing_to_spawn = enemymanager.GetComponent<EnemyManagerGO>().SpawnAnEnemy(this.transform, "Union", enemy_type);
            thing_to_spawn.GetComponent<EnemyBehaviour>().movement_pattern_string = movement_pattern;
            thing_to_spawn.GetComponent<EnemyBehaviour>().sineamplitude = sineamplitude;
            //GameObject.Instantiate (thing_to_spawn, this.transform.position, this.transform.rotation);
			numberspawned++;
            countdown = time_between_spawns;
        }
	
	}
}
