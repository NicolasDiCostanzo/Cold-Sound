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

    [SerializeField] AudioSource playerSounds, soundsEffects, monsterAttack;

    [Range(0, 1)] [SerializeField] float minVolume;

    public void PlayDeathSound()
    {
        monsterAttack.clip = MonsterAttacksSounds[UnityEngine.Random.Range(0, MonsterAttacksSounds.Length)];
        Debug.Log(monsterAttack.clip.name);
        monsterAttack.volume = 1;
        monsterAttack.Play();
        Debug.Log("play death sound");
    }

    public void Play(SoundCategory nameCategory)
    {
        switch (nameCategory)
        {
            case SoundCategory.MonsterSounds:
                soundsEffects.clip = MonsterSounds[UnityEngine.Random.Range(0, MonsterSounds.Length)];
                DetermineVolume(nameCategory, soundsEffects);
                break;
            case SoundCategory.MonsterPrepareSounds:
                soundsEffects.clip = MonsterPrepareSounds[UnityEngine.Random.Range(0, MonsterPrepareSounds.Length)];
                DetermineVolume(nameCategory, soundsEffects);
                break;
            case SoundCategory.MonsterPassSounds:
                soundsEffects.clip = MonsterPassSounds[UnityEngine.Random.Range(0, MonsterPassSounds.Length)];
                DetermineVolume(nameCategory, soundsEffects);
                break;
            case SoundCategory.MonsterAttacksSounds:
                soundsEffects.clip = MonsterAttacksSounds[UnityEngine.Random.Range(0, MonsterAttacksSounds.Length)];
                DetermineVolume(nameCategory, soundsEffects);
                break;
            case SoundCategory.screams:
                soundsEffects.clip = screams[UnityEngine.Random.Range(0, screams.Length)];
                DetermineVolume(nameCategory, soundsEffects);
                break;
            case SoundCategory.ploufs:
                soundsEffects.clip = ploufs[UnityEngine.Random.Range(0, ploufs.Length)];
                DetermineVolume(nameCategory, soundsEffects);
                break;
            case SoundCategory.wallHit:
                playerSounds.clip = wallHit[UnityEngine.Random.Range(0, wallHit.Length)];
                DetermineVolume(nameCategory, playerSounds);
                break;
            case SoundCategory.skate:
                playerSounds.clip = skate[UnityEngine.Random.Range(0, skate.Length)];
                DetermineVolume(nameCategory, playerSounds);
                break;
            case SoundCategory.brake:
                playerSounds.clip = brake[UnityEngine.Random.Range(0, brake.Length)];
                DetermineVolume(nameCategory, playerSounds);
                break;
            case SoundCategory.keyColleted:
                playerSounds.clip = keyColleted[UnityEngine.Random.Range(0, keyColleted.Length)];
                DetermineVolume(nameCategory, playerSounds);
                break;
        }
    }

    void DetermineVolume(SoundCategory soundCategory, AudioSource source)
    {

        if (soundCategory == SoundCategory.wallHit || soundCategory == SoundCategory.brake)
        {
            source.volume = 0.5f;
        }
        else if (soundCategory == SoundCategory.skate)
        {
            source.volume = 0.1f;
        }
        else if (soundCategory == SoundCategory.keyColleted)
        {
            source.volume = 1;
        }
        else
        {
            if (MonsterBehavior.spawnProbability < minVolume) source.volume = minVolume;
            else source.volume = MonsterBehavior.spawnProbability;
        }

        source.Play();
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
