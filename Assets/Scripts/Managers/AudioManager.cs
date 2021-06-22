using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;

    public AudioClip heal;
    public AudioClip shoot;
    public AudioClip pistolReload;
    public AudioClip rifleReload;

    public void HealSound()
    {
        source.PlayOneShot(heal);
    }

    public void Shoot()
    {
        source.PlayOneShot(shoot);
    }

    public void PistolReload()
    {
        source.PlayOneShot(pistolReload);
    }

    public void RifleReload()
    {
        source.PlayOneShot(rifleReload);
    }
}
