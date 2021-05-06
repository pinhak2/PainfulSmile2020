using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [Header("Health Settings")]
    public float health;

    public float maxHealth;
    public int damage;
    public HealthbarBehaviour healthbar;
    public GameObject explosionEffect;

    [Header("Boat Settings")]
    public GameObject boat;

    [Header("Sprites")]
    public Sprite[] boatSpriteArray;

    [Header("Variables")]
    public float accelerationFactor = 25;

    public float turnFactor = 25;

    [Header("Shoot settings")]
    public GameObject bulletPrefab;

    [Header("Front Firepoint")]
    public Transform firePointFront;

    [Header("Left Firepoints")]
    public Transform[] leftFirePoints;

    [Header("Right Firepoints")]
    public Transform[] rightFirePoints;

    [Header("Obstacle settings")]
    public Tilemap obstacle;

    private float accelerationInput = 0;
    private float steeringInput = 0;
    private float rotationAngle = 0;

    private Vector2 rbVelocity;

    private Rigidbody2D rb;

    private Vector3 moveToPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        moveToPosition = Vector3.zero;
        UpdateHealthbar();
    }

    private void Start()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = boatSpriteArray[0];
    }

    private void Update()
    {
        InputVector();

        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeHit();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot("front");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Shoot("left");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot("right");
        }
    }

    private void Shoot(string side)
    {
        if (side == "front")
            Instantiate(bulletPrefab, firePointFront.position, firePointFront.rotation);

        if (side == "left")
        {
            for (int i = 0; i < leftFirePoints.Length; i++)
            {
                Instantiate(bulletPrefab, leftFirePoints[i].position, leftFirePoints[i].rotation);
            }
        }

        if (side == "right")
        {
            for (int i = 0; i < rightFirePoints.Length; i++)
            {
                Instantiate(bulletPrefab, rightFirePoints[i].position, rightFirePoints[i].rotation);
            }
        }
    }

    private void FixedUpdate()
    {
        MoveIfWontCrash();
        RotateBoat();
    }

    private void MoveIfWontCrash()
    {
        Vector3Int obstacleMapTile = ObstacleInNextPosition();

        if (obstacle.GetTile(obstacleMapTile) == null)
        {
            ApplyVerticalForce();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private Vector3Int ObstacleInNextPosition()
    {
        moveToPosition = transform.position + new Vector3(rb.velocity.x, rb.velocity.y, 0);
        Vector3Int obstacleMapTile = obstacle.WorldToCell(moveToPosition);

        return obstacleMapTile;
    }

    private void ApplyVerticalForce()
    {
        Vector2 verticalForceVector = transform.up * accelerationInput * accelerationFactor * Time.fixedDeltaTime;

        rb.AddForce(verticalForceVector, ForceMode2D.Force);
    }

    private void RotateBoat()
    {
        rotationAngle -= steeringInput * turnFactor;

        rb.MoveRotation(rotationAngle * Time.fixedDeltaTime);
    }

    private void InputVector()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    public void TakeHit()
    {
        if (health > 0) health -= damage;

        UpdateHealthbar();

        if (health > 2)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = boatSpriteArray[1];
        }

        if (health <= 2 && health >= 1)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = boatSpriteArray[2];
        }
        if (health <= 0)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(boat);
        }
    }

    private void UpdateHealthbar()
    {
        healthbar.SetHealth(health, maxHealth);
    }
}