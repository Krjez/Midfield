using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int speed = 5;
    public bool isFacingRight = true;

    public int jumpWait = 0;
    public int jumpSmall = 5;
    public int jumpMedium = 10;
    public int jumpLarge = 15;
    public Boolean coroutineRunning = false;
    WaitForSeconds waitTenthSec = new WaitForSeconds(0.1f);

    public LayerMask whatIsGround;
    public Transform GroundCheck;
    public float groundCheckRadius = 0.1f;
    private bool onGround = true;

    private Rigidbody2D body;



    void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    //Add on collision with ground turning point

    void FixedUpdate() {

        //TODO add camera movement

        onGround = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsGround);

        if (onGround && !coroutineRunning) {

            //Start of wait for the jump
            if (Input.GetKey(KeyCode.Space)) {
                JumpWaitHandle();
            }

            //Jumps certain height depending on time of previously held space key
            else if (jumpWait > 0) {
                JumpHandle();
            }

            //Not waiting for a jump - able to move
            else {
                MoveHandle();
            }
           
        }

    }


    private void MoveHandle() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if ((horizontalInput > 0 && !isFacingRight) || (horizontalInput < 0 && isFacingRight))
        {
            Flip();
        }
    }

    private void Flip() {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }

    private void JumpWaitHandle() {
        body.velocity = new Vector2(0, 0);
        StartCoroutine(JumpCoroutine());
        //Researched coroutines here: https://gamedevbeginner.com/coroutines-in-unity-when-and-how-to-use-them/
        //https://stackoverflow.com/questions/30056471/how-to-make-the-script-wait-sleep-in-a-simple-way-in-unity
    }

    private void JumpHandle() {
        if (jumpWait <= 2)
        {
            Jump(jumpSmall);
        }
        else if (jumpWait <= 7)
        {
            Jump(jumpMedium);
        }
        else
        {
            Jump(jumpLarge);
        }
    }

    private void Jump(int jumpHeight) {
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        if (isFacingRight) {
            body.velocity = new Vector2(jumpHeight, body.velocity.y);
        }
        else {
            body.velocity = new Vector2(-jumpHeight, body.velocity.y);
        }
        onGround = false;
        jumpWait = 0;

        //TODO Add horizontal transform dependent on direction facing
    }

    IEnumerator JumpCoroutine() {
        coroutineRunning = true;

        while (Input.GetKey(KeyCode.Space)) {
            jumpWait++;
            print(jumpWait);
            yield return waitTenthSec;
        }
        coroutineRunning = false;
    }


}
