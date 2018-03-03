using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpVelocity = 8f;
    public float groundRadius = 0.05f;

    public LayerMask mask;

    private bool isGrounded;
    private bool jumpRequest;
    private Rigidbody2D myRigidbody;
    private Vector2 playerSize;

    void Awake () {

        myRigidbody = GetComponent<Rigidbody2D>();
        playerSize = GetComponent<BoxCollider2D>().size;
    }

    void Update () {

        Gravity();
        CheckInput();
    }

    void FixedUpdate () {

        CheckJump();
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
