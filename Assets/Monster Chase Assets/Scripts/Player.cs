using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Monster_Chase_Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Vector2;

public class Player : MonoBehaviour
{
    
    public delegate void PlayerDied(bool isAlive); 
    public event PlayerDied PlayerDiedInfo;
    ////// Variables for Inspector Window //////
    
    // Variables for the Player
    [Header("Movement Settings")]
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;
    
    // GameObjects to be imported
    [Header("GameObjects Imported")]
    public GameObject killed;
    [SerializeField] private Weapon myWeapon;
    
    
    
    // Audio Sources 
    [Header("Audio Sources Imported")]
    [SerializeField] private AudioSource walkAudio;
    [SerializeField] private AudioSource jumpAudio;
 
    
    ///// Variables for Script////////
    
    private float movementX;
    
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
   
    
    //Boolean Variables
    public bool walking = false;
    public bool isFlipped = false;
    private bool isGrounded;
    
    //Tags
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    
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
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpAudio.Play();
        }
    }
    void PlayerFire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myWeapon.PlayerDirection(isFlipped);
            myWeapon.FireBullet();
        }
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
    void OnDeath()
    {
        GameObject animation = Instantiate(killed, transform.position, Quaternion.identity);
        ExecuteDeath();
        Destroy(gameObject);
    }
    void ExecuteDeath()
    {
        if (PlayerDiedInfo != null)
            PlayerDiedInfo(false);
    }
    public void FlipPlayer(bool flip)
    {
        if (flip)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFlipped = true;
        }
        else
        {
            transform.localScale = Vector3.one;
            isFlipped = false;
        }
    }
}