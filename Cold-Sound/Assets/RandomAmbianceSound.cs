using System;
using UnityEngine;

public class RandomAmbianceSound : MonoBehaviour
{
    [SerializeField] [Range(0, 90f)] float secondsBetweensScreams_lowLimit;
    [SerializeField] [Range(0, 90f)] float secondsBetweensScreams_highLimit;

    float timeBetweenScreams = 0, timeUntilNextScream;

    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        if (!audioManager)
        {
            Debug.LogError("Audio manager pas trouvé");
            enabled = false;
        }
    }

    void Update()
    {
        if (MonsterBehavior.spawnProbability >= 0) ManageSound();
        if (timeBetweenScreams >= 0) timeBetweenScreams -= Time.deltaTime;

    }

    void ManageSound()
    {
        if (timeBetweenScreams <= 0) DetermineRandomSound();
    }

    float NewTimeBetweenTwoSounds()
    {
        return UnityEngine.Random.Range(secondsBetweensScreams_lowLimit, secondsBetweensScreams_highLimit);
    }

    void DetermineRandomSound()
    {
        int nbEnumValues = Enum.GetValues(typeof(AudioManager.SoundCategory)).Length;

        AudioManager.SoundCategory soundTypeToPlay;
        do
        {

            int typeOfSoundToPlay = UnityEngine.Random.Range(0, nbEnumValues);
            soundTypeToPlay = (AudioManager.SoundCategory)typeOfSoundToPlay;

        } while (
            soundTypeToPlay == AudioManager.SoundCategory.atmospheres ||
            soundTypeToPlay == AudioManager.SoundCategory.wallHit ||
            soundTypeToPlay == AudioManager.SoundCategory.skate ||
            soundTypeToPlay == AudioManager.SoundCategory.brake ||
            soundTypeToPlay == AudioManager.SoundCategory.keyColleted
        );

        Debug.Log("play : " + soundTypeToPlay);


        audioManager.Play(soundTypeToPlay);
        timeBetweenScreams = NewTimeBetweenTwoSounds();
    }


}
