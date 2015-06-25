using UnityEngine;
using System.Collections;

public class HP_Sweeper : MonoBehaviour {

    //Swings *angle* to either side of the y axis. Halve or double as needed.
    //Make angle negative to reverse direction.

    public float rotation_offset;
    public float _Angle;
    public float _Period;

    private float _Time;


    void Start()
    {
        this.transform.Rotate(0,0,rotation_offset);
    }

    void Update()
    {
        {//these values are not relative to initial rotation! That's why the start method does nothing.
        _Time = _Time + Time.deltaTime;
        float phase = Mathf.Sin(_Time / _Period);
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, (phase * _Angle)));
        }
    }
}
