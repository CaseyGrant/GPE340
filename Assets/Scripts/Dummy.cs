using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dummy : Weapon
{
    public GameObject spawnPoint;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        spawnProjectile = GetComponent<SpawnProjectile>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (timer <= 0)
        {
            spawnProjectile.Shoot(bulletSpeed, spawnPoint, projectile);
            timer = firerate;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        
    }
}
