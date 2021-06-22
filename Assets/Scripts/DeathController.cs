using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public GameObject dummy;
    public GameObject player;

    public float respawnTime;

    public void Death()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(respawnTime);

        if (!dummy.activeInHierarchy)
        {
            dummy.SetActive(true);
            dummy.GetComponent<Health>().UpdateSlider();
        }
        if (!player.activeInHierarchy)
        {
            player.SetActive(true);
            player.GetComponent<Health>().UpdateSlider();
        }

    }
}



