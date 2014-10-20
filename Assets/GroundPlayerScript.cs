using UnityEngine;
using System.Collections;

public class GroundPlayerScript : MonoBehaviour {

    //movement variables
    public Vector2 speed = new Vector2(50, 50);
    private Vector2 movement;
    public bool moving;

    //jump variables
    public bool jumping;
    public bool landing;
    public bool onGround;
    public float jumpSpeed;
    private float tick;
    public float jumpAcc;

    //is running into a wall/obstacle
    public bool collisionRight;
    public bool collisionLeft;
    
    public bool canMoveLeft;
    public bool canMoveRight;

    public bool goingLeft;
    public bool goingRight;

    void Update()
    {
        //are true unless otherwise stated
        //canMoveLeft = true;
        //canMoveRight = true;

        //horizontal movement
        float inputX = Input.GetAxis("Horizontal");

        //prevents running off of the map (is there a way to make this not map-exclusive?)
        if (transform.position.x <= -3 || collisionLeft)
        {
            canMoveLeft = false;
            canMoveRight = true;
        }
        else if (transform.position.x >= 285 || collisionRight)
        {
            canMoveRight = false;
            canMoveLeft = true;
        }
        else
        {
            canMoveRight = true;
            canMoveLeft = true;
        }

        if (inputX > 0 && !canMoveRight) inputX = 0;
        if (inputX < 0 && !canMoveLeft) inputX = 0;

        if (inputX > 0)
        {
            goingRight = true;
            goingLeft = false;
        }
        else if (inputX < 0)
        {
            goingLeft = true;
            goingRight = false;
        }

        float inputY = Input.GetAxis("Vertical");
        inputY = inputY * inputY;    // will not be moving up, only left and right(unless jumping)

        if (inputX == 0) moving = false;
        else moving = true;
        
        //jumping initially
        if (inputY > 0 && onGround)
        {
            if (!jumping)
            {
                tick = Time.time;
                speed.y = jumpSpeed;
            }
            jumping = true;
            inputY = 1;
            speed.y = jumpSpeed + ((float)(-jumpAcc) * (Time.time - tick));
        }
        else if (jumping) //keep jumping
        {
            inputY = 1;
            speed.y = jumpSpeed + ((float)(-jumpAcc) * (Time.time - tick));
        }
        else if (!onGround && !jumping)//if falling, to not bounce upon leaving ground
        {
            inputY = 1;
            speed.y = ((float)(-jumpAcc) * (Time.time - tick));
        }

        movement = new Vector2(
            speed.x * inputX,
            speed.y * inputY);

        //attacking
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        
        if (shoot)
        {
            
        }

        //animation
        GameObject.Find("Player").GetComponent<Animator>().SetFloat("xVel", inputX);
        if (inputX == 0)
        {
            GameObject.Find("Player").GetComponent<Animator>().SetBool("Idle", true);
        }
        else GameObject.Find("Player").GetComponent<Animator>().SetBool("Idle", false);

    }

    public Vector2 getMovement()
    {
        return movement;
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = movement;
    }
}
