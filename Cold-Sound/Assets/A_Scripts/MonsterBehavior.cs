using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    static private float WALL_SOUND_PROBA = .10f;
    static private float SKATE_SOUND_PROBA = .01f;
    static private float BRAKE_SOUND_PROBA = .15f;
    static private float GLIDING_SOUND_PROBA = .05f;
    static private float KEY_SOUND_PROBA = .20f;
    static private float HEARING_PROBABILITY = .30f;

    static private float MODIF_PROBA_AFTER_STOP_ALERTED = .75f;
    static private float NB_SECONDES_MONSTER_ALERTED = 2f;

    private float spawnProbability;
    private float probability_valueChanged;
    private bool isAlerted;

    public GameObject monster_Prefab;
    private GameObject monster_GO;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        spawnProbability = 0f;
        probability_valueChanged = spawnProbability;

        isAlerted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnProbability != probability_valueChanged)
        {
            TryPlaySoundMonster();

            probability_valueChanged = spawnProbability;
        }
    }

    IEnumerator MonsterIsAlerted()
    {
        Debug.Log("Monster is alerted");
        isAlerted = true;

        float valueAlerted = spawnProbability;

        yield return new WaitForSeconds(NB_SECONDES_MONSTER_ALERTED);

        if(valueAlerted != spawnProbability)
        {
            TrySpawnMonster();
        }
        spawnProbability *= MODIF_PROBA_AFTER_STOP_ALERTED;
        probability_valueChanged = spawnProbability;

        isAlerted = false;
        Debug.Log("Monster is not alerted");
    }
    public void TrySpawnMonster()
    {
        if(Random.Range(0, 1f) < spawnProbability)
        {
            Debug.Log("Monster Spawns");

            StartCoroutine(MonsterAttackSounds());

            monster_GO = Instantiate(monster_Prefab);
        }
    }
    
    IEnumerator MonsterAttackSounds()
    {
        audioManager.Play(AudioManager.SoundCategory.MonsterPrepareSounds);
        yield return new WaitForSeconds(0.5f);
        audioManager.Play(AudioManager.SoundCategory.MonsterAttacksSounds);
    }

    private void TryPlaySoundMonster()
    {
        if (Random.Range(0, 1f) < spawnProbability)
        {
            Debug.Log("Monster makes Sound");
            if(spawnProbability < .3f)
                audioManager.Play(AudioManager.SoundCategory.MonsterPassSounds);
            else
                audioManager.Play(AudioManager.SoundCategory.MonsterSounds);
            
            if (!isAlerted)
                StartCoroutine(MonsterIsAlerted());

        }
    }

    public void HearingSound_FromWall()
    {
        if(Random.Range(0, 1f) < HEARING_PROBABILITY + spawnProbability)
        {
            Debug.Log("Hearing sound from wall");
            spawnProbability += WALL_SOUND_PROBA;
        }   
    }

    public void HearingSound_FromSkate()
    {
        if (Random.Range(0, 1f) < HEARING_PROBABILITY + spawnProbability)
        {
            Debug.Log("Hearing sound from Skate");
            spawnProbability += SKATE_SOUND_PROBA;
        }
    }
    
    public void HearingSound_FromGliding()
    {
        if (Random.Range(0, 1f) < HEARING_PROBABILITY + spawnProbability)
        {
            Debug.Log("Hearing sound from glide");
            spawnProbability += GLIDING_SOUND_PROBA;
        }
    }
    public void HearingSound_FromBraking()
    {
        if (Random.Range(0, 1f) < HEARING_PROBABILITY + spawnProbability)
        {
            Debug.Log("Hearing sound from glide");
            spawnProbability += BRAKE_SOUND_PROBA;
        }
    }

    public void HearingSound_FromKey()
    {
        if (Random.Range(0, 1f) < HEARING_PROBABILITY + spawnProbability)
        {
            Debug.Log("Hearing sound from key");
            spawnProbability += KEY_SOUND_PROBA;
        }
    }
}
