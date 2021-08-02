using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Pawn pawn;
    public Transform followTarget;
    public float speed;
    private float brainDelay = 0.1f;
    private float nextBrainUse;
    private Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // gets the navmesh agent
        anim = GetComponent<Animator>(); // gets the animator
        pawn = GetComponent<Pawn>(); // gets the pawn
        nextBrainUse = Time.time; // sets up the AI delay
        anim.applyRootMotion = true; // makes sure the AI uses root motion

        if (gameObject.name.Contains("Clone")) // checks if its a clone
        {
            GameManager.Instance.GetComponent<DeathController>().enemy.Add(gameObject); // adds the enemy to an enemy list
        }
        followTarget = GameObject.FindGameObjectWithTag("Player").transform;
        pawn.bullet = GameObject.FindGameObjectWithTag("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextBrainUse) // after a delay
        {
            agent.SetDestination(followTarget.position); // tell the AI where the player is
            nextBrainUse = Time.time + brainDelay; // reset the delay
        }

        Vector3 desiredMovement = agent.desiredVelocity; // the movement to get to the player

        desiredMovement = this.transform.InverseTransformDirection(desiredMovement); // make it work in world space
        desiredMovement = desiredMovement.normalized; // make it 1
        desiredMovement *= speed; // make it affected by speed

        anim.SetFloat("Speed", desiredMovement.z); // sets the speed
        anim.SetFloat("Direction", desiredMovement.x); // sets the direction

        if(pawn.weaponUnlock == true) // they get a rifle
        {
            pawn.EquipRifle(); // equip the rifle
            pawn.weapon.Fire.Invoke(); // shoot
            pawn.weapon.currentAmmo = 15; // never run out of ammo
        }
        else
        {
            pawn.weapon.Fire.Invoke(); // shoot
            pawn.weapon.currentAmmo = 15; // never run out of ammo

        }
    }

    private void OnAnimatorMove()
    {
        agent.velocity = anim.velocity; // use the root motion instead of the navmesh agent for movement
    }
}
