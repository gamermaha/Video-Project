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
    [SerializeField] private float moveForce = 10f;

    [SerializeField] private float jumpForce = 11f;
    [SerializeField] private LayerMask _enemyLayerMask = default;
    [SerializeField] private Fire firyfire;
    
    [SerializeField] private AudioSource walkAudio;
    [SerializeField] private AudioSource jumpAudio;
    [SerializeField] private AudioSource fireAudio;


    private float movementX;

    public GameObject killed;
    public GameObject fired;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";


    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    //private string FIRE_ANIMATION = "Fire";
    public bool firing = false;

    public delegate void PlayerDied(bool isAlive);

    public event PlayerDied PlayerDiedInfo;

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
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
        PlayerFire();
    }

    private void FixedUpdate()
    {
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            walkAudio.Play();
            FlipPlayer(false);
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            walkAudio.Play();
            FlipPlayer(true);
            
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    public void FlipPlayer(bool flip)
    {
        if (flip)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = Vector3.one;
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
            //firing = true;
            Instantiate(firyfire, transform.position, Quaternion.identity);
            var raycastHit = Physics2D.Raycast(transform.position, (transform.right * transform.localScale.x), 12, _enemyLayerMask);
            fireAudio.Play();
            Debug.DrawRay(transform.position, (transform.right * transform.localScale.x) * 12, Color.red, 0.25f);
            Debug.Log("Value of raycast.collider is: " + raycastHit.collider);

            if (raycastHit.collider != null)
            {
                if (raycastHit.collider.TryGetComponent<Monsters>(out var monsters))
                {
                    Debug.Log("Ray has been collided with a monster");
                    monsters.Die();
                    
                    
                }
            }


            //GameObject fire_animation =  Instantiate(fired);
            // , transform.position, Quaternion.identity
            //anim.SetBool(FIRE_ANIMATION, true);
        }
    }

    void ExecuteDeath()
    {
        if (PlayerDiedInfo != null)
        { 
            
            PlayerDiedInfo(false);
            
            
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
            
            GameObject animation = Instantiate(killed, transform.position, Quaternion.identity);
            ExecuteDeath();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            //deathAudio.Play();
            GameObject deathAnimation = Instantiate(killed, transform.position, Quaternion.identity);
            ExecuteDeath();
            Destroy(gameObject);
        }
    }
}