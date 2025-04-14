using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour
{
    public float health = 20f;
    public float speed = 3f;
    public float attackDamage = 25f;

    public float attackRange = 3f;

    private float timer = 0f;

    public AudioSource attackSound;
    public AudioClip hitClip;

    protected bool hasSeenPlayer = false;

    protected NavMeshAgent navAgent;

    [SerializeField]
    protected List<Transform> patrolPoints = new List<Transform>();

    protected int patrolPointIndex = 0;


    [SerializeField] protected float aggroRange = 5f;



    [SerializeField] protected float attackInterval = 1f;

    private PlayerRPG player;

   //public float projectileDamages = 25f;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRPG>();
        
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(patrolPoints[patrolPointIndex].position);
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        if (hasSeenPlayer == true)
        {
            if (navAgent.remainingDistance < 0.5f) //enemy reached last known location of the player
            {
                if (Vector3.Distance(this.transform.position, this.transform.position) > aggroRange) //
                {
                    hasSeenPlayer = false;
                }
            }
            else //they are not out of aggro range
            {
                if (isPlayerInLineOfSight() == true) // if player is within line of sight
                {
                    navAgent.SetDestination(player.transform.position);
                    navAgent.isStopped = false; //enemy will see player and will chase them
                }
            }
            //if the player is within attack range 
            if (Vector3.Distance(this.transform.position, player.transform.position) > attackRange)
            {
                RaycastHit hit; // and if the player is within line of sight

                Vector3 dir = player.transform.position - this.transform.position;
                dir.Normalize();


                if (Physics.Raycast(this.transform.position, dir, out hit))
                {
                    if (hit.collider.tag == "Player")
                    {
                        navAgent.SetDestination(player.transform.position);
                        navAgent.isStopped = false;
                    }

                }

            }
            else //if the player is within attack range
            {
                RaycastHit hit; //and in line of sight

                Vector3 dir = player.transform.position - this.transform.position;
                dir.Normalize();


                if (Physics.Raycast(this.transform.position, dir, out hit))
                {
                    Debug.Log(hit.collider.name);

                    if (hit.collider.tag == "Player")
                    {
                        navAgent.isStopped = true; //stop nav movements
                        this.transform.LookAt(player.transform.position); //look at player



                        timer += Time.deltaTime; //increase attack timer

                        if (timer > speed) //once attack timer reaches the attack speed
                        {
                            Attack(); //attack!
                            timer = 0; //reset timer


                        }
                    }

                }
                // else
                // {
                //     navAgent.isStopped = false;
                // }
            }


        }
        else //if the player has not been seen
        {
            if (navAgent.remainingDistance < 0.5f) // of tje navagent reacjes ots destination
            {
                patrolPointIndex++; //increase the patrol point indec=x so it will move

                if (patrolPointIndex >= patrolPoints.Count) //if the point is out of range
                {
                    patrolPointIndex = 0; //reset to 0
                }

                navAgent.SetDestination(patrolPoints[patrolPointIndex].position); //set destination to determined point
                navAgent.isStopped = false;
            }
        }


        /*if(Vector3.Distance(this.transform.position, player.transform.position) < attackRange)
        {
            timer += Time.deltaTime;

            if (timer >= attackInterval)
            {
                Attack();
                timer = 0f;
            }
        }*/


    }

    protected virtual void Attack()
    {
        attackSound.Play();
        player.TakeDamage(attackDamage);
    }

    public virtual void Move()
    {
        
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;

        attackSound.PlayOneShot(hitClip);

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

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hasSeenPlayer = true;
        }
    }


    protected bool isPlayerInLineOfSight()
    {
        RaycastHit hit;

        Vector3 dir = player.transform.position - this.transform.position;
        dir.Normalize();


        if (Physics.Raycast(this.transform.position, dir, out hit))
        {

            if (hit.collider.tag == "Player")
            {
                return true;
            }

        }

        return false;
    }

    public virtual void SeePlayer()
    {
        RaycastHit hit;

        Vector3 dir = player.transform.position - this.transform.position;

        dir.Normalize();

        if (Physics.Raycast(this.transform.position, dir, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                hasSeenPlayer = true;
            }
        }
        else
        {
            hasSeenPlayer = false;
        }

    }
}
