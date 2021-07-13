using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Pawn : MonoBehaviour
{
    private Animator anim; // holds an animator
    public Weapon weapon; // allows acces to weapon variables

    [Header("Pawn Settings")]
    [SerializeField, Tooltip("Sets the speed the pawn can move"), Range(1f, 10f)]
    public float pawnSpeed; // sets the pawns speed

    [Header("Bullet Settings")]
    [Tooltip("Sets where the bullets will spawn")]
    public GameObject bulletSpawn; // holds the bullets spawn

    public GameObject rifleBulletSpawn; // where the rifles bullets spawn
    public GameObject pistolBulletSpawn; // where the pistols bullets spawn

    public GameObject bullet; // the object to shoot

    public Weapon pistol; // gets the pistols variables
    public Weapon rifle; // gets the rifles variables

    public bool weaponUnlock = false; // locks the rifle behind a pickup
    public bool dead = false;

    void Start()
    {
        anim = GetComponent<Animator>(); // gets the animator
        weapon = pistol; // sets starting weapon to pistol
    }

    void Update()
    {
        
    }

    public void EquipPistol()
    {
        weapon = pistol; // equip pistol
        rifle.gameObject.SetActive(false); // hide rifle
        pistol.gameObject.SetActive(true); // show pistol
        bulletSpawn = pistolBulletSpawn; // update bullet spawnpoint
    }

    public void EquipRifle()
    {
        weapon = rifle; // equip rifle
        rifle.gameObject.SetActive(true); // show rifle
        pistol.gameObject.SetActive(false); // hide pistol
        bulletSpawn = rifleBulletSpawn; // update bullet spawnpoint
    }

    public void OnAnimatorIK(int layerIndex)
    {
        if(weapon != null)
        {
            if(weapon.rightHandPoint != null) // if the right hand point has data
            {
                anim.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandPoint.position); // move hand
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1); // make movement override animation
                anim.SetIKRotation(AvatarIKGoal.RightHand, weapon.rightHandPoint.rotation); // rotate hand
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1); // make rotation override animation
            }
            else
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0); // make hand position follow animation
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0); // make hand rotation follow animation
            }

            if (weapon.leftHandPoint != null)
            {
                anim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHandPoint.position); // move hand
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1); // make movement override animation
                anim.SetIKRotation(AvatarIKGoal.LeftHand, weapon.leftHandPoint.rotation); // rotate hand
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1); // make rotation override animation
            }
            else
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0); // make hand position follow animation
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0); // make hand rotation follow animation
            }
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0); // make hand position follow animation
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0); // make hand rotation follow animation
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0); // make hand position follow animation
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0); // make hand rotation follow animation
        }
    }
}
