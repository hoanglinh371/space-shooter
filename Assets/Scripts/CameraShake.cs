using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float duration = 0.5f;
    [SerializeField] float magnitude = 0.25f;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * magnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }
}
