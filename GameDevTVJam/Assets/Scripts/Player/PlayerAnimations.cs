using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
 

    private int randomAttack;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Idle()
    {
        animator.SetBool("OnFloor",true);
        animator.SetBool("Jump", false);
    }

    public void Jump()
    {
        animator.SetBool("OnFloor", false);
        animator.SetBool("Jump",true);
    }


    public void Attack()
    {
        randomAttack = Random.Range(0, 3);
        Debug.Log(randomAttack);

        if (randomAttack == 0)
        {
            animator.SetTrigger("Punch");
        }

        if (randomAttack == 1)
        {
            animator.SetTrigger("Punch1");
        }

        if (randomAttack == 2)
        {
            animator.SetTrigger("Kick");
        }

        if (randomAttack == 3)
        {
            animator.SetTrigger("Kick1");
        }
    }


}
