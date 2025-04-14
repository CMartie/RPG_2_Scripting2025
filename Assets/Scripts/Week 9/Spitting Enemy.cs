using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpittingEnemy : BaseEnemy
{
    public GameObject spitBallPrefab;
    public Transform spitSource;
    public float spitPower = 500f;
   


    protected override void Attack()
    {
        base.Attack();

        

        GameObject go = Instantiate(spitBallPrefab, spitSource.transform.position, spitSource.transform.rotation);
        go.GetComponent<Rigidbody>().AddForce(go.transform.forward * spitPower);
    }

    protected override void Update()
    {
        this.transform.LookAt(transform.position);
        base.Update();
    }
}
