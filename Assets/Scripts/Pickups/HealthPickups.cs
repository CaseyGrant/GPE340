using UnityEngine;

public class HealthPickups : Pickups
{
    [SerializeField] private float healAmount; // the amount the pickup will heal

    public override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) // checks if the player walked over the pickup
        {
            other.GetComponent<Health>().Heal(healAmount); // heals the player
            base.OnPickup(); // destroys the pickup
        }
        if (other.CompareTag("Enemy")) // checks if the player walked over the pickup
        {
            other.GetComponent<Health>().Heal(healAmount); // heals the player
            base.OnPickup(); // destroys the pickup
        }
    }
}
