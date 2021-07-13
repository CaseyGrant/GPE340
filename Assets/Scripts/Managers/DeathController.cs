using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public GameObject player; // holds the player
    public List<GameObject> enemy;

    public float respawnTime; // sets how long it takes them to respawn

    public void Death()
    {
        StartCoroutine(Respawn()); // waits for respawn time
    }

    IEnumerator Respawn()
    {
        foreach (GameObject dummy in enemy)
        {
            yield return new WaitForSeconds(respawnTime); // after waiting

            if(dummy.GetComponent<Pawn>().dead == true)
            {   
                
                dummy.GetComponent<Health>().UpdateSlider(); // update the dummy's health
                dummy.GetComponent<Pawn>().dead = false;
                dummy.GetComponent<Ragdoll>().RagdollToggle();
            }
            
        }
    
        yield return new WaitForSeconds(respawnTime); // after waiting
        
        if (player.GetComponent<Pawn>().dead == true)
        {
            
            player.GetComponent<Health>().UpdateSlider(); // update the players health
            player.GetComponent<Pawn>().dead = false;
            player.GetComponent<Ragdoll>().RagdollToggle();
        }
        
    }
}



