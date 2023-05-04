using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float firingRate = 0.2f;
    [SerializeField] float firingSpeed = 10f;
    [SerializeField] bool useAI;
    AudioPlayer audioPlayer;
    Coroutine firingCoroutine;
    public bool isFiring;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (audioPlayer)
            {
                audioPlayer.PlayShootingClip();
            }
            if (rb)
            {
                rb.velocity = transform.up * firingSpeed;
            }
            Destroy(instance, 2);

            float randomFiringRate = Random.Range(firingRate - 0.2f, firingRate + 0.2f);
            randomFiringRate = Mathf.Clamp(randomFiringRate, 0.2f, float.MaxValue);

            if (!useAI)
            {
                randomFiringRate = 0.2f;
            }

            yield return new WaitForSeconds(randomFiringRate);
        }
    }
}
