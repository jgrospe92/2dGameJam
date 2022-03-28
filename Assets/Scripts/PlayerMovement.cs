using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Character
    private Rigidbody2D body;

    // HUD
    public GameObject hud;

    // Player speed
    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpSpeeed = 5;

    // movement && direction
    [HideInInspector] public bool isFacingRIght = true;
    public float horizontalInput = 0f;
    public bool m_FacingRight = true;

    // HP GameObject
    public GameObject Hp;

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

    // Oxygen
    public bool addOxygen = false;

    public JumpState jumpState = JumpState.GROUNDED;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        PlayerPrefs.DeleteAll();
       
    }


    // Update is called once per frame
    void Update()
    {

        if (!isDead)
        {

        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

          


        // handles character directins
        if (horizontalInput > 0.01f && !m_FacingRight)
        {
                //spriteRenderer.flipX = false;
                //transform.Rotate(0f, 0f, 0f);
                isFacingRIght = true;
                flip();
                Hp.transform.Rotate(0f, 180f, 0f);


            } else if (horizontalInput < -0.01f && m_FacingRight)
        {
                //transform.Rotate(0f, 180f, 0f);
                // spriteRenderer.flipX = true;
                isFacingRIght = false;
                flip();
                Hp.transform.Rotate(0f, -180f, 0f);

            }


        if (Input.GetKey(KeyCode.Space) && jumpState == JumpState.GROUNDED)
        {
            Jump();

        }


        // Set walking & Jumping Animation
        anim.SetBool("isWalking", horizontalInput  != 0);
        anim.SetBool("isJump", jumpState == JumpState.JUMPING);

        // Set Damage Animation
        anim.SetBool("isDamage", damage);
     

        }
        else
        {
            anim.SetBool("isDead", true);
            anim.enabled = false;
            ChangeSprite(deathSprite);
        }

    }

  

    void flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.rotation = Quaternion.Euler(0, 180, 0) * transform.rotation;
     
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


        if (collision.gameObject.tag == "Finish")
        {
            isDead = true;
            hud.SetActive(true);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("OxygenTank"))
        {
            addOxygen = true;
            Destroy(collision.gameObject);
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
