using UnityEngine;
using System.Collections;

public class PathScript : MonoBehaviour {
   //current nodes on path. Subject to change
    public GameObject node1;
    public GameObject node2;
    public GameObject node3;

    public GameObject tether;//current node following
    GameObject next;

    public Vector2 speed;
    public Vector2 movement;

    public bool moving;

    public float slope;

	void Start () {//initialization
        node1 = GameObject.Find("PathNode1");
        node2 = GameObject.Find("PathNode2");
        node3 = GameObject.Find("PathNode3");

        tether = node1;
        speed = this.GetComponent<PlayerScript>().speed;
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


	// Update is called once per frame
	void Update () {
        float inputX = 0;
        float inputY = 0;

        if (this.transform.position.x < tether.transform.position.x + 1 && this.transform.position.x > tether.transform.position.x - 1 && this.transform.position.y < tether.transform.position.y + 1 && this.transform.position.y > tether.transform.position.y - 1)
        {
            if (tether.name == node1.name)
            {
                tether = node2;
            }
            else if (tether.name == node2.name)
            {
                tether = node3;
            }
            else if (tether.name == node3.name)
            {
                tether = node1;
            }
        }

        if (this.transform.position.x <= tether.transform.position.x)
        {
            inputX = 1;
        }
        else if (this.transform.position.x >= tether.transform.position.x)
        {
            inputX = -1;
        }
        else inputX = 0;

        if (this.transform.position.y <= tether.transform.position.y)
        {
            inputY = 1;
        }
        else if (this.transform.position.y >= tether.transform.position.y)
        {
            inputY = -1;
        }
        else inputY = 0;


        if (transform.position.x <= -3 && inputX < 0)
        {
            inputX = 0;
        }
        
        if (transform.position.x >= 285 && inputX > 0)
        {
            inputX = 0;
        }

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

        //good angle changes. Holla!
        float angle = Mathf.Atan(Mathf.Abs(transform.position.y - tether.transform.position.y)/Mathf.Abs(transform.position.x - tether.transform.position.x));
        float xdis = Mathf.Cos(angle);
        float ydis = Mathf.Sin(angle);

        movement = new Vector2(
            speed.x * inputX * xdis,
            speed.y * inputY * ydis);

        airMovement();
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
