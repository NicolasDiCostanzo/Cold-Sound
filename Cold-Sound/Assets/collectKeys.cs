using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectKeys : MonoBehaviour
{
    private GameManager GM;
    private KeysPanel_UI KP_UI;
    Light light;
    AudioManager audio;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        audio = FindObjectOfType<AudioManager>();
        KP_UI = FindObjectOfType<KeysPanel_UI>();
        light = GetComponentInChildren<Light>();
        light.color = new Color32(System.Convert.ToByte(Random.Range(0, 255)), System.Convert.ToByte(Random.Range(0, 255)), System.Convert.ToByte(Random.Range(0, 255)), 255);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Personnage")
        {
            GM.nbKeys++;
            KP_UI.AddKeyUI();
            audio.Play(AudioManager.SoundCategory.keyColleted);
            MonsterBehavior.HearingSound_FromKey();
            Destroy(gameObject);
        }
    }
}
