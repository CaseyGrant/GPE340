using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source; // what plays the sounds
    public AudioSource pistolReloadSource;
    public AudioSource rifleReloadSource;

    public AudioClip heal; // what to play when healing
    public AudioClip shoot; // what to play when shooting

    public void HealSound()
    {
        source.PlayOneShot(heal); // plays sound
    }

    public void Shoot()
    {
        source.PlayOneShot(shoot); // plays sound
    }

    public void PistolReload()
    {
        pistolReloadSource.Play(); // plays sound
    }

    public void RifleReload()
    {
        rifleReloadSource.Play(); // plays sound
    }
}
