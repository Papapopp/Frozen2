using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [Tooltip("How fast the player can move")]
    public float xVelocity;
    [Tooltip("The applied jump velocity")]
    public float jumpVel;
    [Tooltip("The gravitational pull")]
    public float gravity;
    [Tooltip("How long the player hangs in the air before falling")]
    public float hangtime;

    private float currentHang;
    private float yVel;
    private float xVel;
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
        MovePlayer();
    }

    private void ApplyHorizMovement()
    {

        if (!isJumping)
        {
            xVel = 0;
            if (CurrMoves.right)
            {
                xVel = xVelocity;
            }
            if (CurrMoves.left)
            {
                xVel = -xVelocity;
            }
            if (CurrMoves.right & CurrMoves.left)
            {
                xVel = 0;
            }
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
        

    }



    private void MovePlayer()
    {
        velocity = new Vector3(xVel, yVel, 0);
        this.transform.position += velocity * Time.deltaTime;
    }

    private void GetMovement()
    {
        CurrMoves.left = Input.GetKey(KeyCode.A);
        CurrMoves.right = Input.GetKey(KeyCode.D);
        CurrMoves.jump = Input.GetKey(KeyCode.Space) | Input.GetKey(KeyCode.W);

    }
}
