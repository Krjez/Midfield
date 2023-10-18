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
  //  public Transform GroundCheck;
    public float groundCheckRadius = 0.1f;
    private bool onGround = true;

    private Rigidbody2D body;
    private Animator anim;



    void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate() {

        if (onGround) {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if ((horizontalInput > 0 && !isFacingRight) || (horizontalInput < 0 && isFacingRight))
            {
                Flip();
            }
        }

       // onGround = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsGround);



    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }

}
