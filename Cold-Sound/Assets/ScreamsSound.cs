using UnityEngine;

public class ScreamsSound : MonoBehaviour
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
        if (MonsterBehavior.spawnProbability >= 0) ManageScreamSound();
        if (timeBetweenScreams >= 0) timeBetweenScreams -= Time.deltaTime;

    }

    void ManageScreamSound()
    {
        if (timeBetweenScreams <= 0) ScreamSound();
    }

    float NewTimeBetweenTwoScreams()
    {
        return Random.Range(secondsBetweensScreams_lowLimit, secondsBetweensScreams_highLimit);
    }

    void ScreamSound()
    {
        audioManager.Play(AudioManager.SoundCategory.screams);
        timeBetweenScreams = NewTimeBetweenTwoScreams();
        Debug.Log(timeBetweenScreams);

    }


}
