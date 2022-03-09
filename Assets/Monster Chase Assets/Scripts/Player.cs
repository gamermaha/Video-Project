using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private bool isGrounded;
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        sr = GetComponent<SpriteRenderer>();
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update is called");
        PlayerMoveKeyboard();
        Debug.Log("Playermove is called");
        AnimatePlayer();
        PlayerJump();
    }

    private void FixedUpdate()
    {
        
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
       
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime ;
    }

    void AnimatePlayer()
    {
        Debug.Log("I am here in animate player");
        if (movementX > 0)
        {
            Debug.Log("I am here in animate player >0");
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            Debug.Log("I am here in animate player<0");
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX = true;
        }
        else
        {
            Debug.Log("I am here in animate player else condition");
            anim.SetBool(WALK_ANIMATION, false);
        }
        
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
