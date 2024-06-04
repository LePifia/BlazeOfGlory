using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public enum statType
{
    enemy,
    player,
    fireball,
}

public class PlayerStats : MonoBehaviour
{
    public event EventHandler OnDieEvent;
    [SerializeField] statType statType;
    [SerializeField] int health = 5;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float scoreGiven = 0;

    [SerializeField]bool player;
    [SerializeField] bool damageblae = true;

    [SerializeField] ParticleSystem explotion;

    float timer;

    [Header("Events")]
    [Space]

    public UnityEvent OnHitEvent;


    private void Start()
    {
        if(statType == statType.enemy)
        {
            health = PlayerStatics.Instance.health;
        }
    }
    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            damageblae = true;
        }
        if (health <= 0)
        {
            DIE();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
            if (timer <= 0 && statType == statType.player)
            {
             
                DamageDealer damageDealer = other.GetComponent<DamageDealer>();

                if (damageDealer != null)
                {
                    TakeDamage(damageDealer.GetDamage());
                }

                timer = 5;
            }
            else
            {
                DamageDealer damageDealer = other.GetComponent<DamageDealer>();

                if (damageDealer != null)
                {
                    TakeDamage(damageDealer.GetDamage());
                }
            }
        
       
   
        
    }
    public void TakeDamage (int Damage)
    {
        OnHitEvent.Invoke();

        if (damageblae)
        {
            damageblae = false;
            health -= Damage;
        }
        

        if (health > 0)
        {
            StartCoroutine(DamageFlash());
        }
        

        if (health <= 0)
        {
            DIE();
        }
    }

    public void DIE()
    {
        if (statType == statType.enemy)
        {
            
            Destroy(gameObject);
        }
        if (statType == statType.player)
        {
            OnDieEvent?.Invoke(this, EventArgs.Empty);
            AudioManager.Instance.CasualExplosion();
            ParticleSystem Instance = Instantiate(explotion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            
        }
        if (statType == statType.fireball)
        {
            Destroy(gameObject);
        }
        
    }

    public int GetHealth()
    {
        return health;
    }

    IEnumerator DamageFlash()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.05f);

        spriteRenderer.color = Color.white;
    }

    private void OnDestroy()
    {
        if (statType == statType.enemy)
        {
            AudioManager.Instance.CasualExplosion();
            PlayerStatics.Instance.AddScore(scoreGiven * PlayerStatics.Instance.Multiplier);
            PlayerStatics.Instance.AddExperience(1);
            ParticleSystem Instance = Instantiate(explotion, transform.position, Quaternion.identity);
        }

        if (statType == statType.fireball)
        {
            AudioManager.Instance.PlayerExplosion();
            ParticleSystem Instance = Instantiate(explotion, transform.position, Quaternion.identity);
        }
            
    }

    public statType getStatType()
    {
        return gameObject.GetComponent<statType>();
    }

    

}
