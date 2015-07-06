using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PilotStatusUI : MonoBehaviour {

    public PlayerTraits playertraits;
    public Text nameText;
    public Text experienceText;
    public Text levelText;
    public Text gunneryText;
    public Text pilotingText;
    public Text techText;
    public GameObject textboxGO;
    public Font font;

    //level-up variables
    public int pointsToSpend;
    
    
	void OnEnable () {
        playertraits = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTraits>();

        nameText.text = "Name: " + playertraits.playername;
        experienceText.text = "Experience " + playertraits.xp;
        levelText.text = " Level" + playertraits.playerlvl;
        gunneryText.text = playertraits.gunnery_skill.ToString();
        pilotingText.text = playertraits.piloting_skill.ToString();
        techText.text = playertraits.tech_skill.ToString();


        nameText.font = font; experienceText.font = font; levelText.font = font; gunneryText.font = font; pilotingText.font = font; techText.font = font;
	}
}
