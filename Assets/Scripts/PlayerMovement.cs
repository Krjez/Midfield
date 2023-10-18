using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int speed = 5;
    public int jumpSmall = 3;
    public int jumpMedium = 5;
    public int jumpLarge = 8;
    private bool isFacingRight = true;

    public LayerMask whatIsGround;
    public Transform GroundCheck;
    public float groundCheckRadius = 0.1f;
    private bool onGround = true;

    private Rigidbody2D body;
    private Animator anim;



    void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {

        onGround = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsGround);

        if (onGround) {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if ((horizontalInput > 0 && !isFacingRight) || (horizontalInput < 0 && isFacingRight))
            {
                Flip();
            }

            if ((Input.GetKey(KeyCode.Space)))
            {
                SmallJump();
            }
        }

        




    }

    private void Flip() {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }

    private void SmallJump() {
        body.velocity = new Vector2(body.velocity.x, jumpSmall);
        onGround = false;
    }
}
