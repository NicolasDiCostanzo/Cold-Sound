using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	[SerializeField] Transform camTransform;

	// How long the object should shake for.
	[SerializeField] float shakeDuration, shakeAmount;
	float shakeDuration_mem;

	Vector3 originalPos;

	void Start()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		originalPos = camTransform.localPosition;
		shakeDuration_mem = shakeDuration;
	}

	void Update()
	{
		if (shakeDuration_mem > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration_mem -= Time.deltaTime;
		}
		else
		{
			shakeDuration_mem = 0;
			camTransform.localPosition = originalPos;
			enabled = false;
		}
	}
}