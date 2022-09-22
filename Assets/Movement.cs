using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            _rb.AddForce(Vector2.up * jumpHeight);
        
        _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, _rb.velocity.y);
    }
}
