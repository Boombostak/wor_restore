using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputFieldAutoSelect : MonoBehaviour {

    /*public bool alwaysAutoSelect = true;
    
    void OnEnable()
    {
        Select();
    }*/
    
    
    void Update()
    {
        if (!this.GetComponent<InputField>().isFocused)
        {
            this.GetComponent<InputField>().Select();
        }
    }

    /*public void Select()
    {
            this.GetComponent<InputField>().Select();
            Debug.Log("called Select");
            Debug.Log(this.GetComponent<InputField>());
    }*/
}
