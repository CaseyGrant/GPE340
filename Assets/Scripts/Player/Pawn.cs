using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Pawn : MonoBehaviour
{
    private Animator anim; // holds an animator
    public Weapon weapon; // allows acces to weapon variables

    [Header("Pawn Settings")]
    [SerializeField, Tooltip("Sets the speed the pawn can move"), Range(1f, 10f)]
    private float pawnSpeed; // sets the pawns speed

    [Header("Bullet Settings")]
    [Tooltip("Sets where the bullets will spawn")]
    public GameObject bulletSpawn; // holds the bullets spawn

    public GameObject rifleBulletSpawn; // where the rifles bullets spawn
    public GameObject pistolBulletSpawn; // where the pistols bullets spawn

    public GameObject bullet; // the object to shoot

    [SerializeField, Tooltip("Sets the speed the bullet can move"), Range(1f, 25f)]
    private float bulletSpeed; // sets the bullets speed

    public Weapon pistol; // gets the pistols variables
    public Weapon rifle; // gets the rifles variables

    private bool swap; // toggles pistol or rifle
    public bool weaponUnlock = false; // locks the rifle behind a pickup

    public Image currentGun; // displays current gun on UI
    public Sprite pistolSprite; // pistol image
    public Sprite rifleSprite; // rifle image
    public Text ammoCount; // displays ammo count

    void Start()
    {
        anim = GetComponent<Animator>(); // gets the animator
        weapon = pistol; // sets starting weapon to pistol
    }

    void Update()
    {
        Vector3 MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // gets the player input
        MoveDirection = Vector3.ClampMagnitude(MoveDirection, 1); // makes the max value 1
        Vector3 AnimationDirection = transform.InverseTransformDirection(MoveDirection); // makes North always north regardless of rotation

        anim.SetFloat("Speed", AnimationDirection.z * pawnSpeed); // sets the speed
        anim.SetFloat("Direction", AnimationDirection.x * pawnSpeed); // sets the direction

        if (weaponUnlock == true) // if rifle is picked up
        {
            if (Input.GetKeyDown(KeyCode.Tab)) // when tab is pressed
            {
                swap = !swap; // swap between rifle and pistol
            }

            if (swap == true) // if swapped
            {
                weapon = pistol; // equip pistol
                rifle.gameObject.SetActive(false); // hide rifle
                pistol.gameObject.SetActive(true); // show pistol
                bulletSpawn = pistolBulletSpawn; // update bullet spawnpoint
                currentGun.sprite = pistolSprite; // update UI
            }
            else
            {
                weapon = rifle; // equip rifle
                rifle.gameObject.SetActive(true); // show rifle
                pistol.gameObject.SetActive(false); // hide pistol
                bulletSpawn = rifleBulletSpawn; // update bullet spawnpoint
                currentGun.sprite = rifleSprite; // update UI
            }
        }
        else
        {
            rifle.gameObject.SetActive(false); // hide rifle
            pistol.gameObject.SetActive(true); // show pistol
            bulletSpawn = pistolBulletSpawn; // update bullet spawnpoint
            currentGun.sprite = pistolSprite; // updates UI
        }

        

        if (Input.GetMouseButtonDown(0)) // when left click is pressed
        {
            if (weapon == pistol) // if pistol is equipped
            {
                weapon.Fire.Invoke(); // shoot
            }
        }

        if (Input.GetMouseButton(0)) // when left click is held
        {
            if (weapon == rifle) // if rifle is equipped
            {
                weapon.Fire.Invoke(); // shoot
            }
        }

        if (Input.GetMouseButtonUp(0)) // when click is released
        {
            weapon.ResetFire.Invoke(); // reset timer
        }

        if (Input.GetKeyDown(KeyCode.R)) // when R is pressed
        {
            weapon.Reload.Invoke(); // reload
        }

        ammoCount.text = weapon.currentAmmo + "/" + weapon.magazineSize; // update the ammo counter
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
