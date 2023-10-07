using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerArea : MonoBehaviour
{
    public Animator animator;
    public string animationName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            animator.SetTrigger(animationName);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            animator.SetTrigger(animationName);
        }
    }
}
