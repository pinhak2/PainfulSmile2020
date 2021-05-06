using UnityEngine;

public class ChaserController : MonoBehaviour
{
    [Header("Health Settings")]
    public float health;

    public float maxHealth;
    public HealthbarBehaviour healthbar;
    public GameObject explosionEffect;

    [Header("Movement Settings")]
    public float speed;

    public Transform player;

    private float distanceToPlayer;

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

        UpdateHealthbar();
    }

    private void Update()
    {
        RotateToFacePlayer();

        Move();

        UpdateHealthbar();
    }

    private void Move()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > 0)
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
        else if (health == 1)
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
       GameManagerController.score++ ;
        Destroy(this.gameObject);
    }

    private void UpdateHealthbar()
    {
        healthbar.SetHealth(health, maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().TakeHit(2);
            Die();
        }
    }
}