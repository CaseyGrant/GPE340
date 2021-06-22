using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source; // what plays the sounds

    public AudioClip heal; // what to play when healing
    public AudioClip shoot; // what to play when shooting
    public AudioClip pistolReload; // what to play when reloading the pistol
    public AudioClip rifleReload; // what to play when reloading the rifle

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
        source.PlayOneShot(pistolReload); // plays sound
    }

    public void RifleReload()
    {
        source.PlayOneShot(rifleReload); // plays sound
    }
}
