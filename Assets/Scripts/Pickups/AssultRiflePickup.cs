using UnityEngine;

public class AssultRiflePickup : Pickups
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // if the player walks over the pickup
        {
            other.GetComponent<Pawn>().weaponUnlock = true; // unlock the rifle
            base.OnPickup(); // destroy the pickup
        }
    }
}
