using UnityEngine;

[RequireComponent(typeof(Camera))]

public class CameraFollowsPlayer : MonoBehaviour
{
    Vector3 cameraPos;
    [SerializeField] Transform objectToFollow;
    [SerializeField] Vector3 cameraOffset;

    void Start()
    {
        cameraPos = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(objectToFollow.position.x + cameraOffset.x, cameraPos.y + cameraOffset.y, objectToFollow.position.z + cameraOffset.z);
    }
}
