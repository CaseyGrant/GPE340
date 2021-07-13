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
    private Animator anim; // holds an animator

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>(); // gets the animator
        pawn = GetComponent<Pawn>();
        nextBrainUse = Time.time;
        anim.applyRootMotion = true;

        if (gameObject.name.Contains("Clone")) // checks if its a clone
        {
            GameManager.Instance.GetComponent<DeathController>().enemy.Add(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextBrainUse)
        {
            agent.SetDestination(followTarget.position);
            nextBrainUse = Time.time + brainDelay;
        }

        Vector3 desiredMovement = agent.desiredVelocity;

        desiredMovement = this.transform.InverseTransformDirection(desiredMovement);
        desiredMovement = desiredMovement.normalized;
        desiredMovement *= speed;

        anim.SetFloat("Speed", desiredMovement.z); // sets the speed
        anim.SetFloat("Direction", desiredMovement.x); // sets the direction

        if(pawn.weaponUnlock == true)
        {
            pawn.EquipRifle();
            pawn.weapon.Fire.Invoke();
            pawn.weapon.currentAmmo = 15;
        }
        else
        {
            pawn.weapon.Fire.Invoke(); // shoot
            pawn.weapon.currentAmmo = 15;

        }
    }

    private void OnAnimatorMove()
    {
        agent.velocity = anim.velocity;
    }
}
