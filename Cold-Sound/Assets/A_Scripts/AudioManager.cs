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

    public AudioSource source = null;

    void Start()
    {
        PlayAtmosphereSounds();
    }


    public void Play(SoundCategory nameCategory)
    {
        if (source == null)
            source = FindObjectOfType<AudioSource>();

        source.volume = MonsterBehavior.spawnProbability;

        Debug.Log("Monster spawn probability: " + MonsterBehavior.spawnProbability);

        switch (nameCategory)
        {
            case SoundCategory.MonsterSounds:
                source.clip = MonsterSounds[UnityEngine.Random.Range(0, MonsterSounds.Length)];
                break;
            case SoundCategory.MonsterPrepareSounds:
                source.clip = MonsterPrepareSounds[UnityEngine.Random.Range(0, MonsterPrepareSounds.Length)];
                break;
            case SoundCategory.MonsterPassSounds:
                source.clip = MonsterPassSounds[UnityEngine.Random.Range(0, MonsterPassSounds.Length)];
                break;
            case SoundCategory.MonsterAttacksSounds:
                source.clip = MonsterAttacksSounds[UnityEngine.Random.Range(0, MonsterAttacksSounds.Length)];
                break;
            case SoundCategory.atmospheres:
                PlayAtmosphereSounds();
                break;
            case SoundCategory.screams:
                source.clip = screams[UnityEngine.Random.Range(0, screams.Length)];
                break;
            case SoundCategory.ploufs:
                source.clip = ploufs[UnityEngine.Random.Range(0, ploufs.Length)];
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
        ploufs
    }
}
