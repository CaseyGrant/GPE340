using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Pawn pawn;
    private Animator anim;

    private bool swap; // toggles pistol or rifle

    public Image currentGun; // displays current gun on UI
    public Sprite pistolSprite; // pistol image
    public Sprite rifleSprite; // rifle image
    public Text ammoCount; // displays ammo count

    // Start is called before the first frame update
    void Start()
    {
        pawn = GetComponent<Pawn>(); // gets the pawn
        anim = GetComponent<Animator>(); // gets the animator
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // gets the player input
        MoveDirection = Vector3.ClampMagnitude(MoveDirection, 1); // makes the max value 1
        Vector3 AnimationDirection = transform.InverseTransformDirection(MoveDirection); // makes North always north regardless of rotation

        anim.SetFloat("Speed", AnimationDirection.z * pawn.pawnSpeed); // sets the speed
        anim.SetFloat("Direction", AnimationDirection.x * pawn.pawnSpeed); // sets the direction

        if (pawn.weaponUnlock == true) // if rifle is picked up
        {
            if (Input.GetKeyDown(KeyCode.Tab)) // when tab is pressed
            {
                swap = !swap; // swap between rifle and pistol
            }

            if (swap == true) // if swapped
            {
                pawn.EquipPistol();
                currentGun.sprite = pistolSprite; // update UI
            }
            else
            {
                pawn.EquipRifle();
                currentGun.sprite = rifleSprite; // update UI
            }
        }
        else
        {
            pawn.EquipPistol();
            currentGun.sprite = pistolSprite; // updates UI
        }



        if (Input.GetMouseButtonDown(0)) // when left click is pressed
        {
            if (pawn.weapon == pawn.pistol) // if pistol is equipped
            {
                pawn.weapon.Fire.Invoke(); // shoot
            }
        }

        if (Input.GetMouseButton(0)) // when left click is held
        {
            if (pawn.weapon == pawn.rifle) // if rifle is equipped
            {
                pawn.weapon.Fire.Invoke(); // shoot
            }
        }

        if (Input.GetMouseButtonUp(0)) // when click is released
        {
            pawn.weapon.ResetFire.Invoke(); // reset timer
        }

        if (Input.GetKeyDown(KeyCode.R)) // when R is pressed
        {
            pawn.weapon.Reload.Invoke(); // reload
        }

        ammoCount.text = pawn.weapon.currentAmmo + "/" + pawn.weapon.magazineSize; // update the ammo counter
    }
}
