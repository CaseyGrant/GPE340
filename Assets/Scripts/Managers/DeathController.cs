using System.Collections;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public GameObject dummy; // holds the target dummy
    public GameObject player; // holds the player

    public float respawnTime; // sets how long it takes them to respawn

    public void Death()
    {
        StartCoroutine(Respawn()); // waits for respawn time
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime); // after waiting

        if (!dummy.activeInHierarchy) // if the dummy is not active
        {
            dummy.SetActive(true); // make the dummy active
            dummy.GetComponent<Health>().UpdateSlider(); // update the dummy's health
        }
        if (!player.activeInHierarchy) // if the player is not active
        {
            player.SetActive(true); // make the payer active
            player.GetComponent<Health>().UpdateSlider(); // update the players health
        }
    }
}



