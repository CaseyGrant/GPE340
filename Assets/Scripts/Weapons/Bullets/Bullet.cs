using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLifeTime;
    public Dummy dummy;
    public Pawn pawn;
    public Weapon pistol;
    public Weapon rifle;

    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        if (gameObject.name.Contains("Clone"))
        {
            yield return new WaitForSeconds(bulletLifeTime);

            Destroy(gameObject);
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(pawn.weapon == pistol)
            {
                collision.gameObject.GetComponent<Health>().Damage(pistol.bulletDamage);
            }
            else
            {
                collision.gameObject.GetComponent<Health>().Damage(rifle.bulletDamage);
            }
            
            Destroy(gameObject);
        }
        if ( collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().Damage(dummy.bulletDamage);
            Destroy(gameObject);
        }
    }
}
