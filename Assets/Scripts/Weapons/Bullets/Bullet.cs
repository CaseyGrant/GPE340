﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLifeTime; // how long before the bullet gets destroyed
    public Pawn pawn; // allows the use of the pawn's variables

    public GameObject spark;
    public GameObject electric;

    void Start()
    {
        StartCoroutine(Despawn()); // deletes the bullet after set time

        GameObject particles = Instantiate(spark, gameObject.transform);
        particles.GetComponent<ParticleSystem>().Play();
    }

    IEnumerator Despawn()
    {
        if (gameObject.name.Contains("Clone")) // checks if its a clone
        {
            yield return new WaitForSeconds(bulletLifeTime); // waits until bullet life is over

            Destroy(gameObject); // destroys the bullet
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameObject particles = Instantiate(electric, gameObject.transform.position, Quaternion.identity); // spawns a particle
        particles.GetComponent<ParticleSystem>().Play(); // activates the particle

        if (collision.gameObject.CompareTag("Enemy")) // if the bullet hits the enemy
        {
            if(pawn.weapon == pawn.pistol) // if the player is using the pistol
            {
                collision.gameObject.GetComponent<Health>().Damage(pawn.pistol.bulletDamage); // deal the pistols damage
            }
            else
            {
                collision.gameObject.GetComponent<Health>().Damage(pawn.rifle.bulletDamage); // deal the rifles damage
            }
            
            Destroy(gameObject); // destroy the bullet
        }
        if ( collision.gameObject.CompareTag("Player")) // if the bullet hits the player
        {
            collision.gameObject.GetComponent<Health>().Damage(pawn.weapon.bulletDamage); // deal the dummy's damage
            Destroy(gameObject); // deatroy the bullet
        }
    }
}
