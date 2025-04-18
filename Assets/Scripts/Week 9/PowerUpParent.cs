using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpParent : MonoBehaviour
{
    public PlayerRPG player;
    // public bool WasCollected = false;
    public BaseEnemy enemy;

    public AudioSource popNoise;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRPG>();
    }

    // Update is called once per frame
    

    /*public virtual void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            WasCollected = true;
            this.gameObject.SetActive(false);
        }
    }*/

    public virtual void ResetAmmo()
    {
        player.ammo = 8;
        
    }

    public virtual void PickUp()
    {
        StartCoroutine(DisableDelay());
    }

    IEnumerator DisableDelay()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        popNoise.Play();
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    protected virtual void ProjectileIncrease()
    {
        player.projectileDamages = 100f;
    }
}
