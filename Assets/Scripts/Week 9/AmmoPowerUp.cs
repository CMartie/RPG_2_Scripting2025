using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPowerUp : PowerUpParent
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

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("picked up ammo");

            base.ResetAmmo();
             PickUp();
        }


    }
}

