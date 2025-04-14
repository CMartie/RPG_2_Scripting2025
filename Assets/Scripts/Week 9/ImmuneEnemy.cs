using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneEnemy : BaseEnemy
{
    public AudioClip thudNoise;
    public override void OnCollisionEnter(Collision other)
    {
        //base.OnCollisionEnter(other);
        if (other.gameObject.tag == "Bullet")
        {
            attackSound.PlayOneShot(thudNoise);
        }
    }
}
