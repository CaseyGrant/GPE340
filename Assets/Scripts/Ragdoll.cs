using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private Animator anim;
    private Pawn pawn;
    private Collider mainCollider;
    private Rigidbody mainRigidbody;
    private List<Collider> ragdollColliders;
    private List<Rigidbody> ragdollRigidbodies;
    private PlayerController playerController;
    private AIController aiController;
    private CameraController cameraController;
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // gets the animator
        pawn = GetComponent<Pawn>(); // gets the pawn
        mainCollider = GetComponent<Collider>(); // gets the main collider
        mainRigidbody = GetComponent<Rigidbody>(); // gets the main rigidbody

        ragdollColliders = new List<Collider>(GetComponentsInChildren<Collider>()); // gets the ragdoll colliders
        ragdollRigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>()); // gets the ragdoll rigidbodies

        ragdollColliders.Remove(mainCollider); // removes the main collider from the list of ragdoll colliders
        ragdollRigidbodies.Remove(mainRigidbody); // removes the main rigidbody from the list of ragdoll rigidbodies

        if (tag.Contains("Player")) // if its the player
        {
            playerController = GetComponent<PlayerController>(); // gets the player controller
            cameraController = FindObjectOfType<CameraController>(); // gets the camera controller
        }
        else // if its the enemy
        {
            aiController = GetComponent<AIController>(); // gets the ai controller
        }
            
        health = GetComponent<Health>(); // gets the health
        StopRagdoll(); // makes the pawns start not ragdolled
    }

    // Update is called once per frame
    void Update()
    {
        if(health.health.value <= 0) // if dead
        {
            RagdollToggle(); // ragdoll
            health.health.value = 1; // stop infinite loop
            pawn.dead = true; // set dead
        }
    }

    public void RagdollToggle()
    {
        foreach(Collider currentCollider in ragdollColliders) // for all of the colliders
        {
            currentCollider.enabled = !currentCollider.enabled; // swap between enabled and disabled
        }
        foreach (Rigidbody currentRigidbody in ragdollRigidbodies) // for all of the rigidbodies
        {
            currentRigidbody.isKinematic = !currentRigidbody.isKinematic; // swap between enabled and disabled
        }

        anim.enabled = !anim.enabled; // swap between enabled and disabled
        mainCollider.enabled = !mainCollider.enabled; // swap between enabled and disabled
        mainRigidbody.isKinematic = !mainRigidbody.isKinematic; // swap between enabled and disabled
        if (tag.Contains("Player")) // if its the player
        {
            playerController.enabled = !playerController.enabled; // swap between enabled and disabled
            cameraController.enabled = !cameraController.enabled; // swap between enabled and disabled
        }
        else // if its the enemy
        {
            aiController.enabled = !aiController.enabled; // swap between enabled and disabled
        }
    }

    public void StopRagdoll()
    {
        foreach (Collider currentCollider in ragdollColliders) // for all of the colliders
        {
            currentCollider.enabled = false; // disable colliders
        }
        foreach (Rigidbody currentRigidbody in ragdollRigidbodies) // for all of the rigidbodies
        {
            currentRigidbody.isKinematic = true; // disable rigidbodies
        }

        anim.enabled = true; // enable animator
        mainCollider.enabled = true; // enable main collider
        mainRigidbody.isKinematic = false; // enable main rigidbody
    }
}
