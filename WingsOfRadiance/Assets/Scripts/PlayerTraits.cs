using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerTraits : MonoBehaviour {

    
    public string playername;
    //basic stats
    public int xp;
    public int gunnery_skill;
    public int piloting_skill;
    public int tech_skill;
    //derived stats
    public int playerlvl;
    public int matter_max;
    public int energy_max;
    public int damage_reduction;
    public int damage_bonus;
    public float damage_multiplier;
    public float rof_multiplier;
    public int avoid_chance;
    public int mass_absorbtion;
    public int energy_absorbtion;
    public int bounty_collection;
	public int reputation;//positive means good vibes with union, negative means good vibes with corps.

    //dynamic values
    public int currentmatter;
	public int currentenergy;
	public int credits;

    public float dps;
	public GameObject deathexplosion;


	void Awake(){
		SharedVariables.player = this.gameObject;
		}
	
    void Start()
    {
				for (int i = 0; i < ExperienceTable.xp_for_level_i.Length; i++) {
						if (xp >= ExperienceTable.xp_for_level_i [i]) {
								playerlvl = i;
						}
						SharedVariables.playerlevel = playerlvl;
						currentmatter = matter_max;
						currentenergy = energy_max;
				}
		}
    
    void Update()
    {
		if (currentmatter > matter_max) {currentmatter = matter_max;}
		if (currentenergy > energy_max) {currentenergy = energy_max;}

        if (currentmatter < 1)
        {
            PlayerDied();
        }
    }

    void PlayerDied()
    {
		Instantiate (deathexplosion, this.transform.position, Quaternion.identity);
		GameObject.Find ("MissionManager").SendMessage("PlayerDied");
        SharedVariables.playertraits = this.GetComponent<PlayerTraits>();
		this.gameObject.SetActive (false);
        Debug.Log("Player has died");
    }

    public void AssignPlayerName(string name)
    {
        playername = name;
    }
}
