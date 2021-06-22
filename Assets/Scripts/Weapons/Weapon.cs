using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public Transform rightHandPoint; // where to put the right hand
    public Transform leftHandPoint; // where to put the left hand

    public UnityEvent Reload; // user designed reload
    public UnityEvent Fire; // user designed shoot
    public UnityEvent ResetFire; // user designed timer reset

    public int bulletDamage; // how much damage the weapon does
    public float bulletSpeed; // how fast the bullet goes
    public float firerate; // how often the gun can shoot
    public float timer; // when the gun can shoot

    public int magazineSize; // max ammo
    public int currentAmmo; // current ammo

    private bool reloading; // is the gun reloading
    public bool canShoot = true; // stops you from shooting while reloading

    public SpawnProjectile spawnProjectile; // allows shooting
    public Pawn pawn; // allows access to pawn variables

    public virtual void Update()
    {
        if (!GameManager.Instance.GetComponent<AudioManager>().source.isPlaying) // if the audio manager is not playing
        {
            reloading = false; // no longer reloading
        }
        if (currentAmmo <= 0) // if out of ammo
        {
            canShoot = false; // disable shooting
        }
    }

    public void AutoFire()
    {
        if (reloading == false && canShoot == true) // if not reloading and not out of ammo
        {
            if (timer <= 0) // when the timer ends
            {
                spawnProjectile.Shoot(bulletSpeed, pawn.rifleBulletSpawn, pawn.bullet); // shoot
                timer = firerate; // reset timer
                currentAmmo -= 1; // decrease ammo
            }
            else
            {
                timer -= Time.deltaTime; // tick down timer
            }
        }
    }

    public  void SingleFire()
    {
        if (reloading == false && canShoot == true) // if not reloading and not out of ammo
        {
            spawnProjectile.Shoot(bulletSpeed, pawn.pistolBulletSpawn, pawn.bullet); // shoot
            currentAmmo -= 1; // decrease ammo
        }
    }

    public void EndFire()
    {
        timer = firerate; // resets timer
    }

    public void ReloadPistol()
    {
        GameManager.Instance.GetComponent<AudioManager>().PistolReload(); // plays pistol reload
        reloading = true; // is reloading
        currentAmmo = magazineSize; // refills magazine
        canShoot = true; // re-enables shooting
    }

    public void ReloadRifle()
    {
        GameManager.Instance.GetComponent<AudioManager>().RifleReload(); // plays rifle reload
        reloading = true; // is reloading
        currentAmmo = magazineSize; // refills magazine
        canShoot = true; // re-enables shooting
    }

    public void ShootAudio()
    {
        if (reloading == false && canShoot == true) // if not reloading and not out of ammo
        {
            if (timer == firerate) // after shooting
            {
                GameManager.Instance.GetComponent<AudioManager>().Shoot(); // play shoot
            }
        }
    }
}
