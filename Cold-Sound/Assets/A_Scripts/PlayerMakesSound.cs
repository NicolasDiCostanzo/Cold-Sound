using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMakesSound : MonoBehaviour
{
    AudioManager audioManager;
    WaitForSeconds wait = new WaitForSeconds(.5f);

    float playerPos;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerPos = transform.position.magnitude;

        StartCoroutine(MakeSoundRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MakeSoundRoutine()
    {
        float playerPosUpdate = transform.position.magnitude;

        while (Player_Movement_Law.isAlive)
        {
            yield return wait;


            if (Input.GetKey(KeyCode.Z))
            {
                audioManager.Play(AudioManager.SoundCategory.skate);
                MonsterBehavior.HearingSound_FromSkate();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                audioManager.Play(AudioManager.SoundCategory.brake);
                MonsterBehavior.HearingSound_FromBraking();
            }
            else if (Mathf.Abs(playerPosUpdate - playerPos) > 0.1f)
            {
                MonsterBehavior.HearingSound_FromGliding();
            }
        }
    }
}
