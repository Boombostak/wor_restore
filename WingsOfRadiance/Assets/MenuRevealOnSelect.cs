using UnityEngine;
using System.Collections;

public class MenuRevealOnSelect : MonoBehaviour
{

    public MenuJoystickInput menuJoystickInput;
    public string childToReveal;

    // Update is called once per frame
    void Update()
    {
        if (menuJoystickInput.selected_button.transform.Find(childToReveal) != null)
        {
            menuJoystickInput.selected_button.transform.Find(childToReveal).gameObject.SetActive(true);
        }
        if (Input.GetAxisRaw("Vertical") < 0 && !menuJoystickInput.isRunningUp
            && menuJoystickInput.selected_button.transform.Find(childToReveal) != null)
        {
            menuJoystickInput.selected_button.transform.Find(childToReveal).gameObject.SetActive(false);
        }
        if (Input.GetAxisRaw("Vertical") > 0 && !menuJoystickInput.isRunningDown
            && menuJoystickInput.selected_button.transform.Find(childToReveal) != null)
        {
            menuJoystickInput.selected_button.transform.Find(childToReveal).gameObject.SetActive(false);
        }
        if (this.transform.Find(childToReveal) != menuJoystickInput.selected_button.transform.Find(childToReveal) &&
            this.transform.Find(childToReveal) != null)
        {
            this.transform.Find(childToReveal).gameObject.SetActive(false);
        }
    }
}
