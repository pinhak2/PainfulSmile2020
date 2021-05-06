using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject explosionEffect;
    public int damage;

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
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().TakeHit(damage);
        }
        else if (collision.tag == "Shooter")
        {
            collision.GetComponent<ShooterController>().TakeHit(damage);
        }
        else if (collision.tag == "Chaser")
        {
            collision.GetComponent<ChaserController>().TakeHit(damage);
        }

        Explosion();

        Destroy(this.gameObject);
    }

    private void Explosion()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
    }
}