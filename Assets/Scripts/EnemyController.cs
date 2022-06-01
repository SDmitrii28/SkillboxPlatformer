using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool forward;

    public float Speed;
    //public Animator Anim;
    //public SpriteRenderer Sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 velo = Vector2.right*Speed;
        if (!forward)
            velo = Vector2.left*Speed;

        velo.y = rb.velocity.y;
        rb.velocity = velo;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            forward = !forward;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suricane"))
        {
            Destroy(gameObject);
        }
    }
}
