using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssultRiflePickup : Pickups
{

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Pawn>().weaponUnlock = true;
            base.OnPickup();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
