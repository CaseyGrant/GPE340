using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickups : Pickups
{

    [SerializeField] private float healAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Health>().Heal(healAmount);
            base.OnPickup();
        }
    }
}
