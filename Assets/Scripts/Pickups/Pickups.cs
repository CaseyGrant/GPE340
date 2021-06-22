using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickups : MonoBehaviour
{
    public abstract void OnTriggerEnter(Collider other);

    public virtual void OnPickup()
    {
        Destroy(gameObject);
    }
}
