using UnityEngine;

public class MeltingEffect : MonoBehaviour
{
    void OnTriggerEnter(Collider collider) { ToggleIceMelting(collider.transform, true); }

    void OnTriggerExit(Collider collider) { 
        ToggleIceMelting(collider.transform, false);
        MeltingLight.meltingLight.intensity = 0;
    }

    void ToggleIceMelting(Transform collision, bool a_playerCollides)
    {
        if (collision.GetComponent<IceBlock>()) collision.GetComponent<IceBlock>().playerIsOn = a_playerCollides;
    }
}
