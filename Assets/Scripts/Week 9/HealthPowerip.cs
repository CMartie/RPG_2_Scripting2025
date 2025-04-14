using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerip : PowerUpParent
{
   // private PlayerRPG player;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRPG>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void NewHealth()
    {
        if(player.health < 100)
        {
            player.health = 100;
        }
        player.healthText.text = "" + player.health;
    }

    public virtual void OnCollisionEnter(Collision other)
    {
        //Debug.Log("picked up ammo");

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("i am healed");

            NewHealth();
            base.PickUp();
        }


    }


}
