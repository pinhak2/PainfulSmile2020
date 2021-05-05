using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    [Header("Boat Settings")]
    public float accelerationFactor;
    public float turnFactor;

    [SerializeField]
    [Header("Local variables")]
    public float accelerationInput = 0;
    public float steeringInput = 0;

    public float rotationAngle = 0;

    public Vector2 rbVelocity;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        InputVector();
    }

    private void FixedUpdate()
    {
        ApplyEngineForce();
        ApplySteering();
        UpdateVelocity();

    }

    void ApplyEngineForce()
    {
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        rb.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        rotationAngle -= steeringInput * turnFactor;

            rb.MoveRotation(rotationAngle);
    }

    void UpdateVelocity()
    {
        rbVelocity = rb.velocity;
    }

    void InputVector()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;

    }
}