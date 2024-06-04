using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum damageType
{
    enemy,
    player
}
public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 1;
    int enemyDamage = 1;

    [SerializeField] damageType type;


    private void Update()
    {
       
        damage = PlayerStatics.Instance.damageDealt;
    }

    public int GetDamage()
    {
        if (type == damageType.enemy)
        {
            return enemyDamage;
        }
        else
        {
            return damage;
        }
    }
        

    public void Hit()
    {
        
        //gameObject.SetActive(false);
    }

    public damageType GetDamageType() { return type; }
}
