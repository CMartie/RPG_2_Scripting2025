using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerip : PowerUpParent
{
    private PlayerRPG player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRPG>();
    }

    // Update is called once per frame
    void Update()
    {

    }


}
