using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerRun : MonoBehaviour
{

    public event EventHandler OnFlipEvent;

    public bool facingRight = true;
    [SerializeField] Collider2D standingCollider;
    [SerializeField] SpriteRenderer spriteRenderer;

   

    [Header("Events")]
    [Space]

    public UnityEvent OnFlip;

 

    public void Right(InputAction.CallbackContext context)
    {

            if (facingRight != true)
            {
                Flip();
            }
        
    }

    public void Left(InputAction.CallbackContext context)
    {

        if (facingRight != false)
        {
            Flip();
        }

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;
        spriteRenderer.flipX = facingRight;
        OnFlipEvent.Invoke(this, EventArgs.Empty);

    }
}
