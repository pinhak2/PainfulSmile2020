using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Header("Health Settings")]
    public float health;

    public float maxHealth;
    public HealthbarBehaviour healthbar;

    [SerializeField]
    [Header("Boat Settings")]
    public float accelerationFactor;

    public float turnFactor;

    private float accelerationInput = 0;
    private float steeringInput = 0;
    private float rotationAngle = 0;

    private Vector2 rbVelocity;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        UpdateHealthbar();
    }

    private void Update()
    {
        InputVector();
        UpdateHealthbar();
    }



    private void FixedUpdate()
    {
        ApplyVerticalForce();
        RotateBoat();
    }

    private void ApplyVerticalForce()
    {
        Vector2 verticalForceVector = transform.up * accelerationInput * accelerationFactor;

        rb.AddForce(verticalForceVector, ForceMode2D.Force);
    }

    private void RotateBoat()
    {
        rotationAngle -= steeringInput * turnFactor;

        rb.MoveRotation(rotationAngle);
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