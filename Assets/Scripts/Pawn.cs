using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Pawn : MonoBehaviour
{
    private Animator Anim; // holds an animator
    public GameObject BulletSpawn; // holds the bullets spawn

    [SerializeField] private float PawnSpeed; // sets the pawns speed
    [SerializeField] private float BulletSpeed; // sets the bullets speed

    void Start()
    {
        Anim = GetComponent<Animator>(); // gets the animator
    }

    void Update()
    {
        Vector3 MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // gets the player input
        MoveDirection = Vector3.ClampMagnitude(MoveDirection, 1); // makes the max value 1
        Vector3 AnimationDirection = transform.InverseTransformDirection(MoveDirection); // makes North always north regardless of rotation

        Anim.SetFloat("Speed", AnimationDirection.z * PawnSpeed); // sets the speed
        Anim.SetFloat("Direction", AnimationDirection.x * PawnSpeed); // sets the direction

        if(Input.GetKeyDown(KeyCode.Space)) // when the player hits the space key
        {
            BulletSpawn.GetComponent<SpawnProjectile>().Shoot(BulletSpeed); // spawns a bullet
        }
    }
}
