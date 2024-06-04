using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rigidbody2d;

    [Range(0, .3f)]
    [SerializeField]
    private float movementSmoothing = .05f;

    private Vector3 velocity = Vector3.zero;

    [SerializeField] bool doubleJump;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] float maxJumpSpeed = 4;

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;

    [SerializeField] Vector3 direction;

    [SerializeField] Collider2D playerCollider;

    const float groundedRadius = .1f;

    [SerializeField] bool grounded;

     [SerializeField]float timer;
    [SerializeField] float dobleJumpTimer;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;


    [Space]

    public UnityEvent OnJumpEvent;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        jumpForce = PlayerStatics.Instance.jumpForce;

        if (grounded == false)
        {
            timer += Time.deltaTime;
            dobleJumpTimer += Time.deltaTime;
        }
        
        
    }
    private void FixedUpdate()
    {
        if (rigidbody2d.velocity.y >= maxJumpSpeed)
        {
            rigidbody2d.velocity = Vector3.SmoothDamp(rigidbody2d.velocity, direction, ref velocity, movementSmoothing);
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);


        if (grounded == false && timer > .5f)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    if (playerCollider.IsTouchingLayers(LayerMask.GetMask("ground")) && timer > 0)
                    {
                        OnLandEvent.Invoke();
                        grounded = true;
                        doubleJump = true;
                        timer = 0;
                        dobleJumpTimer = 0;
                    }

                }
            }
        }
        
    }

    public void OnJumper(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (grounded == true)
            {
                AudioManager.Instance.Jump();
                grounded = false;
                OnJumpEvent.Invoke(); 
                rigidbody2d.AddForce(new Vector2(0f, jumpForce));
                dobleJumpTimer = 0;
            }

  
        }

        if (context.phase == InputActionPhase.Performed && grounded == false)
        {
            

            if (doubleJump == true && grounded == false && dobleJumpTimer > .3f)
            {

                AudioManager.Instance.Jump();
                doubleJump = false;
                OnJumpEvent.Invoke();
                rigidbody2d.AddForce(new Vector2(0f, jumpForce));
            }
        }


    } 
        
}

