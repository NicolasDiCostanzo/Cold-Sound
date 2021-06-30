using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessScript : MonoBehaviour
{
    // Start is called before the first frame update

    float intensityOfMonster;
    PostProcessVolume postVolume;
    Vignette vignette;


    void Start()
    {
        intensityOfMonster = MonsterBehavior.riskOfDying;
        postVolume = GetComponent<PostProcessVolume>();
        postVolume.profile.TryGetSettings(out vignette);
        vignette.intensity.value = intensityOfMonster;
    }

    // Update is called once per frame
    void Update()
    {
        intensityOfMonster = MonsterBehavior.riskOfDying;
        vignette.intensity.value = intensityOfMonster;
    }
}
