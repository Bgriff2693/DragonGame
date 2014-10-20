using UnityEngine;
using System.Collections;

public class motorOscillation : MonoBehaviour {

    private JointMotor2D m;
    public int time = 100;

    public int cycle = 1;
    public int initialCycle;
    public int timeOffset = 1;

    private int idleSpeed = -20;
    private int movingSpeed = -80;

    private int tick;

    private bool isMoving;

	// Use this for initialization
	void Start () {
        m = this.GetComponent<HingeJoint2D>().motor;
        m.motorSpeed = idleSpeed;
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

            if (GameObject.Find("Dragon").GetComponent<PlayerScript>().moving || GameObject.Find("Dragon").GetComponent<PathScript>().moving)
            {
                time = 40;

                if (cycle == 1) m.motorSpeed = movingSpeed + ((-(float)movingSpeed / time) * tick);
                if (cycle == 2) m.motorSpeed = -1 * ((((float)movingSpeed / time) * tick));
                if (cycle == 3) m.motorSpeed = -1 * (movingSpeed + ((-(float)movingSpeed / time) * tick));
                if (cycle == 4) m.motorSpeed = (((float)movingSpeed / time) * tick);

                m.maxMotorTorque = 25000;
                if (!isMoving)
                {
                    tick = time - (time / timeOffset);
                    cycle = initialCycle;
                }
                isMoving = true;
            }
            else
            {
                time = 100;
   
                if (cycle == 1) m.motorSpeed = idleSpeed + ((-(float)idleSpeed/time) * tick);
                if (cycle == 2) m.motorSpeed = -1 * ((((float)idleSpeed/time) * tick));
                if (cycle == 3) m.motorSpeed = -1 * (idleSpeed + ((-(float)idleSpeed/time) * tick));
                if (cycle == 4) m.motorSpeed = (((float)idleSpeed/time) * tick);

                m.maxMotorTorque = 5000;
                if (isMoving)
                {
                    tick = time - (time / timeOffset);
                    cycle = initialCycle;
                }
                isMoving = false;
            }
        
            this.GetComponent<HingeJoint2D>().motor = m;
        }
	}

