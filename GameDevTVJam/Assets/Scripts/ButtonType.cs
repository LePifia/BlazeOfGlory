using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum buttonType
{
    Jump,
    Attack,
    ASpeed,
    Multiplier,
    bullet,
}
public class ButtonType : MonoBehaviour
{
    [SerializeField] buttonType buttonType;
    [SerializeField] ParticleSystem explotion;
    public void OnClicker()
    {
        if (PlayerStatics.Instance.Experience > 0)
        {
            if (buttonType == buttonType.Jump)
            {
                PlayerStatics.Instance.AddJumpForce(50);
                PlayerStatics.Instance.RestExperience(1);
                ParticleSystem Instance = Instantiate(explotion, new Vector3(0, -4f, 0), Quaternion.identity);
                OnClick();
            }

            if (buttonType == buttonType.Attack)
            {
                PlayerStatics.Instance.AddDamage(1);
                PlayerStatics.Instance.RestExperience(1);
                ParticleSystem Instance = Instantiate(explotion, new Vector3(0, -4f, 0), Quaternion.identity);
                OnClick();
            }

            if (buttonType == buttonType.ASpeed)
            {
                PlayerStatics.Instance.Cooldown(0.1f);
                PlayerStatics.Instance.RestExperience(1);
                ParticleSystem Instance = Instantiate(explotion, new Vector3(0, -4f, 0), Quaternion.identity);
                OnClick();
            }

            if (buttonType == buttonType.Multiplier)
            {
                PlayerStatics.Instance.AddMultiplier(.1f);
                PlayerStatics.Instance.RestExperience(1);
                ParticleSystem Instance = Instantiate(explotion, new Vector3(0, -4f, 0), Quaternion.identity);
                OnClick();
            }

            if (buttonType == buttonType.bullet)
            {
                PlayerStatics.Instance.AddProjectileSpeed(1);
                PlayerStatics.Instance.RestExperience(1);
                ParticleSystem Instance = Instantiate(explotion, new Vector3(0, -4f, 0), Quaternion.identity);
                OnClick();
            }
        }
    }

    private void OnClick()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Buttons.Instance.buttons.Remove(gameObject);
    }

}
