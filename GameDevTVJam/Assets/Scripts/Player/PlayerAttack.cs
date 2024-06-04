using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayers;
    int damageDealt = 1;


    [SerializeField] float stateTimer;

     [SerializeField] float attackTimer;
    [SerializeField] float maxAttackTimer;


    private enum State
    {
        hit,
        Shoot,
        coolOff,
    }

    [SerializeField] State state;

    [Header("Events")]
    [Space]

    public UnityEvent OnAttackEvent;
    public UnityEvent Onfireball;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        damageDealt = PlayerStatics.Instance.damageDealt;
        if(attackTimer <0)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<PlayerStats>().TakeDamage(damageDealt);
            }

            state = State.hit;
            attackTimer = maxAttackTimer;
        }
            


    }

    private void Update()
    {
        maxAttackTimer = PlayerStatics.Instance.cooldown;

        stateTimer -= Time.deltaTime;
        attackTimer -= Time.deltaTime;

        switch (state)
        {
            case State.hit:
                break;
            case State.Shoot
            : break;
            case State.coolOff:
                break;

        }

        if (stateTimer <= 0f)
        {
            if (state == State.hit)
            {
                hitState();
                state = State.Shoot;
                
            }
            if (state == State.Shoot)
            {
                ShootState();
                state = State.coolOff;
            }
        }
    }

    private void hitState()
    {
        float shootingStateTime = 1f;
        OnAttackEvent.Invoke();
        stateTimer = shootingStateTime;
    }

    private void ShootState()
    {
        float coolOffStateTime = 1f;
        stateTimer = coolOffStateTime;
        Onfireball.Invoke();
        Debug.Log("Fireball");
    }
}
