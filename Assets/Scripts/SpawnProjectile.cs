using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public GameObject Projectile; // holds the projectile

    public void Shoot(float BulletSpeed)
    {
        GameObject Bullet = Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity); // creates a bullet
        Bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * BulletSpeed); // makes the bullet move
    }
}
