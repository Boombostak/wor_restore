using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerTraits : MonoBehaviour {

    
    public string playername;
    //basic stats
    public int xp;
    public int gunnery_skill; //damage bonus, tohit bonus, weapon requirements, special attack requirements
    public int piloting_skill; //dodge bonus, damage reduction, engine requirements, maneuver requirements
    public int tech_skill; // absorbtion bonuses, rof, all sorts of requirements, matter and energy maxes, 
                           // matter and energy regeneration, matter and energy cost reduction
    
    
    //derived stats
    public int playerlvl;
    public int matterMax;
    public int energyMax;
    public int damageReduction; //piloting
    public int damageBonus; //gunnery
    public float damageMultiplier =1;
    public float rofMultiplier =1;
    public int toDodge; //piloting
    public int toHit; //gunnery
    public int massAbsorbtion; //tech
    public int energyAbsorbtion; //tech
    public int massRegen; //tech
    public int energyRegen; //tech
    
    //special stats
    public float bountyCollection; //increases drop rates
	public int reputation;//positive means good vibes with union, negative means good vibes with corps.

    //dynamic values
    public int currentMatter;
	public int currentEnergy;
	public int credits;
    
    //special effect modifiers
    public int damageBonus_MOD;
    public int damageReduction_MOD;
    public int toDodge_MOD;



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
        

						currentMatter = matterMax;
						currentEnergy = energyMax;
				}
		}
    
    void Update()
    {
		if (currentMatter > matterMax) {currentMatter = matterMax;}
		if (currentEnergy > energyMax) {currentEnergy = energyMax;}

        if (currentMatter < 1)
        {
            PlayerDied();
        }
    }

    void PlayerDied()
    {
		Instantiate (deathexplosion, this.transform.position, Quaternion.identity);
		GameObject.Find ("MissionManager").SendMessage("PlayerDied");
		this.gameObject.SetActive (false);
        Debug.Log("Player has died");
    }

    public void AssignPlayerName(string name)
    {
        playername = name;
    }
}
