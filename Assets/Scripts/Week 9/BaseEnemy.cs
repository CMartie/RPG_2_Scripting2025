using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float health = 20f;
    public float speed = 3f;
    public float attackDamage = 25f;

    public float attackRange = 3f;

    private float timer = 0f;

    [SerializeField] protected float attackInterval = 1f;

    private PlayerRPG player;

   //public float projectileDamages = 25f;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRPG>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(Vector3.Distance(this.transform.position, player.transform.position) < attackRange)
        {
            timer += Time.deltaTime;

            if (timer >= attackInterval)
            {
                Attack();
                timer = 0f;
            }
        }
      
        
    }

    protected virtual void Attack()
    {
        player.TakeDamage(attackDamage);
    }

    public virtual void Move()
    {
        
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

   /* protected virtual void TakeProjectileDamage(float projectileDamage)
    {

        health -= projectileDamage;

        if(health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
   */
    public virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(player.projectileDamages);
        }
    }
}
