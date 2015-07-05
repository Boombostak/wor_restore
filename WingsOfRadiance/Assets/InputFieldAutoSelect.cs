using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputFieldAutoSelect : MonoBehaviour {

    /*void OnEnable()
    {
        this.GetComponent<InputField>().Select();
        Debug.Log("AutoSelected Input Field!");
    }*/

    void Update()
    {
        if (!this.GetComponent<InputField>().isFocused)
        {
            this.GetComponent<InputField>().Select();
        }
    }
}
