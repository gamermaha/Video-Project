﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Monster_Chase_Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Vector2;

public class Player : MonoBehaviour
{
    ////// Variables for Inspector Window //////
    
    // Variables for the Player
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;
    
    // GameObjects to be imported
    [SerializeField] private LayerMask _enemyLayerMask = default;
    [SerializeField] private Fire firyfire;
    
    // Audio Sources 
    [SerializeField] private AudioSource walkAudio;
    [SerializeField] private AudioSource jumpAudio;
    [SerializeField] private AudioSource fireAudio;

    
    ///// Variables for Script////////
    
    private float movementX;
    public GameObject killed;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    
    //Boolean Variables
    public bool walking = false;
    public bool flippedorNot = false;
    private bool isGrounded;
    
    //Tags
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    
    
    //Death Execution
    public delegate void PlayerDied(bool isAlive);
    public event PlayerDied PlayerDiedInfo;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
        PlayerFire();
    }
    void PlayerMoveKeyboard()
    {
        walkAudio.Play();
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    void AnimatePlayer()
    {
        
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            walking = true;
            FlipPlayer(false);
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            walking = true;
            FlipPlayer(true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
            walking = false;
        }
        if (walking)
            walkAudio.Play();
        else
        {
            walkAudio.Stop();
        }
    }

    public void FlipPlayer(bool flip)
    {
        if (flip)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            flippedorNot = true;
        }
        else
        {
            transform.localScale = Vector3.one;
            flippedorNot = false;
        }
    }
    

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpAudio.Play();
        }
    }
    private void PlayerFire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var my_fire = Instantiate(firyfire, transform.position,Quaternion.identity);
            my_fire.Shoot(flippedorNot);
            
            var raycastHit = Physics2D.Raycast(transform.position, (transform.right * transform.localScale.x), 12, _enemyLayerMask);
            fireAudio.Play();

            if (raycastHit.collider != null)
            {
                if (raycastHit.collider.TryGetComponent<Monsters>(out var monsters))
                    monsters.Die();
            }
        }
    }
    void ExecuteDeath()
    {
        if (PlayerDiedInfo != null)
            PlayerDiedInfo(false);
    }

    void OnDeath()
    {
        GameObject animation = Instantiate(killed, transform.position, Quaternion.identity);
        ExecuteDeath();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true;
        
        if (collision.gameObject.CompareTag(ENEMY_TAG))
            OnDeath();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
            OnDeath();
    }
}