using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpParent : MonoBehaviour
{
    private PlayerRPG player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRPG>();
    }

    // Update is called once per frame
    

    public virtual void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }

}
