using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    private bool _grounded;
    private CapsuleCollider2D _box;
    [SerializeField] private LayerMask groundLayer;
    private Animator _animator;
    public Vector2 checkPoint;

    // Start is called before the first frame update
    void Start()
    {
        checkPoint = transform.position;
        _animator = gameObject.GetComponent<Animator>();
        _box = gameObject.GetComponent<CapsuleCollider2D>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((bool)Physics2D.BoxCast(_box.bounds.center, _box.bounds.size, 0f, Vector2.down, .1f, groundLayer ))
        {
            _grounded = true;
        }
        else
        {
            _grounded = false;
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && _grounded)
            _rb.AddForce(Vector2.up * jumpHeight);
        
        _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, _rb.velocity.y);

        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            _animator.Play("Run");
        }
        else
        {
            _animator.Play("Idle");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            death();
        }
    }

    void death()
    {
        transform.position = checkPoint;
    }
}
