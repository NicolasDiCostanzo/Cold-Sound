using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMakesSound_OnHit : MonoBehaviour
{
    AudioManager audioManager;
    //CameraShake cameraShake;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        //cameraShake = Camera.main.GetComponent<CameraShake>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            MonsterBehavior.HearingSound_FromWall();

            // Wall makes sound
            audioManager.Play(AudioManager.SoundCategory.wallHit);
            //cameraShake.enabled = true;
        }
    }
}
