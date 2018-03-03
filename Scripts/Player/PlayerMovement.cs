using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 8f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpVelocity = 8f;
    public float groundRadius = 0.05f;
    public LayerMask mask;

    private bool fallingBehind = false;
    private bool isGrounded;
    private bool jumpRequest;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private Vector2 playerSize;

    void Awake () {

        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        playerSize = GetComponent<BoxCollider2D>().size;
    }

    void Update () {

        Animate();
        Gravity();
        CheckInput();

        if (transform.position.x <= -3 && isGrounded) {

            fallingBehind = true;
        }

        else {

            fallingBehind = false;
        }

        if (fallingBehind) {

            Move();
        }
    }

    void FixedUpdate () {

        CheckJump();
    }

    private void Move () {

        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void Animate () {

        myAnimator.SetBool("IsGrounded", isGrounded);
        myAnimator.SetFloat("FallSpeed", myRigidbody.velocity.y);
    }

    private void Gravity () {

        if (myRigidbody.velocity.y < 0) {

            myRigidbody.gravityScale = fallMultiplier;
        }

        else if (myRigidbody.velocity.y > 0 && !Input.GetButton("Jump")) {

            myRigidbody.gravityScale = lowJumpMultiplier;
        }

        else {

            myRigidbody.gravityScale = 1f;
        }
    }

    private void CheckInput () {

        if (Input.GetButtonDown("Jump") && isGrounded) {

            jumpRequest = true;
        }
    }

    private void CheckJump () {

        if (jumpRequest) {

            myRigidbody.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);

            jumpRequest = false;
            isGrounded = false;
        }

        else {

            Vector2 rayStart = (Vector2)transform.position + Vector2.down * playerSize.y * 0.2f;
            isGrounded = Physics2D.Raycast(rayStart, Vector2.down, groundRadius, mask);
        }
    }
}
