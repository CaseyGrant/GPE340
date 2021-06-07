using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Pawn : MonoBehaviour
{
    private Animator Anim; // holds an animator

    [Header("Pawn Settings")]
    [SerializeField, Tooltip("Sets the speed the pawn can move"), Range(1f, 10f)]
    private float PawnSpeed; // sets the pawns speed

    [Header("Bullet Settings")]
    [Tooltip("Sets where the bullets will spawn")]
    public GameObject BulletSpawn; // holds the bullets spawn

    [SerializeField, Tooltip("Sets the speed the bullet can move"), Range(1f, 25f)]
    private float BulletSpeed; // sets the bullets speed

    /// <summary>
    /// On start gets the animator and allows it to be accessed
    /// </summary>
    void Start()
    {
        Anim = GetComponent<Animator>(); // gets the animator
    }

    /// <summary>
    /// Every frame update the animation parameters
    /// Also check if space has been pressed then spawn a bullet
    /// </summary>
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
