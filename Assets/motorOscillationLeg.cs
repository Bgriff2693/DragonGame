using UnityEngine;
using System.Collections;

public class motorOscillationLeg : MonoBehaviour {
    private JointMotor2D m;
    public int time = 100;

    public int cycle = 1;
    public int initialCycle;
    public int timeOffset = 1;

    private int movingSpeed = -300;

    private int tick;

    private bool isMoving;

	// Use this for initialization
    void Start()
    {
        m = this.GetComponent<HingeJoint2D>().motor;
        m.motorSpeed = 0;
        tick = time - (time / timeOffset);
        this.GetComponent<HingeJoint2D>().motor = m;
        isMoving = false;
        initialCycle = cycle;
    }
	
	// Update is called once per frame
	void Update () {
        ++tick;
        if (tick == time)
        {
            if (cycle == 4) cycle = 1;
            else ++cycle;
            tick = 0;
        }

        if (cycle == 1 || cycle == 4)
        {
            if (m.motorSpeed > 0)
            {
                m.motorSpeed *= -1;
            }
        }
        if (cycle == 2 || cycle == 3)
        {
            if (m.motorSpeed < 0)
            {
                m.motorSpeed *= -1;
            }
        }
        if (GameObject.Find("Dragon").GetComponent<PlayerScript>().moving)
        {
            this.rigidbody2D.fixedAngle = false;

            if (cycle == 1) m.motorSpeed = movingSpeed + ((-(float)movingSpeed / time) * tick);
            if (cycle == 2) m.motorSpeed = -1 * ((((float)movingSpeed / time) * tick));
            if (cycle == 3) m.motorSpeed = -1 * (movingSpeed + ((-(float)movingSpeed / time) * tick));
            if (cycle == 4) m.motorSpeed = (((float)movingSpeed / time) * tick);

            m.maxMotorTorque = 15000;
            time = 10;
            if (!isMoving)
            {
                tick = time - (time / timeOffset);
                cycle = initialCycle;
            }
            isMoving = true;

        }
        else if(!GameObject.Find("Dragon").GetComponent<PlayerScript>().isFlying)
        {
            m.motorSpeed = 0;
            Vector3 v = this.gameObject.transform.eulerAngles;
            this.gameObject.transform.eulerAngles = new Vector3(v.x, v.y, v.z);
            this.rigidbody2D.fixedAngle = true;
        }

        this.GetComponent<HingeJoint2D>().motor = m;

        if (GameObject.Find("Dragon").GetComponent<PlayerScript>().isFlying)
        {
            this.GetComponent<HingeJoint2D>().useMotor = false;
            this.GetComponent<Rigidbody2D>().fixedAngle = false;
            this.GetComponent<Rigidbody2D>().isKinematic = false;

        }
        else
        {
            this.GetComponent<HingeJoint2D>().useMotor = false;
            m.motorSpeed = 0;
            Vector3 v = this.gameObject.transform.eulerAngles;
            if(GameObject.Find("Neck1").GetComponent<FlipScript>().isFlipped) this.gameObject.transform.eulerAngles = new Vector3(v.x, v.y, 180);
            else this.gameObject.transform.eulerAngles = new Vector3(v.x, v.y, 0);
            this.rigidbody2D.fixedAngle = true;
            if(this.name == "ForeLeg")this.rigidbody2D.isKinematic = true;

        }
    }
}

