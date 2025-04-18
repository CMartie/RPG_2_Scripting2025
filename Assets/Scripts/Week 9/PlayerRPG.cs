using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRPG : MonoBehaviour
{
    public float health = 100f;
    public float attackDamage = 5f;
    public float attackInterval = 1f;

    private float timer;
    private bool isAttackReady = true;

    public Image attackReadyImage;

    public GameObject bulletPrefab;
    public Transform spawnPosition;
    public float bulletForce = 500f;

    public GameObject YouDiedScreen;

    public int ammo = 8;

    public float projectileDamages = 25f;

    public TextMeshProUGUI healthText;



    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "" + health;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttackReady == false)
        {
            timer += Time.deltaTime;

            if (timer >= attackInterval)
            {
                isAttackReady = true;
                attackReadyImage.gameObject.SetActive(isAttackReady);
                timer = 0f;
            }
        }
        

        if(Input.GetMouseButtonDown(0))
        {
            if(isAttackReady == true)
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3f))
                {
                    BaseEnemy enemy = hit.collider.GetComponent<BaseEnemy>();

                    if (enemy != null)
                    {
                        Attack(enemy);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(ammo > 0)
            {
                Projectile();
            }
            
            
        } 
    }

    public void Attack(BaseEnemy enemy)
    {
        enemy.TakeDamage(attackDamage);
        isAttackReady = false;
        attackReadyImage.gameObject.SetActive(isAttackReady);
    }

    public void RangedAttack()
    {

    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        healthText.text = "" + health;

        if (health <= 0)
        {
            Debug.Log("YOU DIED");
            YouDiedScreen.SetActive(true);
        }
    }

    public void Projectile()
    {
            GameObject go = Instantiate(bulletPrefab, spawnPosition.position, spawnPosition.rotation);

            go.GetComponent<Rigidbody>().AddForce(go.transform.forward * bulletForce);

            ammo -= 1;
        
    }

    protected virtual void GiveProjectileDamage(BaseEnemy enemy)
    {

        enemy.TakeDamage(projectileDamages);

        if (health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vision Cone")
        {
            other.GetComponentInParent<BaseEnemy>().SeePlayer();
        }
    }
}
