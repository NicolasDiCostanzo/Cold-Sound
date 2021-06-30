using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] MonsterSounds;
    [SerializeField] AudioClip[] MonsterPrepareSounds;
    [SerializeField] AudioClip[] MonsterPassSounds;
    [SerializeField] AudioClip[] MonsterAttacksSounds;
    [SerializeField] AudioClip[] atmospheres;
    [SerializeField] AudioClip[] screams;
    [SerializeField] AudioClip[] ploufs;

    [SerializeField] AudioClip[] wallHit;
    [SerializeField] AudioClip[] skate;
    [SerializeField] AudioClip[] brake;
    [SerializeField] AudioClip[] keyColleted;

    public AudioSource source = null;

    void Start()
    {
        PlayAtmosphereSounds();
    }


    public void Play(SoundCategory nameCategory)
    {
        if (source == null)
            source = FindObjectOfType<AudioSource>();

        

        Debug.Log("Monster spawn probability: " + MonsterBehavior.spawnProbability);

        switch (nameCategory)
        {
            case SoundCategory.MonsterSounds:
                source.volume = 1;
                //source.volume = MonsterBehavior.spawnProbability;
                source.clip = MonsterSounds[UnityEngine.Random.Range(0, MonsterSounds.Length)];
                break;
            case SoundCategory.MonsterPrepareSounds:
                source.volume = 1;
                //source.volume = MonsterBehavior.spawnProbability;
                source.clip = MonsterPrepareSounds[UnityEngine.Random.Range(0, MonsterPrepareSounds.Length)];
                break;
            case SoundCategory.MonsterPassSounds:
                source.volume = 1;
                //source.volume = MonsterBehavior.spawnProbability;
                source.clip = MonsterPassSounds[UnityEngine.Random.Range(0, MonsterPassSounds.Length)];
                break;
            case SoundCategory.MonsterAttacksSounds:
                source.volume = 1;
                //source.volume = MonsterBehavior.spawnProbability;
                source.clip = MonsterAttacksSounds[UnityEngine.Random.Range(0, MonsterAttacksSounds.Length)];
                break;
            case SoundCategory.atmospheres:
                PlayAtmosphereSounds();
                break;
            case SoundCategory.screams:
                source.volume = 1;
                source.clip = screams[UnityEngine.Random.Range(0, screams.Length)];
                break;
            case SoundCategory.ploufs:
                source.volume = 1;
                source.clip = ploufs[UnityEngine.Random.Range(0, ploufs.Length)];
                break;
            case SoundCategory.wallHit:
                source.volume = 1;
                source.clip = wallHit[UnityEngine.Random.Range(0, wallHit.Length)];
                break;
            case SoundCategory.skate:
                source.volume = 0.3f;
                source.clip = skate[UnityEngine.Random.Range(0, skate.Length)];
                break;
            case SoundCategory.brake:
                source.volume = 1;
                source.clip = brake[UnityEngine.Random.Range(0, brake.Length)];
                break;
            case SoundCategory.keyColleted:
                source.volume = 1;
                source.clip = keyColleted[UnityEngine.Random.Range(0, keyColleted.Length)];
                break;

        }

        source.Play();
    }

    void PlayAtmosphereSounds()
    {
        foreach (AudioClip clip in atmospheres)
        {
            AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
            newAudioSource.clip = clip;
            newAudioSource.Play();
        }
    }

    public enum SoundCategory
    {
        MonsterSounds,
        MonsterPrepareSounds,
        MonsterPassSounds,
        MonsterAttacksSounds,
        atmospheres,
        screams,
        ploufs,
        wallHit,
        skate,
        brake,
        keyColleted
    }
}
