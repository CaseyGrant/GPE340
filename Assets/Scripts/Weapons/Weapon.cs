using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public Transform rightHandPoint;
    public Transform leftHandPoint;

    public UnityEvent Reload;
    public UnityEvent Fire;
    public UnityEvent ResetFire;

    public int bulletDamage;
    public float bulletSpeed;
    public float firerate;
    public float timer;

    public int magazineSize;
    public int currentAmmo;

    private bool reloading;
    public bool canShoot = true;

    public SpawnProjectile spawnProjectile;
    public Pawn pawn;

    public virtual void Update()
    {
        if (!GameManager.Instance.GetComponent<AudioManager>().source.isPlaying)
        {
            reloading = false;
            currentAmmo = magazineSize;
            canShoot = true;
        }
        if (currentAmmo <= 0)
        {
            canShoot = false;
        }
    }

    public void AutoFire()
    {
        if (reloading == false && canShoot == true)
        {
            if (timer <= 0)
            {
                spawnProjectile.Shoot(bulletSpeed, pawn.rifleBulletSpawn, pawn.bullet);
                timer = firerate;
                currentAmmo -= 1;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        

    }

    public  void SingleFire()
    {
        if (reloading == false && canShoot == true)
        {
            spawnProjectile.Shoot(bulletSpeed, pawn.pistolBulletSpawn, pawn.bullet);
            currentAmmo -= 1;
        }
        
    }

    public void EndFire()
    {
        timer = firerate;
    }

    public void ReloadPistol()
    {
        GameManager.Instance.GetComponent<AudioManager>().PistolReload();
        reloading = true;
    }

    public void ReloadRifle()
    {
        GameManager.Instance.GetComponent<AudioManager>().RifleReload();
        reloading = true;
    }

    public void ShootAudio()
    {
        if (reloading == false && canShoot == true)
        {
            if (timer == firerate)
            {
                GameManager.Instance.GetComponent<AudioManager>().Shoot();
            }
        }
        
    }
}
