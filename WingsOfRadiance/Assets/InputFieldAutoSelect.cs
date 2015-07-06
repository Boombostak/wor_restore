using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputFieldAutoSelect : MonoBehaviour {

    void OnEnable()
    {
        this.GetComponent<InputField>().Select();
    }
}
