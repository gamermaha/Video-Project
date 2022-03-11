using System;
using System.Collections;
using System.Collections.Generic;
using Monster_Chase_Assets.Scripts;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] 
    private float speed = 20f;
    
    private Rigidbody2D _rb;

    //private Vector3 _moveDirection;
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(speed, _rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
