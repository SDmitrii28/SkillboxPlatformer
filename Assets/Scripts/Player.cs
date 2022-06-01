using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //public Camera cam;
    [SerializeField] private float speed, jumpForce,groundCheckRadius;
    [SerializeField] private GameObject spriteGo;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask ground;
    private Animator anim;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private float moveX;
    private bool grounded;
    private int coin;
    public Text tx;
    public AudioSource aud_s;
    public AudioSource aud_jump;
    public AudioSource aud_land;

    // Start is called before the first frame update
    void Start()
    {
        coin = 0;
        anim = spriteGo.GetComponent<Animator>();
        sprite = spriteGo.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        tx.text = "Glyphs:" + coin.ToString();
        moveX = Input.GetAxis("Horizontal");
        grounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckRadius,ground);
        Vector2 velo = Vector2.zero;
        velo.x = moveX * speed;
        velo.y = rb.velocity.y;
        rb.velocity = velo;
        //cam.transform.position = new Vector2(transform.position.x,cam.transform.position.y);
        if (rb.velocity.x < 0)
        {
            sprite.flipX = true;
            aud_s.Play();
        }
        if (rb.velocity.x > 0)
        {
            aud_s.Play();
            sprite.flipX = false;
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            aud_jump.Play();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else
            if(!grounded && rb.velocity.y>0 && rb.velocity.y < 0.1)
            {
                aud_land.Play();
            }
            
        CheckAnimation();
    }
    private void CheckAnimation()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("VelocityX",Mathf.Abs(rb.velocity.x));
        anim.SetFloat("VelocityY",rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("coins"))
        {
            coin += 1;
            Destroy(collision.gameObject);
        }
    }

}
