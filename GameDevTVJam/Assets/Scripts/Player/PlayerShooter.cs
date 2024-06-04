using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{

    [SerializeField] Transform laserPosition;

    [SerializeField] GameObject fireball;
    PlayerRun playerRun;
    bool direction;

    private void Awake()
    {
        playerRun = FindObjectOfType<PlayerRun>();
    }

    public void Firing()
    {
        FireContinualy();

    }


    private void FireContinualy()
    {
        direction = playerRun.facingRight;

        if (direction)
        {
            AudioManager.Instance.PlayShootingClip();
            Instantiate(fireball, laserPosition.position, Quaternion.identity);
        }
        else
        {
            Instantiate(fireball, laserPosition.position, Quaternion.Inverse(gameObject.transform.rotation));
        }
     
    }


}
