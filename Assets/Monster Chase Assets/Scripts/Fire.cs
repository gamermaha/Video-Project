using System;
using System.Collections;
using System.Collections.Generic;
using Monster_Chase_Assets.Scripts;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    
    private Rigidbody2D _rb;
    [SerializeField] private Player playerPlaying;
    private bool _checkForFlip;

    //private Vector3 _moveDirection;
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (_checkForFlip)
        {
            _rb.velocity = new Vector2((-1 * speed), _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(speed, _rb.velocity.y);
        }
    }

    public void Shoot(bool flippedCheck)
    {
        _checkForFlip = flippedCheck;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Monsters>(out var monsters))
        {
            monsters.Die();
            Destroy(gameObject); 
        }
    }
}
