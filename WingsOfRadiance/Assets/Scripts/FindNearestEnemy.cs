using UnityEngine;
using System.Collections;

public class FindNearestEnemy : MonoBehaviour
{

    public GameObject[] gos;
    public float distance;
    public GameObject closest;
    public float mindist;

    void Awake()
    {
        InvokeRepeating("FindClosestEnemy", 0.5f, 0.5f);
    }

    GameObject FindClosestEnemy()
    {
        gos = GameObject.FindGameObjectsWithTag("enemy");
        distance = Mathf.Infinity;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        //Debug.Log(closest);
        return closest;
        
    }
}
