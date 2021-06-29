using UnityEngine;

public class MeltingLight : MonoBehaviour
{
    [SerializeField] float maxIntensity;
    public static float _maxIntensity;
    public static Light meltingLight;

    private void Start()
    {
        meltingLight = GetComponent<Light>();
        _maxIntensity = maxIntensity;
    }

    public static void ChangeLightIntensity(float a_meltValue, float a_maxMeltValue)
    {
        meltingLight.intensity = (a_meltValue / a_maxMeltValue) * _maxIntensity;
    }
}
