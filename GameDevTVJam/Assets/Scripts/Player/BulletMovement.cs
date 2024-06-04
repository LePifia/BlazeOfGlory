using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    float projectileSpeed;
    [SerializeField] PlayerRun playerRun;
    [SerializeField] SpriteRenderer spriteRenderer;
    bool right = true;
    Rigidbody2D rb;


    private void Awake()
    {
       gameObject.GetComponent<PlayerShooter>();
       rb = GetComponent<Rigidbody2D>();
       playerRun = FindObjectOfType<PlayerRun>();

    }

    private void Start()
    {
        playerRun.OnFlipEvent += PlayerRun_OnFlipEvent;

        projectileSpeed = PlayerStatics.Instance.projectileSpeed;

    }

    private void PlayerRun_OnFlipEvent(object sender, System.EventArgs e)
    {
        Flip();
        right = playerRun.facingRight;
    }

    void Update()
    {

        projectileSpeed = PlayerStatics.Instance.projectileSpeed;
        

        if (right != playerRun.facingRight)
        {
            Flip();
            right = playerRun.facingRight;
        }

        

        if (right == false)
        {
            rb.velocity = transform.right * projectileSpeed;

        }
        else
        {
            rb.velocity = transform.right * -1 * projectileSpeed;
  
        }

        if (transform.position.x > 4.5 || transform.position.x < -4.5)
        {
            gameObject.SetActive(false);
        }
        
    }

    

    public void Flip()
    {

        spriteRenderer.flipX = right;

    }

    private void OnDestroy()
    {
        playerRun.OnFlipEvent -= PlayerRun_OnFlipEvent;
    }

}
