using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Pawn : MonoBehaviour
{
    private Animator anim; // holds an animator
    public Weapon weapon;

    [Header("Pawn Settings")]
    [SerializeField, Tooltip("Sets the speed the pawn can move"), Range(1f, 10f)]
    private float pawnSpeed; // sets the pawns speed

    [Header("Bullet Settings")]
    [Tooltip("Sets where the bullets will spawn")]
    public GameObject bulletSpawn; // holds the bullets spawn

    public GameObject rifleBulletSpawn;
    public GameObject pistolBulletSpawn;

    public GameObject bullet;

    [SerializeField, Tooltip("Sets the speed the bullet can move"), Range(1f, 25f)]
    private float bulletSpeed; // sets the bullets speed

    public Weapon pistol;
    public Weapon rifle;

    private bool swap;
    public bool weaponUnlock = false;

    public Image currentGun;
    public Sprite pistolSprite;
    public Sprite rifleSprite;
    public Text ammoCount;

    void Start()
    {
        anim = GetComponent<Animator>(); // gets the animator
        weapon = pistol;
    }

    void Update()
    {
        Vector3 MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // gets the player input
        MoveDirection = Vector3.ClampMagnitude(MoveDirection, 1); // makes the max value 1
        Vector3 AnimationDirection = transform.InverseTransformDirection(MoveDirection); // makes North always north regardless of rotation

        anim.SetFloat("Speed", AnimationDirection.z * pawnSpeed); // sets the speed
        anim.SetFloat("Direction", AnimationDirection.x * pawnSpeed); // sets the direction


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            swap = !swap;
        }

        if (weaponUnlock == true)
        {
            if (swap == true)
            {
                weapon = pistol;
                rifle.gameObject.SetActive(false);
                pistol.gameObject.SetActive(true);
                bulletSpawn = pistolBulletSpawn;
                currentGun.sprite = pistolSprite;
            }
            else
            {
                weapon = rifle;
                rifle.gameObject.SetActive(true);
                pistol.gameObject.SetActive(false);
                bulletSpawn = rifleBulletSpawn;
                currentGun.sprite = rifleSprite;
            }
        }
        else
        {
            weapon = pistol;
            rifle.gameObject.SetActive(false);
            pistol.gameObject.SetActive(true);
            bulletSpawn = pistolBulletSpawn;
            currentGun.sprite = pistolSprite;
        }

        

        if (Input.GetMouseButtonDown(0))
        {
            if (weapon == pistol)
            {
                weapon.Fire.Invoke();
            }

        }

        if (Input.GetMouseButton(0))
        {
            if (weapon == rifle)
            {
                weapon.Fire.Invoke();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            weapon.ResetFire.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            weapon.Reload.Invoke();
        }

        //if(weapon == pistol)
        //{
            ammoCount.text = weapon.currentAmmo + "/" + weapon.magazineSize;
        //}
    }

    public void OnAnimatorIK(int layerIndex)
    {
        if(weapon != null)
        {

            if(weapon.rightHandPoint != null)
            {
                anim.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandPoint.position);
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                anim.SetIKRotation(AvatarIKGoal.RightHand, weapon.rightHandPoint.rotation);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            }
            else
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            }

            if (weapon.leftHandPoint != null)
            {
                anim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHandPoint.position);
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                anim.SetIKRotation(AvatarIKGoal.LeftHand, weapon.leftHandPoint.rotation);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            }
            else
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
            }


        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
        }
    }
}
