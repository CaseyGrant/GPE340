using UnityEngine;

public class Dummy : Weapon
{
    public GameObject spawnPoint; // where to spawn bullets
    public GameObject projectile; // the bullet to spawn

    public override void Update()
    {
        if (timer <= 0) // when the timer ends
        {
            spawnProjectile.Shoot(bulletSpeed, spawnPoint, projectile); // shoot
            timer = firerate; // reset timer
        }
        else
        {
            timer -= Time.deltaTime; // tick down timer
        }
    }
}
