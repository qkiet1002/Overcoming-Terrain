using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;

    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpbleGround;
    private float driX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForece = 14f;

    private enum MovemenntState { idle, running, jumping, falling }
    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // di chuyển
        driX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(driX * moveSpeed,rb.velocity.y);

        // nhảy
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play(); 
            rb.velocity = new Vector2(rb.velocity.x, jumpForece);
        }

        // hướng mặt
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovemenntState state;
  
        if (driX > 0f)
        {
            state = MovemenntState.running;
            sprite.flipX = false;
        }
        else if (driX < 0f)
        {
            state = MovemenntState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovemenntState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovemenntState.jumping;
        }else if(rb.velocity.y < -.1f)
        {
            state = MovemenntState.falling;
        }
        anim.SetInteger("state", (int)state); 
    }  

    private bool IsGrounded()
    {
        // điều kiện để không được nhảy 2 lần
      return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f, jumpbleGround);
    }
}
