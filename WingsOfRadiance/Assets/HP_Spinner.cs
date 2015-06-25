using UnityEngine;
using System.Collections;

public class HP_Spinner : MonoBehaviour {

    //Swings *angle* to either side of the y axis. Halve or double as needed.
    //Make angle negative to reverse direction.

    public float rotation_speed;
    public bool random_direction;
    private int signmult = 1;


    private float _Time;


    void Start()
    {
        if (random_direction)
        {
            signmult = ((Random.Range(0,2) * 2) - 1);//random ints exclude the max value!
            //Debug.Log("sign of HP rotator is" + signmult);
        }
    }

    void Update()
    {
        {
            transform.Rotate(0f, 0f, (rotation_speed * Time.deltaTime * signmult));
        }
    }
}
