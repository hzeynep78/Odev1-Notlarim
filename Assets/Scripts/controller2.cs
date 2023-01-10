using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller2 : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float Speed = 1.0f;
    float movedirection;
    bool jump;
    bool grounded;//true deðer girmezsen otomatik false atar
    bool moving;
    Rigidbody2D rb;
    Animator _anim;
    SpriteRenderer sp;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(rb.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        rb.velocity = new Vector2(Speed * movedirection, rb.velocity.y);

        if (jump == true)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            jump = false;
        }
    }

    void Update()
    {
        if(grounded==true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                movedirection = -1.0f;
                sp.flipX = true;
                _anim.SetFloat("speed", Speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movedirection = 1.0f;
                sp.flipX = false;
                _anim.SetFloat("speed", Speed);
            }
        }
        else if(grounded == true)
        {
            movedirection = 0.0f;
            _anim.SetFloat("speed", 0.0f);
        }
        if(grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            _anim.SetTrigger("jump");
            _anim.SetBool("grounded", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("grounded"))
        {
            _anim.SetBool("grounded", true);
            grounded = true;
        }
    }
}
