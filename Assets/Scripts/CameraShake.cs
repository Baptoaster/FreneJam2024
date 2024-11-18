using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform;
    public float shakeAmount = 3;
    public float shakeSpeed = 20;
    Vector3 originalPos;
    Vector3 newPos;

    void OnEnable()
    {
        originalPos = cameraTransform.position;
    }

    void Update()
    {
        newPos = cameraTransform.position;
        Shake();
    }

    public void Shake()
    {
        if (Vector3.Distance(newPos, cameraTransform.position) <= shakeAmount / 30) { newPos = originalPos + Random.insideUnitSphere * shakeAmount; }

        cameraTransform.position = Vector3.Lerp(cameraTransform.position, newPos, Time.deltaTime * shakeSpeed);
    }
}
