using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
//[RequireComponent(typeof(Animator))]


//Base code from Naoise Collin's classes, Github link:
//https://github.com/naoisecollins/GD2BPlayerController/blob/main/Assets/Scripts/AdvancedPlayerMovement.cs
//
//Heavily modified by me
//Jakub Polacek


public class PlayerMovement : MonoBehaviour {

    //speed for left and right movement on the ground
    //isFacingRight Determines where the character is looking, affected by Flip()
    public int speed = 5;
    public bool isFacingRight = true;

    //Values for different velocity in different jumps
    public int jumpSmall = 7;
    public int jumpMedium = 9;
    public int jumpLarge = 12;

    //coroutineRunning for checking, so that only one JumpCoroutine() can run at the same time
    //custom waitTenthSec, so the corountine runs exactly 10 times per second
    //jumpWait counts the number of coroutine runs, determines the type of jump
    public Boolean coroutineRunning = false;
    public int jumpWait = 0;
    WaitForSeconds waitTenthSec = new WaitForSeconds(0.1f);

    //variables and objects used for physics logic
    private Rigidbody2D body;
    public LayerMask whatIsGround;
    public Transform GroundCheck;
    public Transform GroundCheckOpposite;
    private bool onGround = true;
    public PhysicsMaterial2D playerBounce, playerGround;


    //assigns the player object's rigidbody into variable when it is being loaded in and moves them to the last
    void Awake() {
        body = GetComponent<Rigidbody2D>();
        body.transform.position = new Vector2(GameManager.instance.playerX, GameManager.instance.playerY);
        if(GameManager.instance.isFlipped) {
            Flip();
        }
    }

    //FixedUpdate frames used for physics related logic
    void FixedUpdate() {
        OnGroundCheck();

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

    //Function for bouncing off the walls and stopping at ground
    public void OnCollisionEnter2D(Collision2D collision) {

        OnGroundCheck();

        if (onGround) {

            //Helps with stopping the player bouncing off the ground in high speed, where the material switch could be applied late
            body.velocity = new Vector2(0, 0);
            AudioManager.instance.PlayLandingSound();
        }
        else {
            Flip();
        }
    }

    //Checks if the player is on the ground/very close to ground with rectangle area drawn by 2 points
    public void OnGroundCheck() {
        onGround = Physics2D.OverlapArea(GroundCheck.position, GroundCheckOpposite.position, whatIsGround);

        //Switches player's material depending on proximity to ground
        if (onGround) {
            body.sharedMaterial = playerGround;
        }
        else {
            body.sharedMaterial = playerBounce;
        }

    }

    //Handles horizontal movement, flips
    private void MoveHandle() {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Waits with sound until player is moving
        if(horizontalInput != 0) {
            AudioManager.instance.PlayFootstepSound();
        }

        if ((horizontalInput > 0 && !isFacingRight) || (horizontalInput < 0 && isFacingRight)) {
            Flip();
        }
    }

    //Flip character to look on the other side
    private void Flip() {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }

    //Prevents player from moving left/right when charging jump, starts coroutine to count the time
    private void JumpWaitHandle() {
        body.velocity = new Vector2(0, 0);
        StartCoroutine(JumpCoroutine());
        //Researched coroutines here: https://gamedevbeginner.com/coroutines-in-unity-when-and-how-to-use-them/
        //https://stackoverflow.com/questions/30056471/how-to-make-the-script-wait-sleep-in-a-simple-way-in-unity
    }

    //Coroutine with check to run only 1 at a time. Counts tenths of a second
    IEnumerator JumpCoroutine() {
        coroutineRunning = true;

        while (Input.GetKey(KeyCode.Space))
        {
            jumpWait++;
            yield return waitTenthSec;
        }
        coroutineRunning = false;
    }

    //Decides how high the jump is gonna be
    private void JumpHandle() {
        if (jumpWait <= 2) {
            Jump(jumpSmall);
        }
        else if (jumpWait <= 7) {
            Jump(jumpMedium);
        }
        else {
            Jump(jumpLarge);
        }
    }

    //Jumps itself and reset of the support variables
    private void Jump(int jumpHeight) {

        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        AudioManager.instance.PlayJumpSound();

        if (isFacingRight) {
            body.velocity = new Vector2(jumpHeight, body.velocity.y);
        }
        else {
            body.velocity = new Vector2(-jumpHeight, body.velocity.y);
        }
        
        body.sharedMaterial = playerBounce;
        jumpWait = 0;
        onGround = false;

    }

    //Saves last player position before changing screens
    private void OnDestroy() {
        GameManager.instance.playerX = body.position.x;
        GameManager.instance.playerY = body.position.y;
        GameManager.instance.isFlipped = !isFacingRight;
    }
}
