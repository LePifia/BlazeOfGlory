using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] AudioClip fireballSpawn;
    [SerializeField][Range(0f, 1f)] float shootingVolume = 1f;

    
    [SerializeField] AudioClip [] deadMoment;
    [SerializeField][Range(0f, 1f)] float casualExplosionVolume;

    
    [SerializeField] AudioClip [] jumps;
    [SerializeField][Range(0f, 1f)] float explosionVolume;

    [SerializeField] AudioClip[] fireballExplode;
    [SerializeField][Range(0f, 1f)] float fireballExplodeVolume;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void PlayShootingClip()
    {
        PlayClip(fireballSpawn, shootingVolume);
    }

    public void CasualExplosion()
    {
        PlayClip(deadMoment[UnityEngine.Random.Range(0, deadMoment.Length)], casualExplosionVolume);
    }

    public void PlayerExplosion()
    {
        PlayClip(fireballExplode[UnityEngine.Random.Range(0, fireballExplode.Length)], casualExplosionVolume);

    }

    public void Jump()
    {
        PlayClip(jumps[UnityEngine.Random.Range(0, jumps.Length)], casualExplosionVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
    }
}
