using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Character
    private Rigidbody2D body;

    // Player speed
    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpSpeeed = 5;

    [HideInInspector] public bool isFacingRIght = true;

    // Wall
    [SerializeField] private LayerMask wallLayer;

    // Jump mods
    private float jumpModifier = 1.5f;

    public bool isDead = false;

    // Damage Check
    public bool damage = false;

    // Ref for the sprite
    SpriteRenderer spriteRenderer;

    // Damage sprite
    public Sprite deathSprite;

    //  Ref for animator
    private Animator anim;


    public JumpState jumpState = JumpState.GROUNDED;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {

        if (!isDead)
        {

        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

          


        // handles character directins
        if (horizontalInput > 0.01f)
        {
            spriteRenderer.flipX = false;
                isFacingRIght = true;

        } else if (horizontalInput < -0.01f)
        {
            spriteRenderer.flipX = true;
                isFacingRIght = false;
        }


        if (Input.GetKey(KeyCode.Space) && jumpState == JumpState.GROUNDED)
        {
            Jump();

        }


        // Set Animation
        anim.SetBool("isWalking", horizontalInput  != 0);
        anim.SetBool("isJump", jumpState == JumpState.JUMPING);
        anim.SetBool("isDamage", !damage);
            Debug.Log("Player hurt" + damage);
 
        }
        else
        {
            anim.SetBool("isDead", true);
            anim.enabled = false;
            ChangeSprite(deathSprite);
        }

    }

    private void ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    // jump mechanics
    private void Jump()
    {

        jumpState = JumpState.JUMPING;
        anim.SetTrigger("jump");
        body.velocity = new Vector2(body.velocity.x, jumpSpeeed * jumpModifier);
        
      
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpState = JumpState.GROUNDED;
        }
    }

   

    // Enum class
    public enum JumpState
    {
        GROUNDED,
        PREPARETOJUMP,
        JUMPING,
        INFLIGHT,
        LANDED
    }
}
