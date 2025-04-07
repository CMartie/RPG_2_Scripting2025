using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_PowerUp : PowerUpParent
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public virtual void OnCollisionEnter(Collision other)
    {
        //Debug.Log("picked up ammo");

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("i am stronk now");

            base.ProjectileIncrease();
            base.PickUp();
        }


    }
}
