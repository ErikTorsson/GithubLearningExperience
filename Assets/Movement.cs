using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = Vector2.right * Input.GetAxisRaw("Horizontal") * speed;
    }
}
