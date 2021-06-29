using UnityEngine;

public class IceBlock : MonoBehaviour
{
    [Tooltip("Valeur que doit atteindre le block pour être complètement fondu, donc détruit.")]
    public float maxMeltValue;

    [HideInInspector] public float meltValue = 0;
    [HideInInspector] public bool playerIsOn = false;

    Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (playerIsOn)
        {
            Melting();
        }
        else
        {
            if (meltValue > 0) Freezing();
        }
    }

    void Freezing()
    {
        meltValue -= Time.deltaTime;

        if (meltValue <= 0) meltValue = 0;

        ChangeShaderTransparency(meltValue);
    }

    void Melting()
    {
        meltValue += Time.deltaTime;
        ChangeShaderTransparency(meltValue);

        MeltingLight.ChangeLightIntensity(meltValue, maxMeltValue);

        if (meltValue >= maxMeltValue) DestroyBlock();
    }

    void ChangeShaderTransparency(float a_meltValue)
    {
        a_meltValue = (1 / a_meltValue) * .4f;

        if (a_meltValue > 1)      a_meltValue = 1;
        else if (a_meltValue < 0) a_meltValue = 0;

        material.SetFloat("_Transparency", a_meltValue);

    }

    void DestroyBlock()
    {
        meltValue = 0;
        MeltingLight.meltingLight.intensity = 0;
        Destroy(gameObject);
    }
}
