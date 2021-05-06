using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [Header("Health Settings")]
    public float health;

    public float maxHealth;
    public HealthbarBehaviour healthbar;
    public GameObject explosionEffect;

    [Header("Movement Settings")]
    public float speed;
    public float stoppingDistance;
    public Transform player;

    [Header("Shoot Settings")]
    public Transform firePoint;

    public float startTimeBtwShots;
    private float timeBtwShots;
    private float distanceToPlayer;
    public GameObject projectile;

    [Header("Sprites")]
    public Sprite[] boatSpriteArray;



    private GameObject gameManager;
    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = GameObject.FindGameObjectWithTag("Manager");
        rb = this.GetComponent<Rigidbody2D>();
        health = maxHealth;
                timeBtwShots = startTimeBtwShots;
        UpdateHealthbar();
    }

    private void Update()
    {
        RotateToFacePlayer();

        Move();

        Shoot();
        UpdateHealthbar();
    }


    private void Shoot()
    {
        if (distanceToPlayer <= stoppingDistance)

        {
            if (timeBtwShots <= 0)
            {
                GameObject bullet = Instantiate(projectile, firePoint.transform.position, GetComponentInChildren<Transform>().rotation);

                float invertBulletDirection = -bullet.GetComponent<BulletController>().speed;
                bullet.GetComponent<BulletController>().speed = invertBulletDirection;

                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    private void Move()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = this.transform.position;
        }
    }

    private void RotateToFacePlayer()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    public void TakeHit(int damage)
    {
        if (health > 0) health -= damage;

        UpdateHealthbar();
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (health > 1)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = boatSpriteArray[1];
        }
        else if (health == 1 )
        {
            GetComponentInChildren<SpriteRenderer>().sprite = boatSpriteArray[2];
        }
        else if (health == 0)
        {
            Die();
           
        }
    }

    private void Die()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        gameManager.GetComponent<GameManagerController>().score++;
        Destroy(this.gameObject);
    }

    private void UpdateHealthbar()
    {
        healthbar.SetHealth(health, maxHealth);
    }
}