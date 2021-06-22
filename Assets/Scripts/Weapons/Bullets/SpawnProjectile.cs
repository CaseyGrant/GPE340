using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public void Shoot(float bulletSpeed, GameObject spawnPoint, GameObject projectile)
    {
        GameObject Bullet = Instantiate(projectile, spawnPoint.transform.position, Quaternion.identity); // creates a bullet
        Bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * bulletSpeed); // makes the bullet move
    }
}
