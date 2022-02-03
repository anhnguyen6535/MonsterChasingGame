using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 15f;

    private float movementX;

    private Rigidbody2D myBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private string WALK_ANIMATION = "Walk";
    private bool isGrounded;
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    //1st fc to call
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerKeyboardMovement();
        PlayerAnimation();
        PlayerJump();
    }

    //Fixed Update is called certain times
    //Check in edit > settings > time
    void FixedUpdate()
    {
        //PlayerJump();
    }

    void playerKeyboardMovement(){
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX,0f,0f) * Time.deltaTime * moveForce;
    }

    void PlayerAnimation(){
        if(movementX >0)
        {
            animator.SetBool(WALK_ANIMATION, true);
            spriteRenderer.flipX = false;
        } 
        else if(movementX < 0)
        {
            animator.SetBool(WALK_ANIMATION,true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            myBody.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    //trigger box needs to be checked
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Collider2D can access to CompareTag directly while Collision cant
        if(collider.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
