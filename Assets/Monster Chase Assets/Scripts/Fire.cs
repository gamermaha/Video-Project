using System;
using System.Collections;
using System.Collections.Generic;
using Monster_Chase_Assets.Scripts;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public MyScriptableScript spawnManagerValues;
    
    private Rigidbody2D _rb;
    private bool _checkForFlip;


    void Start() => _rb = GetComponent<Rigidbody2D>();

        void Update()
    {
        if (_checkForFlip) 
            _rb.velocity = new Vector2((-1 * spawnManagerValues.fireSpeed), _rb.velocity.y);
        else 
            _rb.velocity = new Vector2(spawnManagerValues.fireSpeed, _rb.velocity.y);
        
    } 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Monsters>(out var monsters))
        {
            monsters.Die();
            Destroy(gameObject); 
        }
        else if (collision.CompareTag("OutofCamera")) 
            Destroy(gameObject);
    }
   
    
    
    public void Shoot(bool flippedCheck) => _checkForFlip = flippedCheck;
    
}
