using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject explosionEffect;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.velocity = transform.right * -speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Explosion();

        Destroy(this.gameObject);
    }

    private void Explosion()
    {
      GameObject explosionEffectInstance =  Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(explosionEffectInstance, 1);
    }
}