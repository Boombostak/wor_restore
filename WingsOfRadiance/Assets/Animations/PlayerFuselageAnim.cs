using UnityEngine;
using System.Collections;

public class PlayerFuselageAnim : MonoBehaviour
{

    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        
        animator.SetFloat("Horizontal", h);
    }

    /*void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            animator.SetTrigger("Die");
        }
    }*/
}