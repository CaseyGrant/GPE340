using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public GameObject player; // holds the player
    public List<GameObject> enemy;

    public float resetRagdollTime; // sets how long it takes them to respawn

    public EnemySpawner enemySpawner;

    public void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>(); // finds the enemy spawner
    }

    public void Death()
    {
        StartCoroutine(ResetRagdoll()); // waits
    }

    IEnumerator ResetRagdoll()
    {
        if (player.GetComponent<Pawn>().dead == true) // if the player is dead
        {
            yield return new WaitForSeconds(resetRagdollTime); // after waiting
            player.GetComponent<Health>().lives--; // takes down the players lives
            player.GetComponent<Health>().UpdateSlider(); // update the players health
            player.GetComponent<Ragdoll>().RagdollToggle(); // stop ragdolling
            player.GetComponent<Pawn>().dead = false; // reset dead
        }

        foreach (GameObject dummy in enemy) //for all of the enemies
        {
            
            if (dummy != null)
            {
                if(dummy.GetComponent<Pawn>().dead == true) // if the enemy is dead
                {
                    yield return new WaitForSeconds(resetRagdollTime); // after waiting
                    enemy.Remove(dummy); // takes the dead enemy out of the list
                    dummy.GetComponent<Health>().UpdateSlider(); // update the dummy's health
                    dummy.GetComponent<Pawn>().dead = false; // reset dead
                    dummy.GetComponent<Ragdoll>().RagdollToggle(); // stop ragdolling
                    enemySpawner.currentEnemyCount--; // takes the dead enemy out of the list
                    dummy.GetComponent<Health>().lives--; // decreases the enemys lives
                }
            }
        }
    }
}



