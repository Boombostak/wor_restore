using UnityEngine;
using System.Collections;

public class ClassSelection : MonoBehaviour {

    public int gunnery;
    public int piloting;
    public int tech;
    private PlayerTraits playertraits;
    public static bool traitsHaveBeenAssigned = false;
    public static PilotUI pilotui;

    void Start()
    {
        pilotui = GameObject.Find("PilotUI").GetComponent<PilotUI>();
        playertraits = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTraits>();
    }

    public void AssignClassTraits()
    {
        if (traitsHaveBeenAssigned == false)
        {
            playertraits.gunnery_skill = gunnery;
            playertraits.piloting_skill = piloting;
            playertraits.tech_skill = tech;
            traitsHaveBeenAssigned = true;
            pilotui.CheckForClassSelection();
        }
        else
        {
            Debug.Log("A class has already been chosen!!!");
        }
    }
}
