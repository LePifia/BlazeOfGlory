using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance;

    [SerializeField] TextMeshProUGUI Jump;
    [SerializeField] TextMeshProUGUI Damage;
    [SerializeField] TextMeshProUGUI ProjectileSpeed;
    [SerializeField] TextMeshProUGUI Cooldown;
    [SerializeField] TextMeshProUGUI Multiplier;
    [SerializeField] TextMeshProUGUI Experience;
    [SerializeField] TextMeshProUGUI Score;

    private void Awake()
    {
        instance = this;
    }


    public void UpdateJump(float jump)
    {
        Jump.text = jump.ToString();
    }

    public void UpdateDamage(float damage)
    {
        Damage.text = damage.ToString();
    }

    public void UpdateProjectileSpeed(float damage)
    {
        ProjectileSpeed.text = damage.ToString();
    }

    public void UpdateCooldown(float cooldown)
    {
        Cooldown.text = cooldown.ToString();
    }

    public void UpdateMultiplier(float cooldown)
    {
        Multiplier.text = cooldown.ToString();
    }

    public void UpdateExperience(float cooldown)
    {
        Experience.text = cooldown.ToString();
    }

    public void UpdateScore(float cooldown)
    {
        Score.text = cooldown.ToString();
    }


}
