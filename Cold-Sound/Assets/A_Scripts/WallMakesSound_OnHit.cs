using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMakesSound_OnHit : MonoBehaviour
{
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            MonsterBehavior.HearingSound_FromWall();

            // Wall makes sound
            audioManager.Play(AudioManager.SoundCategory.wallHit);
        }
    }
}
