using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float speed = 1.0f;
    Rigidbody2D rb;
    Animator _animator;
    Vector3 v3position;
    [SerializeField] GameObject _camera;
    SpriteRenderer _spriteRenderer;
    //int sayi;
    
    void Start()
    {
        _spriteRenderer= GetComponent<SpriteRenderer>();    
        rb= GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        v3position= transform.position;
        //sayi = 1;
        
    }

    void FixedUpdate()
    {   //Debug.Log("fixed" + sayi);
        //rb.velocity = new Vector2(speed, 0f);
        //sayi= 2;
        
    }

    void Update()
    {
        //if(Input.GetKey(KeyCode.Space))
        //{
        //    speed = 1.0f;
        //    //Debug.Log("Hýz 1.0f");
        //}

        //else
        //{
        //    speed = 0.0f;
        //    //Debug.Log("Hýz 0.0f");
        //}

        
        v3position = new Vector3(v3position.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), v3position.y);
        transform.position = v3position;
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);
        }

        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX= false;
        }
        else if(Input.GetAxis("Horizontal") < -0.1f)
        {
            _spriteRenderer.flipX= true;
        }
        //sayi = 3;
        

    }
    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(v3position.x,v3position.y,v3position.z -1.0f);
        //sayi = 4;
        
    }
}
