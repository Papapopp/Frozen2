using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [Tooltip("How fast the player can move")]
    public float xVelocity;
    [Tooltip("Applied force to player")]
    public float addSpeed;
    [Tooltip("The applied jump velocity")]
    public float jumpVel;
    [Tooltip("The gravitational pull")]
    public float gravity;
    [Tooltip("How long the player hangs in the air before falling")]
    public float hangtime;

    private float currentHang;
    private float yVel;
    private bool canJump;
    private bool isJumping;

    private struct moves
    {
        public bool left;
        public bool right;
        public bool jump;
    }

    private moves CurrMoves;
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetMovement();
        ApplyHorizMovement();
        ApplyVertMovement();
    }

    private void ApplyHorizMovement()
    {

        Rigidbody2D rb2d = this.GetComponent<Rigidbody2D>();
        if (CurrMoves.left)
        {
            rb2d.AddForce(new Vector2(-addSpeed, 0));
        }
        if (CurrMoves.right)
        {
            rb2d.AddForce(new Vector2(addSpeed, 0));
        }

        if (Mathf.Abs(rb2d.velocity.x) > xVelocity)
        {
            //Returns 1 or -1
            float dir = rb2d.velocity.x / Mathf.Abs(rb2d.velocity.x);
            rb2d.velocity = dir * new Vector2(xVelocity, 0);
        }

    }

    private void ApplyVertMovement()
    {
        //Checks if the player can jump and if the player is hitting the jump button
        if (CurrMoves.jump & canJump)
        {
            yVel += jumpVel;
            currentHang = hangtime;
            canJump = false;
            isJumping = true;
        }

        //If the player is jumping, then check if they are pressing jump to hang or not
        if (isJumping)
        {
            float yChange = Mathf.Pow(Time.deltaTime * gravity, 2);
            if (Mathf.Abs(yVel) < 0.25 && currentHang > 0 && CurrMoves.jump)
            {
                currentHang -= Time.deltaTime;
            }
            else
            {
                yVel -= yChange;
            }
        }

        velocity = new Vector3(0, yVel, 0);
        this.transform.position += velocity * Time.deltaTime;
    }

    private void GetMovement()
    {
        CurrMoves.left = Input.GetKey(KeyCode.A);
        CurrMoves.right = Input.GetKey(KeyCode.D);
        CurrMoves.jump = Input.GetKey(KeyCode.Space) | Input.GetKey(KeyCode.W);

    }
}
