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
        anim = GetComponent<Animator>();
        pawn = GetComponent<Pawn>();
        mainCollider = GetComponent<Collider>();
        mainRigidbody = GetComponent<Rigidbody>();

        ragdollColliders = new List<Collider>(GetComponentsInChildren<Collider>());
        ragdollRigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());

        ragdollColliders.Remove(mainCollider);
        ragdollRigidbodies.Remove(mainRigidbody);

        if (tag.Contains("Player"))
        {
            playerController = GetComponent<PlayerController>();
            cameraController = FindObjectOfType<CameraController>();
        }
        else
        {
            aiController = GetComponent<AIController>();
        }
            
        health = GetComponent<Health>();
        StopRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            RagdollToggle();
        }

        if(health.health.value <= 0)
        {
            RagdollToggle();
            health.health.value = 1;
            pawn.dead = true;
        }

    }

    public void RagdollToggle()
    {
        foreach(Collider currentCollider in ragdollColliders)
        {
            currentCollider.enabled = !currentCollider.enabled;
        }
        foreach (Rigidbody currentRigidbody in ragdollRigidbodies)
        {
            currentRigidbody.isKinematic = !currentRigidbody.isKinematic;
        }

        anim.enabled = !anim.enabled;
        mainCollider.enabled = !mainCollider.enabled;
        mainRigidbody.isKinematic = !mainRigidbody.isKinematic;
        if(tag.Contains("Player"))
        {
            playerController.enabled = !playerController.enabled;
            cameraController.enabled = !cameraController.enabled;
        }
        else
        {
            aiController.enabled = !aiController.enabled;
        }
    }

    public void StopRagdoll()
    {
        foreach (Collider currentCollider in ragdollColliders)
        {
            currentCollider.enabled = false;
        }
        foreach (Rigidbody currentRigidbody in ragdollRigidbodies)
        {
            currentRigidbody.isKinematic = true;
        }

        anim.enabled = true;
        mainCollider.enabled = true;
        mainRigidbody.isKinematic = false;
    }
}
