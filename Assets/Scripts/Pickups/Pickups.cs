using UnityEngine;

public abstract class Pickups : MonoBehaviour
{
    public abstract void OnTriggerEnter(Collider other); // requires all children to have trigger detetion

    public virtual void OnPickup()
    {
        Destroy(gameObject); // destroy the pickup
    }
}
