using UnityEngine;
using System.Collections;

public class PilotUI : MonoBehaviour {

    public GameObject classSelectUI;
    public GameObject pilotStatusUI;

    void OnEnable()
    {
        CheckForClassSelection();
    }
    
    public void CheckForClassSelection()
    {
        if (ClassSelection.traitsHaveBeenAssigned == true)
        {
            pilotStatusUI.SetActive(true);
            classSelectUI.SetActive(false);
            this.GetComponent<MenuJoystickInput>().FindActiveButtons();
        }
        else
        {
            pilotStatusUI.SetActive(false);
            classSelectUI.SetActive(true);
        }
    }
}
