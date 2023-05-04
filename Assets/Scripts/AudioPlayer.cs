using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip shootingClip;
    [SerializeField] AudioClip explosionClip;

    public void PlayShootingClip()
    {
        AudioSource.PlayClipAtPoint(shootingClip, transform.position);
    }

    public void PlayExplosionClip()
    {
        AudioSource.PlayClipAtPoint(explosionClip, transform.position);
    }
}
