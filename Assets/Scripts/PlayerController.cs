using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Header("Health Settings")]
    public float health;

    public float maxHealth;
    public HealthbarBehaviour healthbar;

    [SerializeField]
    [Header("Boat Settings")]
    public float accelerationFactor = 25;

    public float turnFactor = 25;

    [SerializeField]
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

    private void Update()
    {
        InputVector();
        UpdateHealthbar();
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

    public void TakeHit(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void UpdateHealthbar()
    {
        healthbar.SetHealth(health, maxHealth);
    }
}