using UnityEngine;
using System.Collections;

public class Cleanup : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name != "cleanup")
        {
        Destroy(collider.gameObject);
        }
    }
}
