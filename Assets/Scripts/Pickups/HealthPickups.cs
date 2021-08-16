using UnityEngine;

public class HealthPickups : Pickups
{
    [SerializeField] private float healAmount; // the amount the pickup will heal

    public GameObject hearts;

    public void Start()
    {
        GameObject particles = Instantiate(hearts, gameObject.transform); // spawn a particle
        particles.GetComponent<ParticleSystem>().Play(); // activates the particle
    }

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
