using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    public float moveSpeed;
    public float rotationPower;

    public float rotationAmout, speed, direction, maxSpeed;

    private Vector2 movement;

    public float aux;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame

    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            aux = moveSpeed;
        }


        
        rotationAmout = -Input.GetAxis("Horizontal");
        if(speed < maxSpeed)      speed = aux * rotationPower;
        direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rb.rotation += rotationAmout * rotationPower * rb.velocity.magnitude;

        rb.AddRelativeForce(Vector2.up * speed);
        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * rotationAmout / 2);
    }
}