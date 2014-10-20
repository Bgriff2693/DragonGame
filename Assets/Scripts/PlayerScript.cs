using UnityEngine;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// 1 - The speed of the head
    /// </summary>
    public Vector2 speed = new Vector2(50, 50);
    public Vector2 groundSpeed = new Vector2(10, 10);

    // 2 - Store the movement
    private Vector2 movement;

    public bool moving;

    public bool isFlying;

    public float inputX;
    public float inputY;

    void groundMovement()
    {
        HingeJoint2D[] joints;
        joints = GameObject.Find("Axis").GetComponents<HingeJoint2D>();

        HingeJoint2D[] joints2;
        joints2 = GameObject.Find("Axis2").GetComponents<HingeJoint2D>();

        GameObject.Find("Axis").GetComponent<AxisPiston>().enabled = true;
        GameObject.Find("Axis2").GetComponent<AxisPiston>().enabled = true;

        JointAngleLimits2D tiltUp = new JointAngleLimits2D();
        tiltUp.max = 90;
        tiltUp.min = -20;

        JointAngleLimits2D tiltDown = new JointAngleLimits2D();
        tiltDown.max = 20;
        tiltDown.min = -90;
        
        JointAngleLimits2D tiltHead = new JointAngleLimits2D();
        tiltHead.max = 70;
        tiltHead.min = -70;

        GameObject.Find("Neck14").GetComponent<CircleCollider2D>().enabled = false;
        
        GameObject.Find("Neck1").GetComponent<HingeJoint2D>().limits = tiltHead;

        GameObject.Find("Neck4").GetComponent<Rigidbody2D>().fixedAngle = true;
        GameObject.Find("Neck10").GetComponent<Rigidbody2D>().fixedAngle = true;

        if (GameObject.Find("Neck1").GetComponent<FlipScript>().isFlipped)
        {
            joints[0].enabled = false;
            joints[1].enabled = false;
            joints[2].enabled = true;
            joints[3].enabled = true;

            joints2[0].enabled = false; 
            joints2[1].enabled = false;
            joints2[2].enabled = true;
            joints2[3].enabled = true;

            GameObject.Find("Neck10").GetComponent<HingeJoint2D>().limits = tiltDown;
            GameObject.Find("Neck11").GetComponent<HingeJoint2D>().limits = tiltDown;

            Vector3 v = new Vector3(0, 0, 180);

            GameObject.Find("Neck4").GetComponent<Transform>().eulerAngles = v;

            Vector3 v2 = new Vector3(0, 0, 160);

            GameObject.Find("Neck10").GetComponent<Transform>().eulerAngles = v2;

        }
        else if (!GameObject.Find("Neck1").GetComponent<FlipScript>().isFlipped)
        {
            joints[0].enabled = true;
            joints[1].enabled = true;
            joints[2].enabled = false;
            joints[3].enabled = false;

            joints2[0].enabled = true;
            joints2[1].enabled = true;
            joints2[2].enabled = false;
            joints2[3].enabled = false;

            GameObject.Find("Neck10").GetComponent<HingeJoint2D>().limits = tiltUp;
            GameObject.Find("Neck11").GetComponent<HingeJoint2D>().limits = tiltUp;

            Vector3 v = new Vector3(0, 0, 0);

            GameObject.Find("Neck4").GetComponent<Transform>().eulerAngles = v;

            Vector3 v2 = new Vector3(0, 0, 20);

            GameObject.Find("Neck10").GetComponent<Transform>().eulerAngles = v2;
        }


        GameObject.Find("Neck1").GetComponent<HingeJoint2D>().useMotor = false;
        GameObject.Find("Neck2").GetComponent<HingeJoint2D>().useMotor = false;
        GameObject.Find("Neck3").GetComponent<HingeJoint2D>().useMotor = false;
        GameObject.Find("Neck4").GetComponent<HingeJoint2D>().useMotor = false;
        GameObject.Find("Neck5").GetComponent<HingeJoint2D>().useMotor = false;
        GameObject.Find("Neck6").GetComponent<HingeJoint2D>().useMotor = false;
        GameObject.Find("Neck7").GetComponent<HingeJoint2D>().useMotor = false;
        GameObject.Find("Neck8").GetComponent<HingeJoint2D>().useMotor = false;
        GameObject.Find("Neck9").GetComponent<HingeJoint2D>().useMotor = false;
        GameObject.Find("Neck10").GetComponent<HingeJoint2D>().useMotor = false;
        GameObject.Find("Neck11").GetComponent<HingeJoint2D>().useMotor = false;
        GameObject.Find("Neck12").GetComponent<HingeJoint2D>().useMotor = false;
        
    }

    void airMovement()
    {
        HingeJoint2D[] joints;
        joints = GameObject.Find("Axis").GetComponents<HingeJoint2D>();
        joints[0].enabled = false;
        joints[1].enabled = false;
        joints[2].enabled = false;
        joints[3].enabled = false;

        joints = GameObject.Find("Axis2").GetComponents<HingeJoint2D>();
        joints[0].enabled = false;
        joints[1].enabled = false;
        joints[2].enabled = false;
        joints[3].enabled = false;

        JointAngleLimits2D limits = new JointAngleLimits2D();
        limits.min = -20;
        limits.max = 20;

        GameObject.Find("Axis").GetComponent<AxisPiston>().enabled = false;
        GameObject.Find("Axis2").GetComponent<AxisPiston>().enabled = false;

        GameObject.Find("Neck4").GetComponent<Rigidbody2D>().fixedAngle = false;
        GameObject.Find("Neck10").GetComponent<Rigidbody2D>().fixedAngle = false;

        GameObject.Find("Neck1").GetComponent<HingeJoint2D>().limits = limits;

        GameObject.Find("Neck10").GetComponent<HingeJoint2D>().limits = limits;
        GameObject.Find("Neck11").GetComponent<HingeJoint2D>().limits = limits;

        GameObject.Find("Neck1").GetComponent<HingeJoint2D>().useMotor = true;
        GameObject.Find("Neck2").GetComponent<HingeJoint2D>().useMotor = true;
        GameObject.Find("Neck3").GetComponent<HingeJoint2D>().useMotor = true;
        GameObject.Find("Neck4").GetComponent<HingeJoint2D>().useMotor = true;
        GameObject.Find("Neck5").GetComponent<HingeJoint2D>().useMotor = true;
        GameObject.Find("Neck6").GetComponent<HingeJoint2D>().useMotor = true;
        GameObject.Find("Neck7").GetComponent<HingeJoint2D>().useMotor = true;
        GameObject.Find("Neck8").GetComponent<HingeJoint2D>().useMotor = true;
        GameObject.Find("Neck9").GetComponent<HingeJoint2D>().useMotor = true;
        GameObject.Find("Neck10").GetComponent<HingeJoint2D>().useMotor = true;
        GameObject.Find("Neck11").GetComponent<HingeJoint2D>().useMotor = true;
        GameObject.Find("Neck12").GetComponent<HingeJoint2D>().useMotor = true;

        GameObject.Find("Neck14").GetComponent<CircleCollider2D>().enabled = true;


    }

    void Update()
    {
        //Movement when flying
        if (isFlying)
        {
            // 3 - Retrieve axis information
            inputX = Input.GetAxis("Horizontal");

            if (transform.position.x <= -3 && inputX < 0)
            {
                inputX = 0;
            }

            if (transform.position.x >= 285 && inputX > 0)
            {
                inputX = 0;
            }

            inputY = Input.GetAxis("Vertical");
            if (transform.position.y <= -103 && inputY < 0)
            {
                inputY = 0;
            }

            if (transform.position.y >= 7 && inputY > 0)
            {
                inputY = 0;
            }

            if (inputX == 0 && inputY == 0) moving = false;
            else moving = true;

            if (inputX != 0 && inputY != 0)
            {
                inputX = (inputX * Mathf.Sqrt(2)) / 2;
                inputY = (inputY * Mathf.Sqrt(2)) / 2;
            }

            // 4 - Movement per direction
            movement = new Vector2(
              speed.x * inputX,
              speed.y * inputY);

            airMovement();
        }
        else
        {
            if (GameObject.Find("Neck1").GetComponent<FlipScript>().isFlipped == GameObject.Find("Neck22").GetComponent<FlipScript>().isFlipped)
            {
                inputX = Input.GetAxis("Horizontal");

                inputX = 0;

                if (inputX == 0) moving = false;
                else moving = true;

                if (transform.position.x <= -3 && inputX < 0)
                {
                    inputX = 0;
                }

                if (transform.position.x >= 285 && inputX > 0)
                {
                    inputX = 0;
                }

                inputY = 0;//no Y movement

                //to prevent going backwards (tentative, until I figure out how to flip him well)
                if (GameObject.Find("Head").GetComponent<FlipScript>().goingLeft)
                {
                    if (inputX > 0) inputX = 0;  //cannot change direction to go right
                }
                else if (GameObject.Find("Head").GetComponent<FlipScript>().goingRight)
                {
                    if (inputX < 0) inputX = 0; //cannot change direction to go left
                }

                movement = new Vector2(
                    groundSpeed.x * inputX,
                    groundSpeed.y * inputY);

                groundMovement();

                if (Input.GetAxis("Vertical") > 0)
                {
                    isFlying = true;
                }
               else isFlying = false;
            }
        }

        // 5 - Shooting
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        // Careful: For Mac users, ctrl + arrow is a bad idea

        if (shoot)
        {
            WeaponScript weapon = GameObject.Find("mouth").GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false because the player is not an enemy
                weapon.Attack(false);
            }
        }
    }

    public Vector2 getMovement()
    {
        return movement;
    }

    void FixedUpdate()
    {
        // 5 - Move the game object
        rigidbody2D.velocity = movement;
    }
}