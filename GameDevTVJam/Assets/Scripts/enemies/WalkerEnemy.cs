using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WalkerEnemy : MonoBehaviour
{
    [SerializeField]bool facingLeft = true;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] GameObject position1;
    [SerializeField] GameObject position2;

    private void Awake()
    {
        position1 = GameObject.FindGameObjectWithTag("positionWalker1");
        position2 = GameObject.FindGameObjectWithTag("positionWalker2");
    }

    void Start()
    {
        position1 = GameObject.FindGameObjectWithTag("positionWalker1");
        position2 = GameObject.FindGameObjectWithTag("positionWalker2");
        walkToPosition();
    }

    private void Flip()
    {
        spriteRenderer.flipX = facingLeft;
    }

    void walkToPosition()
    {     
        InvokeRepeating("Walking", 5f, PlayerStatics.Instance.enemySpeed);
    }

    void Walking()
    {
        Flip();
        facingLeft = !facingLeft;
        if (facingLeft) { gameObject.transform.DOLocalMoveX(position2.transform.position.x, PlayerStatics.Instance.enemySpeed);
            Debug.Log(facingLeft);
        }
        if (!facingLeft) { gameObject.transform.DOLocalMoveX(position1.transform.position.x, PlayerStatics.Instance.enemySpeed);
            Debug.Log(facingLeft);
        }
    }
}
