using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PilotStatusUI : MonoBehaviour
{

    public PlayerTraits playertraits;
    public Text nameText;
    public Text experienceText;
    public Text levelText;
    public Text gunneryText;
    public Text pilotingText;
    public Text techText;
    public GameObject textboxGO;
    public Font font;
    public bool canLevelUp;

    //level-up variables
    public int pointsToSpend;
    public Text pointsText;
    public Button[] addButtons;
    public Button[] subtractButtons;
    public int pendingGunneryPoints;
    public int pendingPilotingPoints;
    public int pendingTechPoints;


    void OnEnable()
    {
        playertraits = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTraits>();

        nameText.text = "Name: " + playertraits.playername;
        experienceText.text = "Experience " + playertraits.xp;
        levelText.text = " Level" + playertraits.playerlvl;
        gunneryText.text = playertraits.gunnery_skill.ToString();
        pilotingText.text = playertraits.piloting_skill.ToString();
        techText.text = playertraits.tech_skill.ToString();
        //font redundancy
        nameText.font = font; experienceText.font = font; levelText.font = font; gunneryText.font = font; pilotingText.font = font; techText.font = font;

        //levelling
        HideLevelUpButtons();
        if (playertraits.xp > ExperienceTable.xp_for_level_i[playertraits.playerlvl] && !canLevelUp)
        {
            canLevelUp = true;
            pointsToSpend = 5;
            ShowLevelUpButtons();
        }
    }

    void ShowLevelUpButtons()
    {
        if (canLevelUp == true && pointsToSpend > 0)
        {
            for (int i = 0; i < addButtons.Length; i++)
            {
                addButtons[i].gameObject.SetActive(true);
            }
        }
        
        if (canLevelUp == true && pointsToSpend > 0)
        {
            for (int i = 0; i < subtractButtons.Length; i++)
            {
                subtractButtons[i].gameObject.SetActive(true);
            }
        }
    }

    void HideLevelUpButtons()
    {
        if (canLevelUp == false && pointsToSpend <= 0)
        {
            for (int i = 0; i < addButtons.Length; i++)
            {
                addButtons[i].gameObject.SetActive(false);
            }
        }

        if (canLevelUp == false && pointsToSpend <= 0)
        {
            for (int i = 0; i < subtractButtons.Length; i++)
            {
                subtractButtons[i].gameObject.SetActive(false);
            }
        }
    }
}
