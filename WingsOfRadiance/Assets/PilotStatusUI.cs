using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PilotStatusUI : MonoBehaviour {

    public PlayerTraits playertraits;
    public Text statustext;
    public GameObject textboxGO;
    public Font font;
    
    
	void OnEnable () {
        playertraits = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTraits>();

        statustext.text =
            "Name: " + playertraits.playername + "\n" +
            "Experience " + playertraits.xp + " Level" + playertraits.playerlvl + "\n" +
            "Gunnery Skill " + playertraits.gunnery_skill + "\n" +
            "Piloting Skill " + playertraits.piloting_skill + "\n" +
            "Tech Skill " + playertraits.tech_skill;

        statustext.font = font;
        textboxGO.GetComponent<Text>().text = statustext.text;
	}
}
